namespace PS
{
    partial class FormPSSM35RetDlg
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
            EF.EFLabel efLabel7;
            this.efGroupBox1 = new EF.EFGroupBox();
            this.ef_heat_no = new EF.EFTextBox();
            this.efLabel2 = new EF.EFLabel();
            this.sT_NOEFTextBox = new EF.EFTextBox();
            this.pONOEFTextBox = new EF.EFTextBox();
            this.efTextBox1 = new EF.EFTextBox();
            this.sM_PLAN_NOEFTextBox = new EF.EFTextBox();
            this.efGroupBox2 = new EF.EFGroupBox();
            this.efDevLookUpEdit_dest = new EF.EFDevLookUpEdit();
            this.efLabel8 = new EF.EFLabel();
            this.efDevGrid1 = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.efDevText_remark = new EF.EFDevTextEdit();
            this.efDevSpin_ret_wt = new EF.EFDevSpinEdit();
            this.efLabel5 = new EF.EFLabel();
            this.efDevRadio_return_mode = new EF.EFDevRadioGroup();
            this.efLabel3 = new EF.EFLabel();
            this.efLabel6 = new EF.EFLabel();
            this.efLabel4 = new EF.EFLabel();
            this.efLabel1 = new EF.EFLabel();
            this.efDevGrid_plan = new EF.EFDevGrid();
            this.gridView_plan = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSM_PLAN_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPONO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCC_MACH_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRESTRAND_FLAG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riLookUpEdit_RESTRAND_FLAG = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colSTEEL_START_TIME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colST_NO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSR_ROUTE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCAST_SHOW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.riLookUpEdit_ld_type = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.riDateEdit_CC_REQ_TIME = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.efStatusBar1 = new EF.EFStatusBar();
            this.efButton_quit = new EF.EFButton();
            this.efButton_OK = new EF.EFButton();
            this.efButton_inq = new EF.EFButton();
            sT_NOLabel = new EF.EFLabel();
            pONOLabel = new EF.EFLabel();
            sM_PLAN_NOLabel = new EF.EFLabel();
            efLabel7 = new EF.EFLabel();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).BeginInit();
            this.efGroupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit_dest.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevText_remark.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevSpin_ret_wt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevRadio_return_mode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid_plan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_plan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLookUpEdit_RESTRAND_FLAG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLookUpEdit_ld_type)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit_CC_REQ_TIME)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit_CC_REQ_TIME.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_quit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_OK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_inq)).BeginInit();
            this.SuspendLayout();
            // 
            // sT_NOLabel
            // 
            sT_NOLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            sT_NOLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            sT_NOLabel.Location = new System.Drawing.Point(463, 41);
            sT_NOLabel.Name = "sT_NOLabel";
            sT_NOLabel.Size = new System.Drawing.Size(61, 16);
            sT_NOLabel.TabIndex = 4;
            sT_NOLabel.Text = "出钢记号:";
            // 
            // pONOLabel
            // 
            pONOLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            pONOLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            pONOLabel.Location = new System.Drawing.Point(287, 40);
            pONOLabel.Name = "pONOLabel";
            pONOLabel.Size = new System.Drawing.Size(75, 16);
            pONOLabel.TabIndex = 2;
            pONOLabel.Text = "制造命令号:";
            // 
            // sM_PLAN_NOLabel
            // 
            sM_PLAN_NOLabel.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            sM_PLAN_NOLabel.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            sM_PLAN_NOLabel.Location = new System.Drawing.Point(5, 40);
            sM_PLAN_NOLabel.Name = "sM_PLAN_NOLabel";
            sM_PLAN_NOLabel.Size = new System.Drawing.Size(75, 16);
            sM_PLAN_NOLabel.TabIndex = 0;
            sM_PLAN_NOLabel.Text = "炼钢计划号:";
            // 
            // efLabel7
            // 
            efLabel7.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            efLabel7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            efLabel7.Location = new System.Drawing.Point(151, 40);
            efLabel7.Name = "efLabel7";
            efLabel7.Size = new System.Drawing.Size(50, 16);
            efLabel7.TabIndex = 12;
            efLabel7.Text = "熔炼号:";
            // 
            // efGroupBox1
            // 
            this.efGroupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.ConfigurationName = null;
            this.efGroupBox1.Controls.Add(efLabel7);
            this.efGroupBox1.Controls.Add(this.ef_heat_no);
            this.efGroupBox1.Controls.Add(sT_NOLabel);
            this.efGroupBox1.Controls.Add(this.efLabel2);
            this.efGroupBox1.Controls.Add(this.sT_NOEFTextBox);
            this.efGroupBox1.Controls.Add(pONOLabel);
            this.efGroupBox1.Controls.Add(this.pONOEFTextBox);
            this.efGroupBox1.Controls.Add(sM_PLAN_NOLabel);
            this.efGroupBox1.Controls.Add(this.efTextBox1);
            this.efGroupBox1.Controls.Add(this.sM_PLAN_NOEFTextBox);
            this.efGroupBox1.Location = new System.Drawing.Point(1, 2);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.ShowControlValueSchemaButton = false;
            this.efGroupBox1.Size = new System.Drawing.Size(733, 74);
            this.efGroupBox1.TabIndex = 11;
            this.efGroupBox1.Text = "返送炉次信息";
            // 
            // ef_heat_no
            // 
            this.ef_heat_no.EFEname = null;
            this.ef_heat_no.EFLeaveExpression = ".*";
            this.ef_heat_no.EFLen = 32767;
            this.ef_heat_no.Location = new System.Drawing.Point(207, 37);
            this.ef_heat_no.Name = "ef_heat_no";
            this.ef_heat_no.ReadOnly = true;
            this.ef_heat_no.Size = new System.Drawing.Size(78, 22);
            this.ef_heat_no.TabIndex = 13;
            // 
            // efLabel2
            // 
            this.efLabel2.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel2.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel2.Location = new System.Drawing.Point(622, 40);
            this.efLabel2.Name = "efLabel2";
            this.efLabel2.Size = new System.Drawing.Size(46, 15);
            this.efLabel2.TabIndex = 11;
            this.efLabel2.Text = "钢包号:";
            // 
            // sT_NOEFTextBox
            // 
            this.sT_NOEFTextBox.EFEname = null;
            this.sT_NOEFTextBox.EFLeaveExpression = ".*";
            this.sT_NOEFTextBox.EFLen = 32767;
            this.sT_NOEFTextBox.Location = new System.Drawing.Point(531, 38);
            this.sT_NOEFTextBox.Name = "sT_NOEFTextBox";
            this.sT_NOEFTextBox.ReadOnly = true;
            this.sT_NOEFTextBox.Size = new System.Drawing.Size(86, 22);
            this.sT_NOEFTextBox.TabIndex = 5;
            // 
            // pONOEFTextBox
            // 
            this.pONOEFTextBox.EFEname = null;
            this.pONOEFTextBox.EFLeaveExpression = ".*";
            this.pONOEFTextBox.EFLen = 32767;
            this.pONOEFTextBox.Location = new System.Drawing.Point(369, 37);
            this.pONOEFTextBox.Name = "pONOEFTextBox";
            this.pONOEFTextBox.ReadOnly = true;
            this.pONOEFTextBox.Size = new System.Drawing.Size(91, 22);
            this.pONOEFTextBox.TabIndex = 3;
            // 
            // efTextBox1
            // 
            this.efTextBox1.EFEname = null;
            this.efTextBox1.EFLeaveExpression = ".*";
            this.efTextBox1.EFLen = 32767;
            this.efTextBox1.Location = new System.Drawing.Point(674, 37);
            this.efTextBox1.Name = "efTextBox1";
            this.efTextBox1.ReadOnly = true;
            this.efTextBox1.Size = new System.Drawing.Size(51, 22);
            this.efTextBox1.TabIndex = 1;
            // 
            // sM_PLAN_NOEFTextBox
            // 
            this.sM_PLAN_NOEFTextBox.EFEname = null;
            this.sM_PLAN_NOEFTextBox.EFLeaveExpression = ".*";
            this.sM_PLAN_NOEFTextBox.EFLen = 32767;
            this.sM_PLAN_NOEFTextBox.Location = new System.Drawing.Point(86, 37);
            this.sM_PLAN_NOEFTextBox.Name = "sM_PLAN_NOEFTextBox";
            this.sM_PLAN_NOEFTextBox.ReadOnly = true;
            this.sM_PLAN_NOEFTextBox.Size = new System.Drawing.Size(58, 22);
            this.sM_PLAN_NOEFTextBox.TabIndex = 1;
            // 
            // efGroupBox2
            // 
            this.efGroupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.efGroupBox2.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox2.Appearance.Options.UseBackColor = true;
            this.efGroupBox2.ConfigurationName = null;
            this.efGroupBox2.Controls.Add(this.efDevLookUpEdit_dest);
            this.efGroupBox2.Controls.Add(this.efLabel8);
            this.efGroupBox2.Controls.Add(this.efDevGrid1);
            this.efGroupBox2.Controls.Add(this.efDevText_remark);
            this.efGroupBox2.Controls.Add(this.efDevSpin_ret_wt);
            this.efGroupBox2.Controls.Add(this.efLabel5);
            this.efGroupBox2.Controls.Add(this.efDevRadio_return_mode);
            this.efGroupBox2.Controls.Add(this.efLabel3);
            this.efGroupBox2.Controls.Add(this.efLabel6);
            this.efGroupBox2.Controls.Add(this.efLabel4);
            this.efGroupBox2.Controls.Add(this.efLabel1);
            this.efGroupBox2.Controls.Add(this.efDevGrid_plan);
            this.efGroupBox2.Location = new System.Drawing.Point(1, 82);
            this.efGroupBox2.Name = "efGroupBox2";
            this.efGroupBox2.ShowControlValueSchemaButton = false;
            this.efGroupBox2.Size = new System.Drawing.Size(733, 270);
            this.efGroupBox2.TabIndex = 13;
            this.efGroupBox2.Text = "返送内容";
            // 
            // efDevLookUpEdit_dest
            // 
            this.efDevLookUpEdit_dest.EditValue = "";
            this.efDevLookUpEdit_dest.Location = new System.Drawing.Point(598, 32);
            this.efDevLookUpEdit_dest.Name = "efDevLookUpEdit_dest";
            this.efDevLookUpEdit_dest.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.efDevLookUpEdit_dest.Properties.NullText = " ";
            this.efDevLookUpEdit_dest.Size = new System.Drawing.Size(100, 20);
            this.efDevLookUpEdit_dest.TabIndex = 18;
            // 
            // efLabel8
            // 
            this.efLabel8.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel8.Location = new System.Drawing.Point(505, 34);
            this.efLabel8.Name = "efLabel8";
            this.efLabel8.Size = new System.Drawing.Size(87, 16);
            this.efLabel8.TabIndex = 17;
            this.efLabel8.Text = "返送目的地:";
            // 
            // efDevGrid1
            // 
            this.efDevGrid1.Location = new System.Drawing.Point(0, 91);
            this.efDevGrid1.MainView = this.gridView1;
            this.efDevGrid1.Name = "efDevGrid1";
            this.efDevGrid1.Size = new System.Drawing.Size(722, 179);
            this.efDevGrid1.TabIndex = 16;
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
            // efDevText_remark
            // 
            this.efDevText_remark.Location = new System.Drawing.Point(376, 58);
            this.efDevText_remark.Name = "efDevText_remark";
            this.efDevText_remark.Size = new System.Drawing.Size(332, 20);
            this.efDevText_remark.TabIndex = 15;
            // 
            // efDevSpin_ret_wt
            // 
            this.efDevSpin_ret_wt.EditValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.efDevSpin_ret_wt.Location = new System.Drawing.Point(376, 32);
            this.efDevSpin_ret_wt.Name = "efDevSpin_ret_wt";
            this.efDevSpin_ret_wt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.efDevSpin_ret_wt.Size = new System.Drawing.Size(77, 20);
            this.efDevSpin_ret_wt.TabIndex = 14;
            // 
            // efLabel5
            // 
            this.efLabel5.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel5.Location = new System.Drawing.Point(313, 61);
            this.efLabel5.Name = "efLabel5";
            this.efLabel5.Size = new System.Drawing.Size(57, 15);
            this.efLabel5.TabIndex = 11;
            this.efLabel5.Text = "备注:";
            // 
            // efDevRadio_return_mode
            // 
            this.efDevRadio_return_mode.EditValue = "1";
            this.efDevRadio_return_mode.Location = new System.Drawing.Point(118, 26);
            this.efDevRadio_return_mode.Name = "efDevRadio_return_mode";
            this.efDevRadio_return_mode.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.efDevRadio_return_mode.Properties.Appearance.Options.UseBackColor = true;
            this.efDevRadio_return_mode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.efDevRadio_return_mode.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("1", "回炉"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("2", "兑包/折包"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("3", "分割")});
            this.efDevRadio_return_mode.Size = new System.Drawing.Size(133, 59);
            this.efDevRadio_return_mode.TabIndex = 13;
            this.efDevRadio_return_mode.SelectedIndexChanged += new System.EventHandler(this.efButton_inq_Click);
            // 
            // efLabel3
            // 
            this.efLabel3.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel3.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel3.Location = new System.Drawing.Point(283, 34);
            this.efLabel3.Name = "efLabel3";
            this.efLabel3.Size = new System.Drawing.Size(87, 16);
            this.efLabel3.TabIndex = 11;
            this.efLabel3.Text = "返送钢水量:";
            // 
            // efLabel6
            // 
            this.efLabel6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel6.Location = new System.Drawing.Point(459, 34);
            this.efLabel6.Name = "efLabel6";
            this.efLabel6.Size = new System.Drawing.Size(87, 16);
            this.efLabel6.TabIndex = 11;
            this.efLabel6.Text = "(吨)";
            // 
            // efLabel4
            // 
            this.efLabel4.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel4.Location = new System.Drawing.Point(15, 70);
            this.efLabel4.Name = "efLabel4";
            this.efLabel4.Size = new System.Drawing.Size(87, 16);
            this.efLabel4.TabIndex = 11;
            this.efLabel4.Text = "目的炉次";
            // 
            // efLabel1
            // 
            this.efLabel1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efLabel1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efLabel1.Location = new System.Drawing.Point(11, 30);
            this.efLabel1.Name = "efLabel1";
            this.efLabel1.Size = new System.Drawing.Size(101, 24);
            this.efLabel1.TabIndex = 11;
            this.efLabel1.Text = "钢水返送方式:";
            // 
            // efDevGrid_plan
            // 
            this.efDevGrid_plan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.efDevGrid_plan.EFMultiSelect = false;
            this.efDevGrid_plan.Location = new System.Drawing.Point(0, 215);
            this.efDevGrid_plan.MainView = this.gridView_plan;
            this.efDevGrid_plan.Name = "efDevGrid_plan";
            this.efDevGrid_plan.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riLookUpEdit_ld_type,
            this.riLookUpEdit_RESTRAND_FLAG,
            this.riDateEdit_CC_REQ_TIME});
            this.efDevGrid_plan.ShowSelectionColumn = true;
            this.efDevGrid_plan.Size = new System.Drawing.Size(97, 50);
            this.efDevGrid_plan.TabIndex = 9;
            this.efDevGrid_plan.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView_plan});
            this.efDevGrid_plan.Visible = false;
            // 
            // gridView_plan
            // 
            this.gridView_plan.Appearance.HeaderPanel.Options.UseTextOptions = true;
            this.gridView_plan.Appearance.HeaderPanel.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_plan.Appearance.Row.Options.UseTextOptions = true;
            this.gridView_plan.Appearance.Row.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.gridView_plan.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSM_PLAN_NO,
            this.colPONO,
            this.colCC_MACH_NO,
            this.colRESTRAND_FLAG,
            this.colSTEEL_START_TIME,
            this.colST_NO,
            this.colSR_ROUTE,
            this.colCAST_SHOW,
            this.gridColumn1});
            this.gridView_plan.FixedLineWidth = 1;
            this.gridView_plan.GridControl = this.efDevGrid_plan;
            this.gridView_plan.IndicatorWidth = 31;
            this.gridView_plan.Name = "gridView_plan";
            this.gridView_plan.OptionsCustomization.AllowFilter = false;
            this.gridView_plan.OptionsCustomization.AllowGroup = false;
            this.gridView_plan.OptionsCustomization.AllowQuickHideColumns = false;
            this.gridView_plan.OptionsCustomization.AllowSort = false;
            this.gridView_plan.OptionsEditForm.ShowOnDoubleClick = DevExpress.Utils.DefaultBoolean.True;
            this.gridView_plan.OptionsSelection.MultiSelect = true;
            this.gridView_plan.OptionsView.ColumnAutoWidth = false;
            this.gridView_plan.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView_plan.OptionsView.EnableAppearanceOddRow = true;
            this.gridView_plan.OptionsView.ShowGroupPanel = false;
            // 
            // colSM_PLAN_NO
            // 
            this.colSM_PLAN_NO.Caption = "计划号";
            this.colSM_PLAN_NO.FieldName = "SM_PLAN_NO";
            this.colSM_PLAN_NO.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colSM_PLAN_NO.Name = "colSM_PLAN_NO";
            this.colSM_PLAN_NO.Visible = true;
            this.colSM_PLAN_NO.VisibleIndex = 0;
            // 
            // colPONO
            // 
            this.colPONO.Caption = "制造命令";
            this.colPONO.FieldName = "PONO";
            this.colPONO.Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            this.colPONO.Name = "colPONO";
            this.colPONO.OptionsColumn.ReadOnly = true;
            this.colPONO.Visible = true;
            this.colPONO.VisibleIndex = 1;
            // 
            // colCC_MACH_NO
            // 
            this.colCC_MACH_NO.Caption = "连铸机";
            this.colCC_MACH_NO.FieldName = "CC_MACH_NO";
            this.colCC_MACH_NO.Name = "colCC_MACH_NO";
            this.colCC_MACH_NO.Visible = true;
            this.colCC_MACH_NO.VisibleIndex = 6;
            this.colCC_MACH_NO.Width = 64;
            // 
            // colRESTRAND_FLAG
            // 
            this.colRESTRAND_FLAG.ColumnEdit = this.riLookUpEdit_RESTRAND_FLAG;
            this.colRESTRAND_FLAG.FieldName = "RESTRAND_FLAG";
            this.colRESTRAND_FLAG.Name = "colRESTRAND_FLAG";
            this.colRESTRAND_FLAG.Width = 44;
            // 
            // riLookUpEdit_RESTRAND_FLAG
            // 
            this.riLookUpEdit_RESTRAND_FLAG.AutoHeight = false;
            this.riLookUpEdit_RESTRAND_FLAG.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riLookUpEdit_RESTRAND_FLAG.DisplayMember = "RESTRAND_FLAG";
            this.riLookUpEdit_RESTRAND_FLAG.Name = "riLookUpEdit_RESTRAND_FLAG";
            this.riLookUpEdit_RESTRAND_FLAG.ValueMember = "RESTRAND_FLAG";
            // 
            // colSTEEL_START_TIME
            // 
            this.colSTEEL_START_TIME.Caption = "开始时刻";
            this.colSTEEL_START_TIME.DisplayFormat.FormatString = "HH:mm";
            this.colSTEEL_START_TIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colSTEEL_START_TIME.FieldName = "STEEL_START_TIME";
            this.colSTEEL_START_TIME.Name = "colSTEEL_START_TIME";
            this.colSTEEL_START_TIME.Visible = true;
            this.colSTEEL_START_TIME.VisibleIndex = 3;
            // 
            // colST_NO
            // 
            this.colST_NO.Caption = "出钢记号";
            this.colST_NO.FieldName = "ST_NO";
            this.colST_NO.Name = "colST_NO";
            this.colST_NO.OptionsColumn.ReadOnly = true;
            this.colST_NO.Visible = true;
            this.colST_NO.VisibleIndex = 4;
            // 
            // colSR_ROUTE
            // 
            this.colSR_ROUTE.Caption = "精炼路径";
            this.colSR_ROUTE.FieldName = "SR_ROUTE";
            this.colSR_ROUTE.Name = "colSR_ROUTE";
            this.colSR_ROUTE.Visible = true;
            this.colSR_ROUTE.VisibleIndex = 5;
            // 
            // colCAST_SHOW
            // 
            this.colCAST_SHOW.Caption = "浇次号";
            this.colCAST_SHOW.FieldName = "CAST_SHOW";
            this.colCAST_SHOW.Name = "colCAST_SHOW";
            this.colCAST_SHOW.Visible = true;
            this.colCAST_SHOW.VisibleIndex = 2;
            this.colCAST_SHOW.Width = 95;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "返送量";
            this.gridColumn1.FieldName = "RETURN_MLSL";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 7;
            // 
            // riLookUpEdit_ld_type
            // 
            this.riLookUpEdit_ld_type.AutoHeight = false;
            this.riLookUpEdit_ld_type.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riLookUpEdit_ld_type.DisplayMember = "LD_TYPE_DESC";
            this.riLookUpEdit_ld_type.Name = "riLookUpEdit_ld_type";
            this.riLookUpEdit_ld_type.ValueMember = "LD_TYPE";
            // 
            // riDateEdit_CC_REQ_TIME
            // 
            this.riDateEdit_CC_REQ_TIME.AutoHeight = false;
            this.riDateEdit_CC_REQ_TIME.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riDateEdit_CC_REQ_TIME.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.riDateEdit_CC_REQ_TIME.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.riDateEdit_CC_REQ_TIME.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.riDateEdit_CC_REQ_TIME.EditFormat.FormatString = "yyyy-MM-dd HH:mm";
            this.riDateEdit_CC_REQ_TIME.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.riDateEdit_CC_REQ_TIME.Mask.EditMask = "yyyy-MM-dd HH:mm";
            this.riDateEdit_CC_REQ_TIME.Name = "riDateEdit_CC_REQ_TIME";
            // 
            // efStatusBar1
            // 
            this.efStatusBar1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.efStatusBar1.Location = new System.Drawing.Point(0, 411);
            this.efStatusBar1.Name = "efStatusBar1";
            this.efStatusBar1.Size = new System.Drawing.Size(735, 26);
            this.efStatusBar1.TabIndex = 14;
            this.efStatusBar1.Text = "提示信息：";
            // 
            // efButton_quit
            // 
            this.efButton_quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_quit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_quit.Appearance.Options.UseFont = true;
            this.efButton_quit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.efButton_quit.FnNo = 0;
            this.efButton_quit.Hint = "";
            this.efButton_quit.Location = new System.Drawing.Point(623, 368);
            this.efButton_quit.Name = "efButton_quit";
            this.efButton_quit.Size = new System.Drawing.Size(86, 27);
            this.efButton_quit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_quit.TabIndex = 16;
            this.efButton_quit.Text = "取消(&C)";
            // 
            // efButton_OK
            // 
            this.efButton_OK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_OK.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_OK.Appearance.Options.UseFont = true;
            this.efButton_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.efButton_OK.FnNo = 0;
            this.efButton_OK.Hint = "";
            this.efButton_OK.Location = new System.Drawing.Point(506, 368);
            this.efButton_OK.Name = "efButton_OK";
            this.efButton_OK.Size = new System.Drawing.Size(86, 27);
            this.efButton_OK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_OK.TabIndex = 15;
            this.efButton_OK.Text = "确定(&O)";
            this.efButton_OK.Click += new System.EventHandler(this.efButton_OK_Click);
            // 
            // efButton_inq
            // 
            this.efButton_inq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_inq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_inq.Appearance.Options.UseFont = true;
            this.efButton_inq.FnNo = 0;
            this.efButton_inq.Hint = "";
            this.efButton_inq.Location = new System.Drawing.Point(302, 368);
            this.efButton_inq.Name = "efButton_inq";
            this.efButton_inq.Size = new System.Drawing.Size(86, 27);
            this.efButton_inq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_inq.TabIndex = 17;
            this.efButton_inq.Text = "查询(&I)";
            this.efButton_inq.Click += new System.EventHandler(this.efButton_inq_Click);
            // 
            // FormPSSM35RetDlg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(735, 437);
            this.Controls.Add(this.efButton_inq);
            this.Controls.Add(this.efButton_quit);
            this.Controls.Add(this.efButton_OK);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.efGroupBox2);
            this.Controls.Add(this.efGroupBox1);
            this.Name = "FormPSSM35RetDlg";
            this.Text = "FormPSSM35RetDlg-炉次返送";
            this.Load += new System.EventHandler(this.FormPSSM35RetDlg_Load);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            this.efGroupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox2)).EndInit();
            this.efGroupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit_dest.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevText_remark.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevSpin_ret_wt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevRadio_return_mode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid_plan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView_plan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLookUpEdit_RESTRAND_FLAG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riLookUpEdit_ld_type)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit_CC_REQ_TIME.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDateEdit_CC_REQ_TIME)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_quit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_OK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_inq)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFGroupBox efGroupBox1;
        private EF.EFLabel efLabel2;
        private EF.EFTextBox sT_NOEFTextBox;
        private EF.EFTextBox pONOEFTextBox;
        private EF.EFTextBox efTextBox1;
        private EF.EFTextBox sM_PLAN_NOEFTextBox;
        private EF.EFGroupBox efGroupBox2;
        private EF.EFDevGrid efDevGrid_plan;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView_plan;
        private DevExpress.XtraGrid.Columns.GridColumn colPONO;
        private DevExpress.XtraGrid.Columns.GridColumn colRESTRAND_FLAG;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpEdit_RESTRAND_FLAG;
        private DevExpress.XtraGrid.Columns.GridColumn colST_NO;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit riDateEdit_CC_REQ_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colCAST_SHOW;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit riLookUpEdit_ld_type;
        private EF.EFDevRadioGroup efDevRadio_return_mode;
        private EF.EFLabel efLabel3;
        private EF.EFLabel efLabel4;
        private EF.EFLabel efLabel1;
        private EF.EFStatusBar efStatusBar1;
        private EF.EFDevSpinEdit efDevSpin_ret_wt;
        private EF.EFButton efButton_quit;
        private EF.EFButton efButton_OK;
        private EF.EFButton efButton_inq;
        //private DS_PSSM35 dS_PSSM35;
        private DevExpress.XtraGrid.Columns.GridColumn colSM_PLAN_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colCC_MACH_NO;
        private DevExpress.XtraGrid.Columns.GridColumn colSTEEL_START_TIME;
        private DevExpress.XtraGrid.Columns.GridColumn colSR_ROUTE;
        private EF.EFLabel efLabel5;
        private EF.EFDevTextEdit efDevText_remark;
        private EF.EFLabel efLabel6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private EF.EFDevGrid efDevGrid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private EF.EFTextBox ef_heat_no;
        private EF.EFLabel efLabel8;
        private EF.EFDevLookUpEdit efDevLookUpEdit_dest;
    }
}