namespace SmartAnalyticsApp
{
    partial class AddProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddProduct));
            this.label24 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.AddMakerButton = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label24.Location = new System.Drawing.Point(92, 69);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(191, 24);
            this.label24.TabIndex = 55;
            this.label24.Text = "Name of new product";
            // 
            // textBox7
            // 
            this.textBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox7.Location = new System.Drawing.Point(95, 109);
            this.textBox7.Margin = new System.Windows.Forms.Padding(2);
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(176, 31);
            this.textBox7.TabIndex = 56;
            // 
            // AddMakerButton
            // 
            this.AddMakerButton.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddMakerButton.Appearance.Options.UseFont = true;
            this.AddMakerButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AddMakerButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddMakerButton.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("AddMakerButton.ImageOptions.Image")));
            this.AddMakerButton.ImageOptions.ImageToTextAlignment = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            this.AddMakerButton.Location = new System.Drawing.Point(96, 182);
            this.AddMakerButton.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Style3D;
            this.AddMakerButton.Name = "AddMakerButton";
            this.AddMakerButton.Size = new System.Drawing.Size(175, 51);
            this.AddMakerButton.TabIndex = 57;
            this.AddMakerButton.Text = "Add";
            this.AddMakerButton.Click += new System.EventHandler(this.AddMakerButton_Click);
            // 
            // AddProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 320);
            this.Controls.Add(this.label24);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.AddMakerButton);
            this.Name = "AddProduct";
            this.Text = "AddProduct";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label24;
        public System.Windows.Forms.TextBox textBox7;
        private DevExpress.XtraEditors.SimpleButton AddMakerButton;
    }
}