namespace TopProcess
{
  partial class FormMain
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
      if (disposing && (components != null))
      {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
      this.panelMemory = new System.Windows.Forms.Panel();
      this.gridMemory = new System.Windows.Forms.DataGridView();
      this.gridMemoryColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gridMemoryColumnMemory = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.panelChart = new System.Windows.Forms.Panel();
      this.gridCpu = new System.Windows.Forms.DataGridView();
      this.gridCpuColumnName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.gridCpuColumnCpuLoad = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.timerGetState = new System.Windows.Forms.Timer(this.components);
      this.panelDisks = new System.Windows.Forms.Panel();
      this.panelMemory.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.gridMemory)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridCpu)).BeginInit();
      this.SuspendLayout();
      // 
      // panelMemory
      // 
      this.panelMemory.Controls.Add(this.gridMemory);
      this.panelMemory.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.panelMemory.Location = new System.Drawing.Point(0, 410);
      this.panelMemory.Name = "panelMemory";
      this.panelMemory.Size = new System.Drawing.Size(146, 132);
      this.panelMemory.TabIndex = 5;
      // 
      // gridMemory
      // 
      this.gridMemory.AllowUserToAddRows = false;
      this.gridMemory.AllowUserToDeleteRows = false;
      this.gridMemory.AllowUserToResizeRows = false;
      this.gridMemory.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.gridMemory.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gridMemory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
      this.gridMemory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.gridMemory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridMemoryColumnName,
            this.gridMemoryColumnMemory});
      dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.gridMemory.DefaultCellStyle = dataGridViewCellStyle3;
      this.gridMemory.Dock = System.Windows.Forms.DockStyle.Fill;
      this.gridMemory.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.gridMemory.Location = new System.Drawing.Point(0, 0);
      this.gridMemory.MultiSelect = false;
      this.gridMemory.Name = "gridMemory";
      this.gridMemory.ReadOnly = true;
      this.gridMemory.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
      dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gridMemory.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
      this.gridMemory.RowHeadersVisible = false;
      this.gridMemory.ShowEditingIcon = false;
      this.gridMemory.Size = new System.Drawing.Size(146, 132);
      this.gridMemory.TabIndex = 0;
      // 
      // gridMemoryColumnName
      // 
      this.gridMemoryColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.gridMemoryColumnName.DataPropertyName = "Name";
      this.gridMemoryColumnName.FillWeight = 70F;
      this.gridMemoryColumnName.HeaderText = "Name";
      this.gridMemoryColumnName.MinimumWidth = 20;
      this.gridMemoryColumnName.Name = "gridMemoryColumnName";
      this.gridMemoryColumnName.ReadOnly = true;
      // 
      // gridMemoryColumnMemory
      // 
      this.gridMemoryColumnMemory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.gridMemoryColumnMemory.DataPropertyName = "MemoryConsumption";
      dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.gridMemoryColumnMemory.DefaultCellStyle = dataGridViewCellStyle2;
      this.gridMemoryColumnMemory.FillWeight = 30F;
      this.gridMemoryColumnMemory.HeaderText = "MB";
      this.gridMemoryColumnMemory.Name = "gridMemoryColumnMemory";
      this.gridMemoryColumnMemory.ReadOnly = true;
      // 
      // panelChart
      // 
      this.panelChart.Dock = System.Windows.Forms.DockStyle.Top;
      this.panelChart.Location = new System.Drawing.Point(0, 0);
      this.panelChart.Name = "panelChart";
      this.panelChart.Size = new System.Drawing.Size(146, 53);
      this.panelChart.TabIndex = 6;
      this.panelChart.Paint += new System.Windows.Forms.PaintEventHandler(this.panelChart_Paint);
      // 
      // gridCpu
      // 
      this.gridCpu.AllowUserToAddRows = false;
      this.gridCpu.AllowUserToDeleteRows = false;
      this.gridCpu.AllowUserToResizeRows = false;
      this.gridCpu.BorderStyle = System.Windows.Forms.BorderStyle.None;
      this.gridCpu.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None;
      dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
      dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gridCpu.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
      this.gridCpu.ColumnHeadersHeight = 21;
      this.gridCpu.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
      this.gridCpu.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.gridCpuColumnName,
            this.gridCpuColumnCpuLoad});
      dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
      dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 8.25F);
      dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
      dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
      this.gridCpu.DefaultCellStyle = dataGridViewCellStyle7;
      this.gridCpu.Dock = System.Windows.Forms.DockStyle.Bottom;
      this.gridCpu.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
      this.gridCpu.Location = new System.Drawing.Point(0, 278);
      this.gridCpu.MultiSelect = false;
      this.gridCpu.Name = "gridCpu";
      this.gridCpu.ReadOnly = true;
      this.gridCpu.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
      dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
      dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
      dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
      dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
      dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
      dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
      dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
      this.gridCpu.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
      this.gridCpu.RowHeadersVisible = false;
      this.gridCpu.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.gridCpu.ShowEditingIcon = false;
      this.gridCpu.Size = new System.Drawing.Size(146, 132);
      this.gridCpu.TabIndex = 1;
      // 
      // gridCpuColumnName
      // 
      this.gridCpuColumnName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.gridCpuColumnName.DataPropertyName = "Name";
      this.gridCpuColumnName.FillWeight = 80F;
      this.gridCpuColumnName.HeaderText = "Name";
      this.gridCpuColumnName.MinimumWidth = 40;
      this.gridCpuColumnName.Name = "gridCpuColumnName";
      this.gridCpuColumnName.ReadOnly = true;
      this.gridCpuColumnName.ToolTipText = "Process name";
      // 
      // gridCpuColumnCpuLoad
      // 
      this.gridCpuColumnCpuLoad.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.gridCpuColumnCpuLoad.DataPropertyName = "CpuUsageForBind";
      dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
      this.gridCpuColumnCpuLoad.DefaultCellStyle = dataGridViewCellStyle6;
      this.gridCpuColumnCpuLoad.FillWeight = 20F;
      this.gridCpuColumnCpuLoad.HeaderText = "%";
      this.gridCpuColumnCpuLoad.MinimumWidth = 10;
      this.gridCpuColumnCpuLoad.Name = "gridCpuColumnCpuLoad";
      this.gridCpuColumnCpuLoad.ReadOnly = true;
      this.gridCpuColumnCpuLoad.ToolTipText = "CPU usage percentage";
      // 
      // timerGetState
      // 
      this.timerGetState.Interval = 2000;
      this.timerGetState.Tick += new System.EventHandler(this.timerGetState_Tick);
      // 
      // panelDisks
      // 
      this.panelDisks.Dock = System.Windows.Forms.DockStyle.Fill;
      this.panelDisks.Location = new System.Drawing.Point(0, 53);
      this.panelDisks.Name = "panelDisks";
      this.panelDisks.Size = new System.Drawing.Size(146, 225);
      this.panelDisks.TabIndex = 7;
      // 
      // FormMain
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(146, 542);
      this.Controls.Add(this.panelDisks);
      this.Controls.Add(this.gridCpu);
      this.Controls.Add(this.panelChart);
      this.Controls.Add(this.panelMemory);
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "FormMain";
      this.ShowIcon = false;
      this.ShowInTaskbar = false;
      this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
      this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
      this.Text = "Top Process ";
      this.TopMost = true;
      this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
      this.Load += new System.EventHandler(this.FormMain_Load);
      this.panelMemory.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.gridMemory)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.gridCpu)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Panel panelMemory;
    private System.Windows.Forms.DataGridView gridMemory;
    private System.Windows.Forms.Panel panelChart;
    private System.Windows.Forms.DataGridView gridCpu;
    private System.Windows.Forms.Timer timerGetState;
    private System.Windows.Forms.DataGridViewTextBoxColumn gridMemoryColumnName;
    private System.Windows.Forms.DataGridViewTextBoxColumn gridMemoryColumnMemory;
    private System.Windows.Forms.DataGridViewTextBoxColumn gridCpuColumnName;
    private System.Windows.Forms.DataGridViewTextBoxColumn gridCpuColumnCpuLoad;
    private System.Windows.Forms.Panel panelDisks;
  }
}

