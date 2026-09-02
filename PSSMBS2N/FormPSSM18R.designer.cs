namespace PS
{
    partial class FormPSSM18R
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPSSM18R));
            this.efLabel1 = new EF.EFLabel();
            this.efLabel2 = new EF.EFLabel();
            this.efLabel3 = new EF.EFLabel();
            this.efLabel4 = new EF.EFLabel();
            this.efDevDateEdit1 = new EF.EFDevDateEdit(this.components);
            this.efStatusBar1 = new EF.EFStatusBar(this.components);
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.efDevSpinEdit1 = new EF.EFDevSpinEdit(this.components);
            this.efDevLookUpEdit_pos = new EF.EFDevLookUpEdit(this.components);
            this.efDevComboBox_htno = new EF.EFDevComboBoxEdit(this.components);
            this.efLabel5 = new EF.EFLabel();
            this.efDevTextEdit1 = new EF.EFDevTextEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevDateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevDateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevSpinEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit_pos.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBox_htno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit1.Properties)).BeginInit();
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
            // efLabel2
            // 
            resources.ApplyResources(this.efLabel2, "efLabel2");
            this.efLabel2.Name = "efLabel2";
            // 
            // efLabel3
            // 
            resources.ApplyResources(this.efLabel3, "efLabel3");
            this.efLabel3.Name = "efLabel3";
            // 
            // efLabel4
            // 
            resources.ApplyResources(this.efLabel4, "efLabel4");
            this.efLabel4.Name = "efLabel4";
            // 
            // efDevDateEdit1
            // 
            resources.ApplyResources(this.efDevDateEdit1, "efDevDateEdit1");
            this.efDevDateEdit1.Name = "efDevDateEdit1";
            this.efDevDateEdit1.Properties.CalendarTimeEditing = DevExpress.Utils.DefaultBoolean.True;
            this.efDevDateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.efDevDateEdit1.Properties.CalendarView = DevExpress.XtraEditors.Repository.CalendarView.Vista;
            this.efDevDateEdit1.Properties.DisplayFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.efDevDateEdit1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.efDevDateEdit1.Properties.EditFormat.FormatString = "yyyy-MM-dd HH:mm:ss";
            this.efDevDateEdit1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.efDevDateEdit1.Properties.Mask.EditMask = resources.GetString("efDevDateEdit1.Properties.Mask.EditMask");
            this.efDevDateEdit1.Properties.VistaDisplayMode = DevExpress.Utils.DefaultBoolean.True;
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
            // efDevSpinEdit1
            // 
            resources.ApplyResources(this.efDevSpinEdit1, "efDevSpinEdit1");
            this.efDevSpinEdit1.Name = "efDevSpinEdit1";
            this.efDevSpinEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            // 
            // efDevLookUpEdit_pos
            // 
            resources.ApplyResources(this.efDevLookUpEdit_pos, "efDevLookUpEdit_pos");
            this.efDevLookUpEdit_pos.Name = "efDevLookUpEdit_pos";
            this.efDevLookUpEdit_pos.Properties.NullText = resources.GetString("efDevLookUpEdit_pos.Properties.NullText");
            // 
            // efDevComboBox_htno
            // 
            resources.ApplyResources(this.efDevComboBox_htno, "efDevComboBox_htno");
            this.efDevComboBox_htno.Name = "efDevComboBox_htno";
            // 
            // efLabel5
            // 
            resources.ApplyResources(this.efLabel5, "efLabel5");
            this.efLabel5.Name = "efLabel5";
            // 
            // efDevTextEdit1
            // 
            resources.ApplyResources(this.efDevTextEdit1, "efDevTextEdit1");
            this.efDevTextEdit1.Name = "efDevTextEdit1";
            // 
            // FormPSSM18R
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.efDevTextEdit1);
            this.Controls.Add(this.efLabel5);
            this.Controls.Add(this.efDevComboBox_htno);
            this.Controls.Add(this.efDevLookUpEdit_pos);
            this.Controls.Add(this.efDevSpinEdit1);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.efDevDateEdit1);
            this.Controls.Add(this.efLabel4);
            this.Controls.Add(this.efLabel3);
            this.Controls.Add(this.efLabel2);
            this.Controls.Add(this.efLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPSSM18R";
            this.Load += new System.EventHandler(this.FormPSSM21R_Load);
            this.Controls.SetChildIndex(this.efLabel1, 0);
            this.Controls.SetChildIndex(this.efLabel2, 0);
            this.Controls.SetChildIndex(this.efLabel3, 0);
            this.Controls.SetChildIndex(this.efLabel4, 0);
            this.Controls.SetChildIndex(this.efDevDateEdit1, 0);
            this.Controls.SetChildIndex(this.efStatusBar1, 0);
            this.Controls.SetChildIndex(this.efDevSpinEdit1, 0);
            this.Controls.SetChildIndex(this.efBtnOk, 0);
            this.Controls.SetChildIndex(this.efDevLookUpEdit_pos, 0);
            this.Controls.SetChildIndex(this.efBtnCancel, 0);
            this.Controls.SetChildIndex(this.efDevComboBox_htno, 0);
            this.Controls.SetChildIndex(this.efLabel5, 0);
            this.Controls.SetChildIndex(this.efDevTextEdit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevDateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevDateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevSpinEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit_pos.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBox_htno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFLabel efLabel1;
        private EF.EFLabel efLabel2;
        private EF.EFLabel efLabel3;
        private EF.EFLabel efLabel4;
        private EF.EFDevDateEdit efDevDateEdit1;
        private EF.EFStatusBar efStatusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private EF.EFDevSpinEdit efDevSpinEdit1;
        private EF.EFDevLookUpEdit efDevLookUpEdit_pos;
        private EF.EFDevComboBoxEdit efDevComboBox_htno;
        private EF.EFLabel efLabel5;
        private EF.EFDevTextEdit efDevTextEdit1;
    }
}