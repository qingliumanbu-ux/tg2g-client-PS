namespace PS
{
    partial class FormPSSM10ADD
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
            this.efDevGrid1 = new EF.EFDevGrid();
            this.efDevGrid2 = new EF.EFDevGrid();
            this.efButton1 = new EF.EFButton();
            this.efButton2 = new EF.EFButton();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).BeginInit();
            this.SuspendLayout();
            // 
            // efDevGrid1
            // 
            this.efDevGrid1.Location = new System.Drawing.Point(0, 1);
            this.efDevGrid1.Name = "efDevGrid1";
            this.efDevGrid1.Size = new System.Drawing.Size(984, 212);
            this.efDevGrid1.TabIndex = 5;
            // 
            // efDevGrid2
            // 
            this.efDevGrid2.Location = new System.Drawing.Point(0, 214);
            this.efDevGrid2.Name = "efDevGrid2";
            this.efDevGrid2.Size = new System.Drawing.Size(984, 257);
            this.efDevGrid2.TabIndex = 6;
            // 
            // efButton1
            // 
            this.efButton1.FnNo = 0;
            this.efButton1.Hint = "";
            this.efButton1.Location = new System.Drawing.Point(120, 478);
            this.efButton1.Name = "efButton1";
            this.efButton1.Size = new System.Drawing.Size(75, 23);
            this.efButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton1.TabIndex = 7;
            this.efButton1.Text = "efButton1";
            // 
            // efButton2
            // 
            this.efButton2.FnNo = 0;
            this.efButton2.Hint = "";
            this.efButton2.Location = new System.Drawing.Point(321, 478);
            this.efButton2.Name = "efButton2";
            this.efButton2.Size = new System.Drawing.Size(75, 23);
            this.efButton2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.efButton2.TabIndex = 8;
            this.efButton2.Text = "efButton2";
            // 
            // FormPSSM10ADD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.ClientSize = new System.Drawing.Size(984, 562);
            this.Controls.Add(this.efButton2);
            this.Controls.Add(this.efButton1);
            this.Controls.Add(this.efDevGrid2);
            this.Controls.Add(this.efDevGrid1);
            this.Name = "FormPSSM10ADD";
            this.Controls.SetChildIndex(this.efDevGrid1, 0);
            this.Controls.SetChildIndex(this.efDevGrid2, 0);
            this.Controls.SetChildIndex(this.efButton1, 0);
            this.Controls.SetChildIndex(this.efButton2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efDevGrid2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.efButton2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup Root;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.XtraLayout.SimpleSeparator simpleSeparator1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem3;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem5;
        private EF.EFDevGrid efDevGrid1;
        private EF.EFDevGrid efDevGrid2;
        private EF.EFButton efButton1;
        private EF.EFButton efButton2;

    }
}