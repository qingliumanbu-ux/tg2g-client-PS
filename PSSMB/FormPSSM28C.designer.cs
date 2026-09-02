namespace PS
{
    partial class FormPSSM28C
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
            this.efPanel2 = new EF.EFPanel(this.components);
            this.efDevLookUpEdit_CC_MACH_NO_1 = new EF.EFDevLookUpEdit(this.components);
            this.efL_CC_MACH_NO_1 = new EF.EFLabel();
            this.efDevGrid1 = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlGroup_q = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup4 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.efButton_inq = new EF.EFButton();
            this.efButton_add = new EF.EFButton();
            this.efButton_quit = new EF.EFButton();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efPanel2)).BeginInit();
            this.efPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit_CC_MACH_NO_1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup_q)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_inq)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_add)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_quit)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.efPanel2);
            this.layoutControl1.Controls.Add(this.efDevGrid1);
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.OptionsCustomizationForm.DesignTimeCustomizationFormPositionAndSize = new System.Drawing.Rectangle(374, 327, 250, 350);
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(992, 524);
            this.layoutControl1.TabIndex = 4;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // efPanel2
            // 
            this.efPanel2.Controls.Add(this.efDevLookUpEdit_CC_MACH_NO_1);
            this.efPanel2.Controls.Add(this.efL_CC_MACH_NO_1);
            this.efPanel2.Location = new System.Drawing.Point(15, 35);
            this.efPanel2.Name = "efPanel2";
            this.efPanel2.Size = new System.Drawing.Size(962, 39);
            this.efPanel2.TabIndex = 6;
            // 
            // efDevLookUpEdit_CC_MACH_NO_1
            // 
            this.efDevLookUpEdit_CC_MACH_NO_1.Location = new System.Drawing.Point(63, 9);
            this.efDevLookUpEdit_CC_MACH_NO_1.Name = "efDevLookUpEdit_CC_MACH_NO_1";
            this.efDevLookUpEdit_CC_MACH_NO_1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.efDevLookUpEdit_CC_MACH_NO_1.Properties.NullText = "";
            this.efDevLookUpEdit_CC_MACH_NO_1.Size = new System.Drawing.Size(110, 20);
            this.efDevLookUpEdit_CC_MACH_NO_1.TabIndex = 25;
            // 
            // efL_CC_MACH_NO_1
            // 
            this.efL_CC_MACH_NO_1.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.efL_CC_MACH_NO_1.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.efL_CC_MACH_NO_1.Location = new System.Drawing.Point(3, 11);
            this.efL_CC_MACH_NO_1.Name = "efL_CC_MACH_NO_1";
            this.efL_CC_MACH_NO_1.Size = new System.Drawing.Size(54, 14);
            this.efL_CC_MACH_NO_1.TabIndex = 24;
            this.efL_CC_MACH_NO_1.Text = "连铸机号";
            // 
            // efDevGrid1
            // 
            this.efDevGrid1.Location = new System.Drawing.Point(15, 104);
            this.efDevGrid1.MainView = this.gridView1;
            this.efDevGrid1.Name = "efDevGrid1";
            this.efDevGrid1.Size = new System.Drawing.Size(962, 405);
            this.efDevGrid1.TabIndex = 4;
            this.efDevGrid1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.efDevGrid1.DragDrop += new System.Windows.Forms.DragEventHandler(this.efDevGrid1_DragDrop);
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
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.CustomizationFormText = "layoutControlGroup1";
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlGroup_q,
            this.layoutControlGroup4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "Root";
            this.layoutControlGroup1.Size = new System.Drawing.Size(992, 524);
            this.layoutControlGroup1.Text = "Root";
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlGroup_q
            // 
            this.layoutControlGroup_q.CustomizationFormText = "查询条件";
            this.layoutControlGroup_q.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem3});
            this.layoutControlGroup_q.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup_q.Name = "layoutControlGroup_q";
            this.layoutControlGroup_q.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup_q.Size = new System.Drawing.Size(972, 69);
            this.layoutControlGroup_q.Text = "设备信息";
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.efPanel2;
            this.layoutControlItem3.CustomizationFormText = "layoutControlItem3";
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(966, 43);
            this.layoutControlItem3.Text = "layoutControlItem3";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup4
            // 
            this.layoutControlGroup4.CustomizationFormText = "炼钢计划";
            this.layoutControlGroup4.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1});
            this.layoutControlGroup4.Location = new System.Drawing.Point(0, 69);
            this.layoutControlGroup4.Name = "layoutControlGroup4";
            this.layoutControlGroup4.Padding = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup4.Size = new System.Drawing.Size(972, 435);
            this.layoutControlGroup4.Text = "浇次信息";
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.efDevGrid1;
            this.layoutControlItem1.CustomizationFormText = "layoutControlItem1";
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(966, 409);
            this.layoutControlItem1.Text = "layoutControlItem1";
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // efButton_inq
            // 
            this.efButton_inq.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_inq.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_inq.Appearance.Options.UseFont = true;
            this.efButton_inq.FnNo = 0;
            this.efButton_inq.Hint = "";
            this.efButton_inq.Location = new System.Drawing.Point(682, 530);
            this.efButton_inq.Name = "efButton_inq";
            this.efButton_inq.Size = new System.Drawing.Size(86, 27);
            this.efButton_inq.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_inq.TabIndex = 13;
            this.efButton_inq.Text = "查询(&I)";
            this.efButton_inq.Click += new System.EventHandler(this.efButton_inq_Click);
            // 
            // efButton_add
            // 
            this.efButton_add.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_add.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_add.Appearance.Options.UseFont = true;
            this.efButton_add.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.efButton_add.FnNo = 0;
            this.efButton_add.Hint = "";
            this.efButton_add.Location = new System.Drawing.Point(786, 530);
            this.efButton_add.Name = "efButton_add";
            this.efButton_add.Size = new System.Drawing.Size(86, 27);
            this.efButton_add.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_add.TabIndex = 14;
            this.efButton_add.Text = "确认(&C)";
            this.efButton_add.Click += new System.EventHandler(this.efButton_add_Click);
            // 
            // efButton_quit
            // 
            this.efButton_quit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.efButton_quit.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.efButton_quit.Appearance.Options.UseFont = true;
            this.efButton_quit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.efButton_quit.FnNo = 0;
            this.efButton_quit.Hint = "";
            this.efButton_quit.Location = new System.Drawing.Point(892, 530);
            this.efButton_quit.Name = "efButton_quit";
            this.efButton_quit.Size = new System.Drawing.Size(86, 27);
            this.efButton_quit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton_quit.TabIndex = 15;
            this.efButton_quit.Text = "退出(&X)";
            this.efButton_quit.Click += new System.EventHandler(this.efButton_quit_Click);
            // 
            // FormPSSM28C
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(990, 568);
            this.Controls.Add(this.efButton_quit);
            this.Controls.Add(this.efButton_add);
            this.Controls.Add(this.efButton_inq);
            this.Controls.Add(this.layoutControl1);
            this.Name = "FormPSSM28C";
            this.Load += new System.EventHandler(this.FormPSSM28C_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efPanel2)).EndInit();
            this.efPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit_CC_MACH_NO_1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup_q)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_inq)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_add)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton_quit)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private EF.EFDevGrid efDevGrid1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private EF.EFDevGrid efDevGrid2;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup_q;
        private EF.EFPanel efPanel2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private EF.EFDevLookUpEdit efDevLookUpEdit_CC_MACH_NO_1;
        private EF.EFLabel efL_CC_MACH_NO_1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private EF.EFButton efButton_inq;
        private EF.EFButton efButton_add;
        private EF.EFButton efButton_quit;
    }
}