namespace PS
{
    partial class FormPSSM18B
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPSSM18B));
            this.efLabel1 = new EF.EFLabel();
            this.efStatusBar1 = new EF.EFStatusBar(this.components);
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.efDevComboBox_htno = new EF.EFDevComboBoxEdit(this.components);
            this.efDevGrid1 = new EF.EFDevGrid();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.efBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBox_htno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // efBtnOk
            // 
            this.efBtnOk.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("efBtnOk.Appearance.Font")));
            this.efBtnOk.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.efBtnOk, "efBtnOk");
            this.efBtnOk.Click += new System.EventHandler(this.efBtnOk_Click);
            // 
            // efBtnCancel
            // 
            this.efBtnCancel.Appearance.Font = ((System.Drawing.Font)(resources.GetObject("efBtnCancel.Appearance.Font")));
            this.efBtnCancel.Appearance.Options.UseFont = true;
            resources.ApplyResources(this.efBtnCancel, "efBtnCancel");
            this.efBtnCancel.Click += new System.EventHandler(this.efBtnCancel_Click);
            // 
            // efLabel1
            // 
            resources.ApplyResources(this.efLabel1, "efLabel1");
            this.efLabel1.Name = "efLabel1";
            // 
            // efStatusBar1
            // 
            resources.ApplyResources(this.efStatusBar1, "efStatusBar1");
            this.efStatusBar1.Name = "efStatusBar1";
            this.efStatusBar1.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
            this.statusBarPanel1});
            this.efStatusBar1.ShowPanels = true;
            // 
            // statusBarPanel1
            // 
            this.statusBarPanel1.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
            resources.ApplyResources(this.statusBarPanel1, "statusBarPanel1");
            // 
            // efDevComboBox_htno
            // 
            resources.ApplyResources(this.efDevComboBox_htno, "efDevComboBox_htno");
            this.efDevComboBox_htno.Name = "efDevComboBox_htno";
            this.efDevComboBox_htno.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("efDevComboBox_htno.Properties.Buttons"))))});
            this.efDevComboBox_htno.SelectedValueChanged += new System.EventHandler(this.efDevComboBox_htno_SelectedValueChanged);
            // 
            // efDevGrid1
            // 
            this.efDevGrid1.IsUseCustomPageBar = true;
            resources.ApplyResources(this.efDevGrid1, "efDevGrid1");
            this.efDevGrid1.MainView = this.gridView1;
            this.efDevGrid1.Name = "efDevGrid1";
            this.efDevGrid1.ShowAddRowButton = true;
            this.efDevGrid1.ShowDeleteRowButton = true;
            this.efDevGrid1.ShowExportButton = false;
            this.efDevGrid1.ShowFilterButton = false;
            this.efDevGrid1.ShowGroupButton = false;
            this.efDevGrid1.ShowPageButton = false;
            this.efDevGrid1.ShowRefreshButton = false;
            this.efDevGrid1.ShowSaveLayoutButton = false;
            this.efDevGrid1.ShowSelectionColumn = true;
            this.efDevGrid1.UseEmbeddedNavigator = true;
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
            // FormPSSM18R
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.efDevGrid1);
            this.Controls.Add(this.efDevComboBox_htno);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.efLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPSSM18R";
            this.Load += new System.EventHandler(this.FormPSSM18R_Load);
            this.Controls.SetChildIndex(this.efLabel1, 0);
            this.Controls.SetChildIndex(this.efStatusBar1, 0);
            this.Controls.SetChildIndex(this.efBtnOk, 0);
            this.Controls.SetChildIndex(this.efBtnCancel, 0);
            this.Controls.SetChildIndex(this.efDevComboBox_htno, 0);
            this.Controls.SetChildIndex(this.efDevGrid1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBox_htno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFLabel efLabel1;
        private EF.EFStatusBar efStatusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private EF.EFDevComboBoxEdit efDevComboBox_htno;
        private EF.EFDevGrid efDevGrid1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}