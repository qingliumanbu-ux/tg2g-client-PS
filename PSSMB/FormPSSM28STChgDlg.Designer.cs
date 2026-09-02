namespace PS
{
    partial class FormPSSM28STChgDlg
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
            EF.EFLabel sT_NOLabel;
            EF.EFLabel pONOLabel;
            EF.EFLabel sM_PLAN_NOLabel;
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.efPanel3 = new EF.EFPanel();
            this.efButton_inq = new EF.EFButton();
            this.efButton_quit = new EF.EFButton();
            this.efButton_chg = new EF.EFButton();
            this.efPanel2 = new EF.EFPanel();
            this.efDevGrid1 = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.efPanel1 = new EF.EFPanel();
            this.cHG_CC_MACH_NOEFTDevLookUpEdit = new EF.EFDevLookUpEdit();
            this.efLabel3 = new EF.EFLabel();
            this.efLabel2 = new EF.EFLabel();
            this.sT_NOEFTextBox = new EF.EFTextBox();
            this.pONOEFTextBox = new EF.EFTextBox();
            this.cC_MACH_NOEFTextBox = new EF.EFTextBox();
            this.sM_PLAN_NOEFTextBox = new EF.EFTextBox();
            this.efLabel1 = new EF.EFLabel();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup3 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.splitterItem1 = new DevExpress.XtraLayout.SplitterItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.efStatusBar1 = new EF.EFStatusBar();
            sT_NOLabel = new EF.EFLabel();
            pONOLabel = new EF.EFLabel();
            sM_PLAN_NOLabel = new EF.EFLabel();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel3)).BeginInit();
            this.efPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_inq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_quit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_chg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel2)).BeginInit();
            this.efPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).BeginInit();
            this.efPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // sT_NOLabel
            // 
            sT_NOLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            sT_NOLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            sT_NOLabel.Location = new System.Drawing.Point(467, 13);
            sT_NOLabel.Name = "sT_NOLabel";
            sT_NOLabel.Size = new System.Drawing.Size(61, 16);
            sT_NOLabel.TabIndex = 17;
            sT_NOLabel.Text = "出钢记号:";
            // 
            // pONOLabel
            // 
            pONOLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            pONOLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            pONOLabel.Location = new System.Drawing.Point(243, 13);
            pONOLabel.Name = "pONOLabel";
            pONOLabel.Size = new System.Drawing.Size(75, 16);
            pONOLabel.TabIndex = 15;
            pONOLabel.Text = "制造命令号:";
            // 
            // sM_PLAN_NOLabel
            // 
            sM_PLAN_NOLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            sM_PLAN_NOLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            sM_PLAN_NOLabel.Location = new System.Drawing.Point(23, 13);
            sM_PLAN_NOLabel.Name = "sM_PLAN_NOLabel";
            sM_PLAN_NOLabel.Size = new System.Drawing.Size(75, 16);
            sM_PLAN_NOLabel.TabIndex = 12;
            sM_PLAN_NOLabel.Text = "炼钢计划号:";
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.efPanel3);
            this.layoutControl1.Controls.Add(this.efPanel2);
            this.layoutControl1.Controls.Add(this.efPanel1);
            this.layoutControl1.Controls.Add(this.efLabel1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(528, 295, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(787, 439);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // efPanel3
            // 
            this.efPanel3.Controls.Add(this.efButton_inq);
            this.efPanel3.Controls.Add(this.efButton_quit);
            this.efPanel3.Controls.Add(this.efButton_chg);
            this.efPanel3.Location = new System.Drawing.Point(5, 394);
            this.efPanel3.Name = "efPanel3";
            this.efPanel3.Size = new System.Drawing.Size(777, 40);
            this.efPanel3.TabIndex = 14;
            // 
            // efButton_inq
            // 
            this.efButton_inq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_inq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_inq.Appearance.Options.UseFont = true;
            this.efButton_inq.FnNo = 0;
            this.efButton_inq.Hint = "";
            this.efButton_inq.Location = new System.Drawing.Point(415, 9);
            this.efButton_inq.Name = "efButton_inq";
            this.efButton_inq.Size = new System.Drawing.Size(74, 23);
            this.efButton_inq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_inq.TabIndex = 9;
            this.efButton_inq.Text = "查询(&I)";
            this.efButton_inq.Click += new System.EventHandler(this.efButton_inq_Click);
            // 
            // efButton_quit
            // 
            this.efButton_quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_quit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_quit.Appearance.Options.UseFont = true;
            this.efButton_quit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.efButton_quit.FnNo = 0;
            this.efButton_quit.Hint = "";
            this.efButton_quit.Location = new System.Drawing.Point(682, 9);
            this.efButton_quit.Name = "efButton_quit";
            this.efButton_quit.Size = new System.Drawing.Size(74, 23);
            this.efButton_quit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_quit.TabIndex = 11;
            this.efButton_quit.Text = "退出(&X)";
            this.efButton_quit.Click += new System.EventHandler(this.efButton_quit_Click);
            // 
            // efButton_chg
            // 
            this.efButton_chg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_chg.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_chg.Appearance.Options.UseFont = true;
            this.efButton_chg.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.efButton_chg.FnNo = 0;
            this.efButton_chg.Hint = "";
            this.efButton_chg.Location = new System.Drawing.Point(580, 9);
            this.efButton_chg.Name = "efButton_chg";
            this.efButton_chg.Size = new System.Drawing.Size(74, 23);
            this.efButton_chg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_chg.TabIndex = 10;
            this.efButton_chg.Text = "变更(&C)";
            this.efButton_chg.Click += new System.EventHandler(this.efButton_chg_Click);
            // 
            // efPanel2
            // 
            this.efPanel2.Controls.Add(this.efDevGrid1);
            this.efPanel2.Location = new System.Drawing.Point(8, 131);
            this.efPanel2.Name = "efPanel2";
            this.efPanel2.Size = new System.Drawing.Size(771, 256);
            this.efPanel2.TabIndex = 1;
            // 
            // efDevGrid1
            // 
            this.efDevGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.efDevGrid1.Location = new System.Drawing.Point(0, 0);
            this.efDevGrid1.MainView = this.gridView1;
            this.efDevGrid1.Name = "efDevGrid1";
            this.efDevGrid1.Size = new System.Drawing.Size(771, 256);
            this.efDevGrid1.TabIndex = 0;
            this.efDevGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.FixedLineWidth = 1;
            this.gridView1.GridControl = this.efDevGrid1;
            this.gridView1.IndicatorWidth = 35;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.EnableAppearanceOddRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // efPanel1
            // 
            this.efPanel1.Controls.Add(this.cHG_CC_MACH_NOEFTDevLookUpEdit);
            this.efPanel1.Controls.Add(sT_NOLabel);
            this.efPanel1.Controls.Add(this.efLabel3);
            this.efPanel1.Controls.Add(this.efLabel2);
            this.efPanel1.Controls.Add(this.sT_NOEFTextBox);
            this.efPanel1.Controls.Add(pONOLabel);
            this.efPanel1.Controls.Add(this.pONOEFTextBox);
            this.efPanel1.Controls.Add(sM_PLAN_NOLabel);
            this.efPanel1.Controls.Add(this.cC_MACH_NOEFTextBox);
            this.efPanel1.Controls.Add(this.sM_PLAN_NOEFTextBox);
            this.efPanel1.Location = new System.Drawing.Point(8, 28);
            this.efPanel1.Name = "efPanel1";
            this.efPanel1.Size = new System.Drawing.Size(771, 68);
            this.efPanel1.TabIndex = 0;
            // 
            // cHG_CC_MACH_NOEFTDevLookUpEdit
            // 
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.Location = new System.Drawing.Point(325, 41);
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.Name = "cHG_CC_MACH_NOEFTDevLookUpEdit";
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.DisplayMember = "DEV_DESC";
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.NullText = "";
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties.ValueMember = "DEV_CODE";
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.Size = new System.Drawing.Size(78, 20);
            this.cHG_CC_MACH_NOEFTDevLookUpEdit.TabIndex = 16;
            // 
            // efLabel3
            // 
            this.efLabel3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(231, 43);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(87, 16);
            this.efLabel3.TabIndex = 15;
            this.efLabel3.Text = "交换连铸机:";
            // 
            // efLabel2
            // 
            this.efLabel2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(41, 44);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(57, 15);
            this.efLabel2.TabIndex = 19;
            this.efLabel2.Text = "连铸机:";
            // 
            // sT_NOEFTextBox
            // 
            this.sT_NOEFTextBox.EFEname = null;
            this.sT_NOEFTextBox.EFLeaveExpression = ".*";
            this.sT_NOEFTextBox.EFLen = 32767;
            this.sT_NOEFTextBox.Location = new System.Drawing.Point(535, 10);
            this.sT_NOEFTextBox.Name = "sT_NOEFTextBox";
            this.sT_NOEFTextBox.ReadOnly = true;
            this.sT_NOEFTextBox.Size = new System.Drawing.Size(116, 22);
            this.sT_NOEFTextBox.TabIndex = 18;
            // 
            // pONOEFTextBox
            // 
            this.pONOEFTextBox.EFEname = null;
            this.pONOEFTextBox.EFLeaveExpression = ".*";
            this.pONOEFTextBox.EFLen = 32767;
            this.pONOEFTextBox.Location = new System.Drawing.Point(325, 10);
            this.pONOEFTextBox.Name = "pONOEFTextBox";
            this.pONOEFTextBox.ReadOnly = true;
            this.pONOEFTextBox.Size = new System.Drawing.Size(116, 22);
            this.pONOEFTextBox.TabIndex = 16;
            // 
            // cC_MACH_NOEFTextBox
            // 
            this.cC_MACH_NOEFTextBox.EFEname = null;
            this.cC_MACH_NOEFTextBox.EFLeaveExpression = ".*";
            this.cC_MACH_NOEFTextBox.EFLen = 32767;
            this.cC_MACH_NOEFTextBox.Location = new System.Drawing.Point(104, 41);
            this.cC_MACH_NOEFTextBox.Name = "cC_MACH_NOEFTextBox";
            this.cC_MACH_NOEFTextBox.ReadOnly = true;
            this.cC_MACH_NOEFTextBox.Size = new System.Drawing.Size(78, 22);
            this.cC_MACH_NOEFTextBox.TabIndex = 13;
            // 
            // sM_PLAN_NOEFTextBox
            // 
            this.sM_PLAN_NOEFTextBox.EFEname = null;
            this.sM_PLAN_NOEFTextBox.EFLeaveExpression = ".*";
            this.sM_PLAN_NOEFTextBox.EFLen = 32767;
            this.sM_PLAN_NOEFTextBox.Location = new System.Drawing.Point(104, 10);
            this.sM_PLAN_NOEFTextBox.Name = "sM_PLAN_NOEFTextBox";
            this.sM_PLAN_NOEFTextBox.ReadOnly = true;
            this.sM_PLAN_NOEFTextBox.Size = new System.Drawing.Size(116, 22);
            this.sM_PLAN_NOEFTextBox.TabIndex = 14;
            // 
            // efLabel1
            // 
            this.efLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(8, 365);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(822, 20);
            this.efLabel1.StyleController = this.layoutControl1;
            this.efLabel1.TabIndex = 13;
            this.efLabel1.Text = "连铸机:";
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "Root";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup2,
            this.layoutControlGroup3,
            this.splitterItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(787, 439);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.CustomizationFormText = "当前炉次信息";
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup2.Size = new System.Drawing.Size(781, 98);
            this.layoutControlGroup2.Text = "当前炉次信息";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.efPanel1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(775, 72);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup3
            // 
            this.layoutControlGroup3.CustomizationFormText = "可交换炉次";
            this.layoutControlGroup3.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem2});
            this.layoutControlGroup3.Location = new System.Drawing.Point(0, 103);
            this.layoutControlGroup3.Name = "layoutControlGroup3";
            this.layoutControlGroup3.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup3.Size = new System.Drawing.Size(781, 286);
            this.layoutControlGroup3.Text = "可交换炉次";
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.efPanel2;
            this.layoutControlItem2.CustomizationFormText = "layoutControlItem2";
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(775, 260);
            this.layoutControlItem2.Text = "layoutControlItem2";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextToControlDistance = 0;
            this.layoutControlItem2.TextVisible = false;
            // 
            // splitterItem1
            // 
            this.splitterItem1.AllowHotTrack = true;
            this.splitterItem1.CustomizationFormText = "splitterItem1";
            this.splitterItem1.Location = new System.Drawing.Point(0, 98);
            this.splitterItem1.Name = "splitterItem1";
            this.splitterItem1.Size = new System.Drawing.Size(781, 5);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.efPanel3;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 389);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(781, 44);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // efStatusBar1
            // 
            this.efStatusBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.efStatusBar1.Location = new System.Drawing.Point(0, 436);
            this.efStatusBar1.Name = "efStatusBar1";
            this.efStatusBar1.Size = new System.Drawing.Size(784, 26);
            this.efStatusBar1.TabIndex = 4;
            this.efStatusBar1.Text = "提示信息：";
            // 
            // FormPSSM28STChgDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 462);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormPSSM28STChgDlg";
            this.Text = "FormPSSM28STChgDlg";
            this.Load += new System.EventHandler(this.FormPSSM28STChgDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efPanel3)).EndInit();
            this.efPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efButton_inq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_quit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_chg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel2)).EndInit();
            this.efPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).EndInit();
            this.efPanel1.ResumeLayout(false);
            this.efPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cHG_CC_MACH_NOEFTDevLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitterItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private EF.EFStatusBar efStatusBar1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup3;
        private EF.EFPanel efPanel2;
        private EF.EFPanel efPanel1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private EF.EFLabel efLabel2;
        private EF.EFTextBox sT_NOEFTextBox;
        private EF.EFTextBox pONOEFTextBox;
        private EF.EFTextBox cC_MACH_NOEFTextBox;
        private EF.EFTextBox sM_PLAN_NOEFTextBox;
        private DevExpress.XtraLayout.SplitterItem splitterItem1;
        private EF.EFDevLookUpEdit cHG_CC_MACH_NOEFTDevLookUpEdit;
        private EF.EFLabel efLabel3;
        private EF.EFLabel efLabel1;
        private EF.EFPanel efPanel3;
        private EF.EFButton efButton_inq;
        private EF.EFButton efButton_quit;
        private EF.EFButton efButton_chg;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private EF.EFDevGrid efDevGrid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}