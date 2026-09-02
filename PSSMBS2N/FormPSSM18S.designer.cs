namespace PS
{
    partial class FormPSSM18S
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPSSM18S));
            this.efLabel1 = new EF.EFLabel();
            this.efLabel2 = new EF.EFLabel();
            this.efDevLookUpEdit1 = new EF.EFDevLookUpEdit(this.components);
            this.efDevComboBoxEdit1 = new EF.EFDevComboBoxEdit(this.components);
            this.efStatusBar1 = new EF.EFStatusBar(this.components);
            this.statusBarPanel1 = new System.Windows.Forms.StatusBarPanel();
            this.efLabel3 = new EF.EFLabel();
            this.efDevComboBoxEdit2 = new EF.EFDevComboBoxEdit(this.components);
            this.efLabel4 = new EF.EFLabel();
            this.efDevTextEdit1 = new EF.EFDevTextEdit(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efBtnOk)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efBtnCancel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBoxEdit2.Properties)).BeginInit();
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
            // efDevLookUpEdit1
            // 
            resources.ApplyResources(this.efDevLookUpEdit1, "efDevLookUpEdit1");
            this.efDevLookUpEdit1.Name = "efDevLookUpEdit1";
            this.efDevLookUpEdit1.Properties.NullText = resources.GetString("efDevLookUpEdit1.Properties.NullText");
            // 
            // efDevComboBoxEdit1
            // 
            resources.ApplyResources(this.efDevComboBoxEdit1, "efDevComboBoxEdit1");
            this.efDevComboBoxEdit1.Name = "efDevComboBoxEdit1";
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
            // efLabel3
            // 
            resources.ApplyResources(this.efLabel3, "efLabel3");
            this.efLabel3.Name = "efLabel3";
            // 
            // efDevComboBoxEdit2
            // 
            resources.ApplyResources(this.efDevComboBoxEdit2, "efDevComboBoxEdit2");
            this.efDevComboBoxEdit2.Name = "efDevComboBoxEdit2";
            // 
            // efLabel4
            // 
            resources.ApplyResources(this.efLabel4, "efLabel4");
            this.efLabel4.Name = "efLabel4";
            // 
            // efDevTextEdit1
            // 
            resources.ApplyResources(this.efDevTextEdit1, "efDevTextEdit1");
            this.efDevTextEdit1.Name = "efDevTextEdit1";
            // 
            // FormPSSM18S
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.efDevTextEdit1);
            this.Controls.Add(this.efLabel4);
            this.Controls.Add(this.efDevComboBoxEdit2);
            this.Controls.Add(this.efLabel3);
            this.Controls.Add(this.efStatusBar1);
            this.Controls.Add(this.efDevComboBoxEdit1);
            this.Controls.Add(this.efDevLookUpEdit1);
            this.Controls.Add(this.efLabel2);
            this.Controls.Add(this.efLabel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPSSM18S";
            this.Load += new System.EventHandler(this.FormPSSM21S_Load);
            this.Controls.SetChildIndex(this.efLabel1, 0);
            this.Controls.SetChildIndex(this.efLabel2, 0);
            this.Controls.SetChildIndex(this.efDevLookUpEdit1, 0);
            this.Controls.SetChildIndex(this.efBtnOk, 0);
            this.Controls.SetChildIndex(this.efDevComboBoxEdit1, 0);
            this.Controls.SetChildIndex(this.efBtnCancel, 0);
            this.Controls.SetChildIndex(this.efStatusBar1, 0);
            this.Controls.SetChildIndex(this.efLabel3, 0);
            this.Controls.SetChildIndex(this.efDevComboBoxEdit2, 0);
            this.Controls.SetChildIndex(this.efLabel4, 0);
            this.Controls.SetChildIndex(this.efDevTextEdit1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efBtnOk)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efBtnCancel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevLookUpEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.statusBarPanel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevComboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevTextEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFLabel efLabel1;
        private EF.EFLabel efLabel2;
        private EF.EFDevLookUpEdit efDevLookUpEdit1;
        private EF.EFDevComboBoxEdit efDevComboBoxEdit1;
        private EF.EFStatusBar efStatusBar1;
        private System.Windows.Forms.StatusBarPanel statusBarPanel1;
        private EF.EFLabel efLabel3;
        private EF.EFDevComboBoxEdit efDevComboBoxEdit2;
        private EF.EFLabel efLabel4;
        private EF.EFDevTextEdit efDevTextEdit1;
    }
}