using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.ComponentModel;
using System.Timers;

namespace TopProcess.Engine
{

  [Serializable]
  public class TopProcessItem
  {
    public string Name { get; set; }
    public string ExecutableName { get; set; }

    public long ProcessID { get; set; }

    public bool ItemProcessExists { get; set; }

    public decimal CpuUsagePercent { get; set; }
    public string CpuUsageForBind
    {
      get
      {
        decimal rounded = Math.Round(this.CpuUsagePercent);
        if (rounded == 0)
          rounded = 1;
        return rounded.ToString();
      }
    }

    public decimal CpuLoadTotalCurrent { get; set; }
    public decimal CpuLoadTotalLast { get; set; }
    public decimal CpuLoadPeriod { get; set; }

    public DateTime LoadTimeCurrent { get; set; }
    public DateTime LoadTimeLast { get; set; }
    public decimal PeriodMiliseconds { get; set; }

    public long MemoryConsumption { get; set; }

  }

  [Serializable]
  public class DiskUsageInfo
  {
    public string DiskName { get; set; }
    public float PercentUsed { get; set; }
    private PerformanceCounter performanceCounter { get; set; }

    public DiskUsageInfo(string diskName)
    {
      this.DiskName = diskName;
      this.performanceCounter = new PerformanceCounter("PhysicalDisk", "% Disk Time", this.DiskName);
    }

    public void ReadPerformanceCounterData()
    {
      this.PercentUsed = this.performanceCounter.NextValue();
    }
  }

  public class TopProcessWorker
  {
    private int processCheckInterval;

    public List<TopProcessItem> Items { get; private set; }
    public List<DiskUsageInfo> DiskUsage { get; private set; }
    public decimal CpuUsagePercent { get; private set; }
    public decimal MemoryUsagePercent { get; private set; }

    public List<TopProcessItem> TopMemory { get; private set; }
    public List<TopProcessItem> TopCpu { get; private set; }

    public TopProcessWorker()
    {
      this.processCheckInterval = 2000;
      this.Items = new List<TopProcessItem>();
    }

    public TopProcessWorker(int pcInterval)
    {
      this.processCheckInterval = pcInterval;
      this.Items = new List<TopProcessItem>();
      this.DiskUsage = new List<DiskUsageInfo>();
    }

    public void Refresh()
    {
      var perfData = PsApiWrapper.GetPerformanceInfo();
      decimal memAvailable = (decimal)perfData.PhysicalAvailableBytes;
      decimal memTotal = (decimal)perfData.PhysicalTotalBytes;
      this.MemoryUsagePercent = (memTotal - memAvailable) / memTotal * 100;

      foreach (TopProcessItem tpi in this.Items)
        tpi.ItemProcessExists = false;

      var procs = Process.GetProcesses();
      foreach (var prc in procs)
      {
        try
        {
          RefreshItemFromProcess(prc);
        }
        catch
        {
          /// for now, I am ignoring the fact that query for process is throwing an exception
        }
      }
      RecalculateTopProcesses();
      RefreshDiskUsageData();

      this.Items.RemoveAll(it => !it.ItemProcessExists);
      this.CpuUsagePercent = this.Items.Sum(cp => cp.CpuUsagePercent);
    }

    private void RefreshItemFromProcess(Process prc)
    {
      var item = this.Items.FirstOrDefault(it => it.ProcessID == prc.Id);
      if (item == null)
      {
        item = new TopProcessItem();
        this.Items.Add(item);
        item.Name = prc.ProcessName;
        /// didn't find a way to check if MainModule is accessible
        try
        {
          item.ExecutableName = GetExecutablePath(prc);
        }
        catch { }

        item.ProcessID = prc.Id;
        item.CpuLoadTotalLast = 0;
        item.LoadTimeLast = DateTime.Now;
      }

      decimal prcTimeInMs = (decimal)prc.TotalProcessorTime.TotalMilliseconds;
      item.LoadTimeCurrent = DateTime.Now;
      item.PeriodMiliseconds = 0;

      item.CpuLoadTotalCurrent = prcTimeInMs;

      if (item.CpuLoadTotalLast != 0)
      {
        item.PeriodMiliseconds = (decimal)item.LoadTimeCurrent.Subtract(item.LoadTimeLast).TotalMilliseconds;
        if (item.PeriodMiliseconds > 0)
        {
          item.CpuLoadPeriod = prcTimeInMs - item.CpuLoadTotalLast;
          item.CpuUsagePercent = ((item.CpuLoadPeriod / item.PeriodMiliseconds) * 100) / Environment.ProcessorCount;
        }
      }

      item.MemoryConsumption = prc.WorkingSet64 / (1024 * 1024);
      item.ItemProcessExists = true;
      item.CpuLoadTotalLast = prcTimeInMs;
      item.LoadTimeLast = item.LoadTimeCurrent;
    }

    private void RecalculateTopProcesses()
    {
      /// group by process name
      var memItems = this.Items.GroupBy(tpi => tpi.ExecutableName)
                               .Select(grp => new TopProcessItem
                               {
                                 Name = grp.First().Name,
                                 MemoryConsumption = grp.Sum(tpi => tpi.MemoryConsumption)
                               }).ToList();

      this.TopMemory = memItems.OrderByDescending(tpi => tpi.MemoryConsumption).Take(5).ToList();

      var cpuItems = this.Items.GroupBy(tpi => tpi.ExecutableName)
                               .Select(grp => new TopProcessItem
                               {
                                 Name = grp.First().Name,
                                 CpuUsagePercent = grp.Sum(tpi => tpi.CpuUsagePercent)
                               }).ToList();
      this.TopCpu = cpuItems.Where(tpi => tpi.CpuUsagePercent > 0).OrderByDescending(tpi => tpi.CpuUsagePercent).Take(5).ToList();
    }

    private static string GetExecutablePath(Process Process)
    {
      //If running on Vista or later use the new function
      if (Environment.OSVersion.Version.Major >= 6)
      {
        return GetExecutablePathAboveVista(Process.Id);
      }

      return Process.MainModule.FileName;
    }

    private static string GetExecutablePathAboveVista(int ProcessId)
    {
      var buffer = new StringBuilder(1024);
      IntPtr hprocess = OpenProcess(ProcessAccessFlags.QueryLimitedInformation,
                                    false, ProcessId);
      if (hprocess != IntPtr.Zero)
      {
        try
        {
          int size = buffer.Capacity;
          if (QueryFullProcessImageName(hprocess, 0, buffer, out size))
          {
            return buffer.ToString();
          }
        }
        finally
        {
          CloseHandle(hprocess);
        }
      }
      throw new Win32Exception(Marshal.GetLastWin32Error());
    }

    private void RefreshDiskUsageData()
    {
      var cat = new PerformanceCounterCategory("PhysicalDisk");
      var instances = cat.GetInstanceNames();

      if (!this.DiskUsage.Any())
      {
        var unsortedList = new List<DiskUsageInfo>();
        foreach (var diskName in instances)
        {
          if (diskName != "_Total")
          {
            var diskUsage = new DiskUsageInfo(diskName);
            unsortedList.Add(diskUsage);
          }
        }
        this.DiskUsage.AddRange(unsortedList.OrderBy(us => us.DiskName));
      }

      foreach (var usageData in this.DiskUsage.ToList())
      {
        try
        {
          usageData.ReadPerformanceCounterData();
        }
        catch (System.InvalidOperationException)
        {
          // disk was removed
          this.DiskUsage.Remove(usageData);
        }
      }

    }

    #region imports
    [Flags]
    enum ProcessAccessFlags : uint
    {
      All = 0x001F0FFF,
      Terminate = 0x00000001,
      CreateThread = 0x00000002,
      VMOperation = 0x00000008,
      VMRead = 0x00000010,
      VMWrite = 0x00000020,
      DupHandle = 0x00000040,
      SetInformation = 0x00000200,
      QueryInformation = 0x00000400,
      QueryLimitedInformation = 0x00001000,
      Synchronize = 0x00100000,
      ReadControl = 0x00020000
    }

    [DllImport("kernel32.dll")]
    private static extern bool QueryFullProcessImageName(IntPtr hprocess, int dwFlags,
                   StringBuilder lpExeName, out int size);
    [DllImport("kernel32.dll")]
    private static extern IntPtr OpenProcess(ProcessAccessFlags dwDesiredAccess,
                   bool bInheritHandle, int dwProcessId);

    [DllImport("kernel32.dll", SetLastError = true)]
    private static extern bool CloseHandle(IntPtr hHandle);
    #endregion
  }


}
