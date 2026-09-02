namespace PS
{
    partial class FormPSSM18TPS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPSSM18TPS));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.efStatusBar1 = new EF.EFStatusBar(this.components);
            this.efGroupBox1 = new EF.EFGroupBox(this.components);
            this.efDevRadioGroup1 = new EF.EFDevRadioGroup(this.components);
            this.efButton2 = new EF.EFButton();
            this.efButton1 = new EF.EFButton();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).BeginInit();
            this.efGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.efDevRadioGroup1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            resources.ApplyResources(this.layoutControl1, "layoutControl1");
            this.layoutControl1.Controls.Add(this.efStatusBar1);
            this.layoutControl1.Controls.Add(this.efGroupBox1);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            // 
            // efStatusBar1
            // 
            resources.ApplyResources(this.efStatusBar1, "efStatusBar1");
            this.efStatusBar1.Name = "efStatusBar1";
            // 
            // efGroupBox1
            // 
            resources.ApplyResources(this.efGroupBox1, "efGroupBox1");
            this.efGroupBox1.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.efGroupBox1.Appearance.Options.UseBackColor = true;
            this.efGroupBox1.ConfigurationName = null;
            this.efGroupBox1.Controls.Add(this.efDevRadioGroup1);
            this.efGroupBox1.Controls.Add(this.efButton2);
            this.efGroupBox1.Controls.Add(this.efButton1);
            this.efGroupBox1.Name = "efGroupBox1";
            this.efGroupBox1.ShowControlValueSchemaButton = false;
            // 
            // efDevRadioGroup1
            // 
            resources.ApplyResources(this.efDevRadioGroup1, "efDevRadioGroup1");
            this.efDevRadioGroup1.Name = "efDevRadioGroup1";
            this.efDevRadioGroup1.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.efDevRadioGroup1.Properties.Appearance.Options.UseBackColor = true;
            this.efDevRadioGroup1.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.efDevRadioGroup1.Properties.Columns = 2;
            this.efDevRadioGroup1.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, resources.GetString("efDevRadioGroup1.Properties.Items")),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(null, resources.GetString("efDevRadioGroup1.Properties.Items1"))});
            // 
            // efButton2
            // 
            this.efButton2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efButton2.Appearance.Options.UseFont = true;
            this.efButton2.FnNo = 0;
            this.efButton2.Hint = "";
            resources.ApplyResources(this.efButton2, "efButton2");
            this.efButton2.Name = "efButton2";
            this.efButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton2.Click += new System.EventHandler(this.efButton2_Click);
            // 
            // efButton1
            // 
            this.efButton1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.efButton1.Appearance.Options.UseFont = true;
            this.efButton1.FnNo = 0;
            this.efButton1.Hint = "";
            resources.ApplyResources(this.efButton1, "efButton1");
            this.efButton1.Name = "efButton1";
            this.efButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton1.Click += new System.EventHandler(this.efButton1_Click);
            // 
            // layoutControlGroup1
            // 
            resources.ApplyResources(this.layoutControlGroup1, "layoutControlGroup1");
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem3});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(212, 193);
            this.layoutControlGroup1.Spacing = new DevExpress.XtraLayout.Utils.Padding(0, 0, 0, 0);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.efGroupBox1;
            resources.ApplyResources(this.layoutControlItem1, "layoutControlItem1");
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(192, 149);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextToControlDistance = 0;
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.efStatusBar1;
            resources.ApplyResources(this.layoutControlItem3, "layoutControlItem3");
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 149);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(192, 24);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextToControlDistance = 0;
            this.layoutControlItem3.TextVisible = false;
            // 
            // FormPSSM11TPS
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormPSSM11TPS";
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efGroupBox1)).EndInit();
            this.efGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.efDevRadioGroup1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private EF.EFGroupBox efGroupBox1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private EF.EFStatusBar efStatusBar1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private EF.EFButton efButton2;
        private EF.EFButton efButton1;
        private EF.EFDevRadioGroup efDevRadioGroup1;
    }
}