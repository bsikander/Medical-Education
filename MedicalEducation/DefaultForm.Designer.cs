namespace MedicalEducation
{
    partial class DefaultForm
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
            this.customButton1 = new MedicalEducation.Controls.CustomButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grdApplication = new System.Windows.Forms.DataGridView();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdApplication)).BeginInit();
            this.SuspendLayout();
            // 
            // customButton1
            // 
            this.customButton1.BackColor = System.Drawing.Color.SteelBlue;
            this.customButton1.Font = new System.Drawing.Font("Arial", 8F);
            this.customButton1.ForeColor = System.Drawing.Color.White;
            this.customButton1.Location = new System.Drawing.Point(12, 12);
            this.customButton1.Name = "customButton1";
            this.customButton1.RoundCorners = true;
            this.customButton1.Size = new System.Drawing.Size(134, 23);
            this.customButton1.TabIndex = 0;
            this.customButton1.Text = "New Application";
            this.customButton1.UseVisualStyleBackColor = false;
            this.customButton1.Click += new System.EventHandler(this.customButton1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grdApplication);
            this.groupBox1.Location = new System.Drawing.Point(12, 41);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(621, 264);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Submitted Application";
            // 
            // grdApplication
            // 
            this.grdApplication.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdApplication.Location = new System.Drawing.Point(6, 19);
            this.grdApplication.Name = "grdApplication";
            this.grdApplication.Size = new System.Drawing.Size(609, 239);
            this.grdApplication.TabIndex = 3;
            // 
            // DefaultForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(645, 317);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.customButton1);
            this.Name = "DefaultForm";
            this.Text = "Application";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdApplication)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private MedicalEducation.Controls.CustomButton customButton1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView grdApplication;
    }
}