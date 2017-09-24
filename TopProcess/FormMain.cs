using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml.Serialization;
using System.IO;
using TopProcess.Engine;
using TopProcess.Properties;
using System.Drawing.Imaging;

namespace TopProcess
{
  public partial class FormMain : Form
  {
    private TopProcessWorker worker = null;
    private ChartPainter chartPainter = null;
    private Dictionary<string, ProgressBar> diskBars = null;

    public FormMain()
    {
      InitializeComponent();
      timerGetState.Interval = 2000;
      this.worker = new TopProcessWorker(timerGetState.Interval);
    }

    private void FormMain_Load(object sender, EventArgs e)
    {
      RestoreSettings();
      this.chartPainter = new ChartPainter(this.panelChart);
      timerGetState.Enabled = true;
      this.worker.Refresh();
      CreateDiskBarControls();
      RefillAll();
    }

    private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
    {
      StoreSettings();
    }

    private void RefillAll()
    {
      this.worker.Refresh();
      gridMemory.AutoGenerateColumns = false;
      gridMemory.DataSource = this.worker.TopMemory;
      gridCpu.AutoGenerateColumns = false;
      gridCpu.DataSource = this.worker.TopCpu;
      UpdateDiskBarControls();
    }

    private void timerGetState_Tick(object sender, EventArgs e)
    {
      RefillAll();
      int cpuRounded = (int)Math.Round(this.worker.CpuUsagePercent);
      int memRounded = (int)Math.Round(this.worker.MemoryUsagePercent);
      this.chartPainter.AddNewPercent(cpuRounded, memRounded);
      this.Text = "C: " + cpuRounded.ToString() + "% M: " + memRounded.ToString() + "%";
    }

    private void StoreSettings()
    {
      // Copy window location to app settings
      Settings.Default.WindowLocation = this.Location;

      // Copy window size to app settings
      if (this.WindowState == FormWindowState.Normal)
        Settings.Default.WindowSize = this.Size;
      else
        Settings.Default.WindowSize = this.RestoreBounds.Size;
      Settings.Default.WindowAllwaysOnTop = this.TopMost;

      // Save settings
      Settings.Default.Save();
    }

    private void RestoreSettings()
    {
      // window location
      if (Settings.Default.WindowLocation != null)
        this.Location = Settings.Default.WindowLocation;

      // window size
      if (Settings.Default.WindowSize != null)
        this.Size = Settings.Default.WindowSize;

      this.TopMost = Settings.Default.WindowAllwaysOnTop;
      if (!Settings.Default.WindowAllwaysOnTop)
      {
        this.ShowIcon = true;
        this.ShowInTaskbar = true;
      }
    }

    private void panelChart_Paint(object sender, PaintEventArgs e)
    {
      base.OnPaint(e);
      this.chartPainter.ControlOnPaint(sender, e);
    }

    private void CreateDiskBarControls()
    {
      int top = 0;
      int height = 0;
      this.diskBars = new Dictionary<string, ProgressBar>();
      foreach (var diskInfo in this.worker.DiskUsage)
      {
        var lb = new Label();
        panelDisks.Controls.Add(lb);
        lb.Top = top;
        lb.Text = diskInfo.DiskName;
        lb.Height = 16;
        top += lb.Height;
        height += lb.Height;

        var pg = new ProgressBar();
        panelDisks.Controls.Add(pg);
        pg.Top = top;
        pg.Tag = lb;
        pg.Width = panelDisks.ClientSize.Width;
        this.diskBars.Add(diskInfo.DiskName, pg);
        top += pg.Height + 12;
      }

      if (panelDisks.Height == 0)
      {
        this.Height += height;
        panelDisks.Height = height;
      }

      if (top < panelDisks.Height)
        this.Height = this.Height - (panelDisks.Height - top);
    }

    private void UpdateDiskBarControls()
    {
      foreach (var diskInfo in this.worker.DiskUsage)
      {
        if (this.diskBars.ContainsKey(diskInfo.DiskName))
        {
          var bar = this.diskBars[diskInfo.DiskName];
          if (diskInfo.PercentUsed < 100)
          {
            bar.Value = (int)diskInfo.PercentUsed;
            var label = bar.Tag as Label;
            label.Text = diskInfo.DiskName + " " + diskInfo.PercentUsed.ToString("f") + " %";
          }
        }
      }
    }

  }

  public class ChartPainter
  {
    private Control targetControl;
    private Queue<int> cpuValues;
    private Queue<int> memValues;

    public ChartPainter(Control paintMe)
    {
      this.targetControl = paintMe;
      this.cpuValues = new Queue<int>(this.targetControl.Width);
      this.memValues = new Queue<int>(this.targetControl.Width);
      for (int i = 0; i < this.targetControl.Width; i++)
      {
        this.cpuValues.Enqueue(0);
        this.memValues.Enqueue(0);
      }
    }

    public void ControlOnPaint(object sender, PaintEventArgs e)
    {
      Bitmap bmp = new Bitmap(this.targetControl.Width, this.targetControl.Height);
      Graphics bmpGraph = Graphics.FromImage(bmp);
      bmpGraph.Clear(this.targetControl.BackColor);
      decimal controlRatio = (decimal)this.targetControl.Height / 100M;

      /// Draw CPU usage percent
      using (Pen myPen = new Pen(Color.Blue))
      {
        int xx = 0;
        Point lastCpu = new Point(0, this.targetControl.Height);

        foreach (int cpuVal in this.cpuValues)
        {
          int controlRatioPx = this.targetControl.Height - (int)Math.Round(cpuVal * controlRatio);
          Point currentCpu = new Point(xx, controlRatioPx);
          bmpGraph.DrawLine(myPen, lastCpu, currentCpu);
          lastCpu = currentCpu;
          xx++;
        }
      }

      /// Draw memory usage percent
      using (Pen myPen = new Pen(Color.Green))
      {
        int xx = 0;
        Point lastMem = new Point(0, this.targetControl.Height);

        foreach (int memVal in this.memValues)
        {
          int controlRatioPx = this.targetControl.Height - (int)Math.Round(memVal * controlRatio);
          Point currentMem = new Point(xx, controlRatioPx);
          bmpGraph.DrawLine(myPen, lastMem, currentMem);
          lastMem = currentMem;
          xx++;
        }
      }

      e.Graphics.DrawImage(bmp, new Point(0, 0));
    }


    public void AddNewPercent(int cpuUsagePercent, int memUsagePercent)
    {
      this.cpuValues.Dequeue();
      this.cpuValues.Enqueue(cpuUsagePercent > 100 ? 100 : cpuUsagePercent);

      this.memValues.Dequeue();
      this.memValues.Enqueue(memUsagePercent > 100 ? 100 : memUsagePercent);

      this.targetControl.Invalidate();
    }

  }

}
