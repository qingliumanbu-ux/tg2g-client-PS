namespace PS
{
    partial class FormPSSM28Signal
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
            this.efTabControl1 = new EF.EFTabControl(this.components);
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.efButton2 = new EF.EFButton();
            this.efButton1 = new EF.EFButton();
            this.efDevLookUpEdit1 = new EF.EFDevLookUpEdit(this.components);
            this.efLabel6 = new EF.EFLabel();
            this.efLabel7 = new EF.EFLabel();
            this.efLabel5 = new EF.EFLabel();
            this.proc_no_txt = new EF.EFDevTextEdit(this.components);
            this.btn_cancel = new EF.EFButton();
            this.htno_txt = new EF.EFDevTextEdit(this.components);
            this.btn_end = new EF.EFButton();
            this.efLabel4 = new EF.EFLabel();
            this.btn_start = new EF.EFButton();
            this.pono_txt = new EF.EFDevTextEdit(this.components);
            this.efLabel3 = new EF.EFLabel();
            this.state_txt = new EF.EFDevTextEdit(this.components);
            this.end_time = new EF.EFDevDateEdit(this.components);
            this.start_time = new EF.EFDevDateEdit(this.components);
            this.efLabel2 = new EF.EFLabel();
            this.efLabel1 = new EF.EFLabel();
            this.efStatusBar1 = new EF.EFStatusBar(this.components);
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.efTabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.proc_no_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.htno_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_end)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pono_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.state_txt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_time.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_time.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_time.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_time.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            this.SuspendLayout();
            // 
            // efTabControl1
            // 
            this.efTabControl1.Controls.Add(this.tabPage1);
            this.efTabControl1.Location = new System.Drawing.Point(2, 2);
            this.efTabControl1.Name = "efTabControl1";
            this.efTabControl1.SelectedIndex = 0;
            this.efTabControl1.Size = new System.Drawing.Size(336, 261);
            this.efTabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.efButton2);
            this.tabPage1.Controls.Add(this.efButton1);
            this.tabPage1.Controls.Add(this.efDevLookUpEdit1);
            this.tabPage1.Controls.Add(this.efLabel6);
            this.tabPage1.Controls.Add(this.efLabel7);
            this.tabPage1.Controls.Add(this.efLabel5);
            this.tabPage1.Controls.Add(this.proc_no_txt);
            this.tabPage1.Controls.Add(this.btn_cancel);
            this.tabPage1.Controls.Add(this.htno_txt);
            this.tabPage1.Controls.Add(this.btn_end);
            this.tabPage1.Controls.Add(this.efLabel4);
            this.tabPage1.Controls.Add(this.btn_start);
            this.tabPage1.Controls.Add(this.pono_txt);
            this.tabPage1.Controls.Add(this.efLabel3);
            this.tabPage1.Controls.Add(this.state_txt);
            this.tabPage1.Controls.Add(this.end_time);
            this.tabPage1.Controls.Add(this.start_time);
            this.tabPage1.Controls.Add(this.efLabel2);
            this.tabPage1.Controls.Add(this.efLabel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(328, 234);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "信号模拟";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // efButton2
            // 
            this.efButton2.FnNo = 0;
            this.efButton2.Hint = "";
            this.efButton2.Location = new System.Drawing.Point(222, 148);
            this.efButton2.Name = "efButton2";
            this.efButton2.Size = new System.Drawing.Size(52, 23);
            this.efButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton2.TabIndex = 15;
            this.efButton2.Text = "NOW";
            this.efButton2.Click += new System.EventHandler(this.efButton2_Click_1);
            // 
            // efButton1
            // 
            this.efButton1.FnNo = 0;
            this.efButton1.Hint = "";
            this.efButton1.Location = new System.Drawing.Point(222, 114);
            this.efButton1.Name = "efButton1";
            this.efButton1.Size = new System.Drawing.Size(52, 23);
            this.efButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton1.TabIndex = 14;
            this.efButton1.Text = "NOW";
            this.efButton1.Click += new System.EventHandler(this.efButton1_Click_1);
            // 
            // efDevLookUpEdit1
            // 
            this.efDevLookUpEdit1.Location = new System.Drawing.Point(222, 50);
            this.efDevLookUpEdit1.Name = "efDevLookUpEdit1";
            this.efDevLookUpEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.efDevLookUpEdit1.Properties.NullText = "";
            this.efDevLookUpEdit1.Size = new System.Drawing.Size(100, 20);
            this.efDevLookUpEdit1.TabIndex = 13;
            this.efDevLookUpEdit1.EditValueChanged += new System.EventHandler(this.efDevLookUpEdit1_EditValueChanged);
            // 
            // efLabel6
            // 
            this.efLabel6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.efLabel6.Location = new System.Drawing.Point(169, 53);
            this.efLabel6.Name = "efLabel6";
            this.efLabel6.Size = new System.Drawing.Size(48, 14);
            this.efLabel6.TabIndex = 12;
            this.efLabel6.Text = "设备代码";
            // 
            // efLabel7
            // 
            this.efLabel7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.efLabel7.Location = new System.Drawing.Point(29, 85);
            this.efLabel7.Name = "efLabel7";
            this.efLabel7.Size = new System.Drawing.Size(36, 14);
            this.efLabel7.TabIndex = 11;
            this.efLabel7.Text = "处理号";
            // 
            // efLabel5
            // 
            this.efLabel5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.efLabel5.Location = new System.Drawing.Point(181, 20);
            this.efLabel5.Name = "efLabel5";
            this.efLabel5.Size = new System.Drawing.Size(36, 14);
            this.efLabel5.TabIndex = 11;
            this.efLabel5.Text = "熔炼号";
            // 
            // proc_no_txt
            // 
            this.proc_no_txt.Location = new System.Drawing.Point(70, 82);
            this.proc_no_txt.Name = "proc_no_txt";
            this.proc_no_txt.Size = new System.Drawing.Size(93, 20);
            this.proc_no_txt.TabIndex = 10;
            // 
            // btn_cancel
            // 
            this.btn_cancel.FnNo = 0;
            this.btn_cancel.Hint = "";
            this.btn_cancel.Location = new System.Drawing.Point(238, 185);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "退出";
            this.btn_cancel.Click += new System.EventHandler(this.efButton3_Click);
            // 
            // htno_txt
            // 
            this.htno_txt.Enabled = false;
            this.htno_txt.Location = new System.Drawing.Point(222, 17);
            this.htno_txt.Name = "htno_txt";
            this.htno_txt.Size = new System.Drawing.Size(93, 20);
            this.htno_txt.TabIndex = 10;
            // 
            // btn_end
            // 
            this.btn_end.FnNo = 0;
            this.btn_end.Hint = "";
            this.btn_end.Location = new System.Drawing.Point(129, 185);
            this.btn_end.Name = "btn_end";
            this.btn_end.Size = new System.Drawing.Size(75, 23);
            this.btn_end.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_end.TabIndex = 2;
            this.btn_end.Text = "结束";
            this.btn_end.Click += new System.EventHandler(this.efButton2_Click);
            // 
            // efLabel4
            // 
            this.efLabel4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.efLabel4.Location = new System.Drawing.Point(5, 20);
            this.efLabel4.Name = "efLabel4";
            this.efLabel4.Size = new System.Drawing.Size(60, 14);
            this.efLabel4.TabIndex = 9;
            this.efLabel4.Text = "制造命令号";
            // 
            // btn_start
            // 
            this.btn_start.FnNo = 0;
            this.btn_start.Hint = "";
            this.btn_start.Location = new System.Drawing.Point(17, 185);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(75, 23);
            this.btn_start.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.btn_start.TabIndex = 1;
            this.btn_start.Text = "开始";
            this.btn_start.Click += new System.EventHandler(this.efButton1_Click);
            // 
            // pono_txt
            // 
            this.pono_txt.Enabled = false;
            this.pono_txt.Location = new System.Drawing.Point(71, 17);
            this.pono_txt.Name = "pono_txt";
            this.pono_txt.Size = new System.Drawing.Size(93, 20);
            this.pono_txt.TabIndex = 8;
            // 
            // efLabel3
            // 
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.efLabel3.Location = new System.Drawing.Point(17, 53);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(48, 14);
            this.efLabel3.TabIndex = 7;
            this.efLabel3.Text = "计划状态";
            // 
            // state_txt
            // 
            this.state_txt.Enabled = false;
            this.state_txt.Location = new System.Drawing.Point(71, 50);
            this.state_txt.Name = "state_txt";
            this.state_txt.Size = new System.Drawing.Size(92, 20);
            this.state_txt.TabIndex = 6;
            // 
            // end_time
            // 
            this.end_time.EditValue = new System.DateTime(2015, 10, 19, 10, 34, 13, 733);
            this.end_time.Location = new System.Drawing.Point(71, 149);
            this.end_time.Name = "end_time";
            this.end_time.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.end_time.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.end_time.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.end_time.Properties.DisplayFormat.FormatString = "yy-MM-dd HH:mm:ss";
            this.end_time.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.end_time.Properties.EditFormat.FormatString = "yy-MM-dd HH:mm:ss";
            this.end_time.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.end_time.Properties.Mask.EditMask = "yy-MM-dd HH:mm:ss";
            this.end_time.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.end_time.Size = new System.Drawing.Size(133, 20);
            this.end_time.TabIndex = 5;
            // 
            // start_time
            // 
            this.start_time.EditValue = new System.DateTime(2015, 10, 19, 10, 34, 13, 733);
            this.start_time.Location = new System.Drawing.Point(71, 115);
            this.start_time.Name = "start_time";
            this.start_time.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.start_time.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.start_time.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.start_time.Properties.DisplayFormat.FormatString = "yy-MM-dd HH:mm:ss";
            this.start_time.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.start_time.Properties.EditFormat.FormatString = "yy-MM-dd HH:mm:ss";
            this.start_time.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.start_time.Properties.Mask.EditMask = "yy-MM-dd HH:mm:ss";
            this.start_time.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
            this.start_time.Size = new System.Drawing.Size(133, 20);
            this.start_time.TabIndex = 4;
            // 
            // efLabel2
            // 
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.efLabel2.Location = new System.Drawing.Point(17, 152);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(48, 14);
            this.efLabel2.TabIndex = 3;
            this.efLabel2.Text = "结束时刻";
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Horizontal;
            this.efLabel1.Location = new System.Drawing.Point(17, 118);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(48, 14);
            this.efLabel1.TabIndex = 2;
            this.efLabel1.Text = "开始时刻";
            // 
            // efStatusBar1
            // 
            this.efStatusBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.efStatusBar1.Location = new System.Drawing.Point(0, 269);
            this.efStatusBar1.Name = "efStatusBar1";
            this.efStatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.efStatusBar1.ShowPanels = true;
            this.efStatusBar1.Size = new System.Drawing.Size(341, 22);
            this.efStatusBar1.TabIndex = 10;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            this.statusBarPanel1.Name = "statusBarPanel1";
            this.statusBarPanel1.Width = 324;
            // 
            // FormPSSM21O
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 291);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.efTabControl1);
            this.Name = "FormPSSM28Signal";
            this.Text = "其他";
            this.Load += new System.EventHandler(this.FormPSSM28Signal_Load);
            this.efTabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.proc_no_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_cancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.htno_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_end)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btn_start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pono_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.state_txt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_time.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end_time.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_time.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.start_time.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFTabControl efTabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private EF.EFButton btn_start;
        private EF.EFButton btn_end;
        private EF.EFButton btn_cancel;
        private EF.EFLabel efLabel2;
        private EF.EFLabel efLabel1;
        private EF.EFDevDateEdit start_time;
        private EF.EFDevDateEdit end_time;
        private EF.EFLabel efLabel3;
        private EF.EFDevTextEdit state_txt;
        private EF.EFLabel efLabel5;
        private EF.EFDevTextEdit htno_txt;
        private EF.EFLabel efLabel4;
        private EF.EFDevTextEdit pono_txt;
        private EF.EFLabel efLabel6;
        private EF.EFDevLookUpEdit efDevLookUpEdit1;
        private EF.EFStatusBar efStatusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private EF.EFButton efButton2;
        private EF.EFButton efButton1;
        private EF.EFLabel efLabel7;
        private EF.EFDevTextEdit proc_no_txt;
    }
}