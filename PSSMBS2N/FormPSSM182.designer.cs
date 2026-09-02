namespace PS
{
    partial class FormPSSM182
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPSSM182));
            this.efPanel1 = new EF.EFPanel(this.components);
            this.elementHost1 = new System.Windows.Forms.Integration.ElementHost();
            this.efDevCalcEdit1 = new EF.EFDevCalcEdit(this.components);
            this.efDevCheckEdit1 = new EF.EFDevCheckEdit(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).BeginInit();
            this.efPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevCalcEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevCheckEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // efPanel1
            // 
            resources.ApplyResources(this.efPanel1, "efPanel1");
            this.efPanel1.Controls.Add(this.elementHost1);
            this.efPanel1.Controls.Add(this.efDevCalcEdit1);
            this.efPanel1.Controls.Add(this.efDevCheckEdit1);
            this.efPanel1.Name = "efPanel1";
            // 
            // elementHost1
            // 
            resources.ApplyResources(this.elementHost1, "elementHost1");
            this.elementHost1.Name = "elementHost1";
            this.elementHost1.Child = null;
            // 
            // efDevCalcEdit1
            // 
            resources.ApplyResources(this.efDevCalcEdit1, "efDevCalcEdit1");
            this.efDevCalcEdit1.Name = "efDevCalcEdit1";
            this.efDevCalcEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("efDevCalcEdit1.Properties.Buttons"))))});
            // 
            // efDevCheckEdit1
            // 
            resources.ApplyResources(this.efDevCheckEdit1, "efDevCheckEdit1");
            this.efDevCheckEdit1.Name = "efDevCheckEdit1";
            this.efDevCheckEdit1.Properties.Caption = resources.GetString("efDevCheckEdit1.Properties.Caption");
            this.efDevCheckEdit1.CheckedChanged += new System.EventHandler(this.efDevCheckEdit1_CheckedChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.querytimer_Tick);
            // 
            // FormPSSM182
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.efPanel1);
            this.EFMsgInfo = "";
            this.Name = "FormPSSM182";
            this.EF_START_FORM_BY_EP += new EF.EFFormMain.EFFormEvent(this.FormPSSM21_EF_START_FORM_BY_EP);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormPSSM182_FormClosing);
            this.Load += new System.EventHandler(this.geUserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.efPanel1)).EndInit();
            this.efPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevCalcEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevCheckEdit1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private EF.EFPanel efPanel1;
        private System.Windows.Forms.Timer timer1;
        private EF.EFDevCheckEdit efDevCheckEdit1;
        private EF.EFDevCalcEdit efDevCalcEdit1;
        private System.Windows.Forms.Integration.ElementHost elementHost1;
    }
}