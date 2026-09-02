namespace PS
{
    partial class FormPSSM28SI
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.efDevGrid1 = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.efPanel5 = new EF.EFPanel(this.components);
            this.efLabel1 = new EF.EFLabel();
            this.efRadio_cast = new EF.EFRadioButton(this.components);
            this.efRadio_tps = new EF.EFRadioButton(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup5 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem6 = new DevExpress.XtraLayout.LayoutControlItem();
            this.timer_plan = new System.Windows.Forms.Timer(this.components);
            this.timer_resp = new System.Windows.Forms.Timer(this.components);
            this.timer_proc_no = new System.Windows.Forms.Timer(this.components);
            this.timer_pour = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel5)).BeginInit();
            this.efPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.layoutControl1.Controls.Add(this.efDevGrid1);
            this.layoutControl1.Controls.Add(this.efPanel5);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1119, 655);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // efDevGrid1
            // 
            this.efDevGrid1.Location = new System.Drawing.Point(8, 149);
            this.efDevGrid1.MainView = this.gridView1;
            this.efDevGrid1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.efDevGrid1.Name = "efDevGrid1";
            this.efDevGrid1.ShowContextMenuSaveAs = false;
            this.efDevGrid1.ShowExportButton = false;
            this.efDevGrid1.Size = new System.Drawing.Size(1103, 497);
            this.efDevGrid1.TabIndex = 9;
            this.efDevGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 286;
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.efDevGrid1;
            this.gridView1.IndicatorWidth = 28;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bandedGridViewPlan_MouseDown);
            // 
            // efPanel5
            // 
            this.efPanel5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.efPanel5.Controls.Add(this.efLabel1);
            this.efPanel5.Controls.Add(this.efRadio_cast);
            this.efPanel5.Controls.Add(this.efRadio_tps);
            this.efPanel5.Location = new System.Drawing.Point(5, 103);
            this.efPanel5.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.efPanel5.Name = "efPanel5";
            this.efPanel5.Size = new System.Drawing.Size(1109, 39);
            this.efPanel5.TabIndex = 8;
            // 
            // efLabel1
            // 
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(8, 7);
            this.efLabel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(86, 18);
            this.efLabel1.TabIndex = 10;
            this.efLabel1.Text = "出钢计划信息";
            // 
            // efRadio_cast
            // 
            this.efRadio_cast.AutoSize = true;
            this.efRadio_cast.BackColor = System.Drawing.Color.Transparent;
            this.efRadio_cast.Location = new System.Drawing.Point(587, 5);
            this.efRadio_cast.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.efRadio_cast.Name = "efRadio_cast";
            this.efRadio_cast.Size = new System.Drawing.Size(74, 22);
            this.efRadio_cast.TabIndex = 8;
            this.efRadio_cast.Text = "未确定";
            this.efRadio_cast.UseVisualStyleBackColor = false;
            this.efRadio_cast.CheckedChanged += new System.EventHandler(this.efRadio_cast_CheckedChanged);
            // 
            // efRadio_tps
            // 
            this.efRadio_tps.AutoSize = true;
            this.efRadio_tps.BackColor = System.Drawing.Color.Transparent;
            this.efRadio_tps.Checked = true;
            this.efRadio_tps.Location = new System.Drawing.Point(449, 5);
            this.efRadio_tps.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.efRadio_tps.Name = "efRadio_tps";
            this.efRadio_tps.Size = new System.Drawing.Size(74, 22);
            this.efRadio_tps.TabIndex = 9;
            this.efRadio_tps.TabStop = true;
            this.efRadio_tps.Text = "未浇完";
            this.efRadio_tps.UseVisualStyleBackColor = false;
            this.efRadio_tps.CheckedChanged += new System.EventHandler(this.efRadio_tps_CheckedChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup5,
            this.layoutControlItem5,
            this.layoutControlGroup2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 4, 4);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1119, 655);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup5
            // 
            this.layoutControlGroup5.CustomizationFormText = "layoutControlGroup5";
            this.layoutControlGroup5.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup5.Location = new System.Drawing.Point(0, 140);
            this.layoutControlGroup5.Name = "layoutControlGroup5";
            this.layoutControlGroup5.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup5.Size = new System.Drawing.Size(1113, 507);
            this.layoutControlGroup5.Text = "出钢计划信息";
            this.layoutControlGroup5.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.efDevGrid1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1107, 501);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.efPanel5;
            this.layoutControlItem5.CustomizationFormText = "layoutControlItem5";
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 97);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1113, 43);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "状态信息";
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1113, 97);
            this.layoutControlGroup2.Text = "状态信息";
            // 
            // layoutControlItem6
            // 
            this.layoutControlItem6.CustomizationFormText = "layoutControlItem6";
            this.layoutControlItem6.Location = new System.Drawing.Point(0, 89);
            this.layoutControlItem6.Name = "layoutControlItem6";
            this.layoutControlItem6.Size = new System.Drawing.Size(629, 1);
            this.layoutControlItem6.TextSize = new System.Drawing.Size(50, 20);
            // 
            // timer_plan
            // 
            this.timer_plan.Interval = 30000;
            this.timer_plan.Tag = "计划更新(每30秒)";
            this.timer_plan.Tick += new System.EventHandler(this.timer_plan_Tick);
            // 
            // timer_resp
            // 
            this.timer_resp.Interval = 1000;
            this.timer_resp.Tag = "应答(每6秒更新)";
            // 
            // timer_proc_no
            // 
            this.timer_proc_no.Interval = 26000;
            this.timer_proc_no.Tag = "工序处理号(每30秒更新)";
            // 
            // timer_pour
            // 
            this.timer_pour.Interval = 32000;
            this.timer_pour.Tag = "浇注信息(每分钟更新)";
            // 
            // FormPSSM28SI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1125, 722);
            this.Controls.Add(this.layoutControl1);
            this.Margin = new System.Windows.Forms.Padding(10, 16, 10, 16);
            this.Name = "FormPSSM28SI";
            this.Text = "FormPSSM28SI";
            this.EF_PRE_DO_F5 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_PRE_DO_F5);
            this.EF_PRE_DO_F6 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_PRE_DO_F6);
            this.EF_PRE_DO_F7 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_PRE_DO_F7);
            this.EF_PRE_DO_F8 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_PRE_DO_F8);
            this.EF_PRE_DO_F9 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_PRE_DO_F9);
            this.EF_DO_F2 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F2);
            this.EF_DO_F3 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F3);
            this.EF_DO_F4 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F4);
            this.EF_DO_F5 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F5);
            this.EF_DO_F6 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F6);
            this.EF_DO_F7 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F7);
            this.EF_DO_F8 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F8);
            this.EF_DO_F9 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_F9);
            this.EF_DO_FA += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_FA);
            this.EF_DO_FB += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_FB);
            this.EF_DO_FC += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_DO_FC);
            this.EF_CANCEL_DO_F5 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_CANCEL_DO_F5);
            this.EF_CANCEL_DO_F6 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_CANCEL_DO_F6);
            this.EF_CANCEL_DO_F7 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_CANCEL_DO_F7);
            this.EF_CANCEL_DO_F8 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_CANCEL_DO_F8);
            this.EF_CANCEL_DO_F9 += new EF.EFButtonBar.EFDoFnEventHandler(this.FormPSSM28SI_EF_CANCEL_DO_F9);
            this.EF_START_FORM_BY_EP += new EF.EFFormMain.EFFormEvent(this.FormPSSM28SI_EF_START_FORM_BY_EP);
            this.Load += new System.EventHandler(this.FormPSSM28SI_Load);
            this.Controls.SetChildIndex(this.layoutControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel5)).EndInit();
            this.efPanel5.ResumeLayout(false);
            this.efPanel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem6)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup5;
        private EF.EFPanel efPanel5;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private EF.EFRadioButton efRadio_cast;
        private EF.EFRadioButton efRadio_tps;
        private EF.EFLabel efLabel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem6;
        private System.Windows.Forms.Timer timer_plan;
        private System.Windows.Forms.Timer timer_resp;
        private System.Windows.Forms.Timer timer_proc_no;
        private System.Windows.Forms.Timer timer_pour;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private EF.EFDevGrid efDevGrid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
    }
}