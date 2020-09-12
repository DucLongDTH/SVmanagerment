namespace SVMANAGERMENT
{
    partial class HomePage
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.HP_title = new System.Windows.Forms.Label();
            this.HP_Name = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // HP_title
            // 
            this.HP_title.AutoSize = true;
            this.HP_title.Font = new System.Drawing.Font("Candara", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HP_title.ForeColor = System.Drawing.Color.White;
            this.HP_title.Location = new System.Drawing.Point(224, 209);
            this.HP_title.Name = "HP_title";
            this.HP_title.Size = new System.Drawing.Size(452, 42);
            this.HP_title.TabIndex = 0;
            this.HP_title.Text = "Phần Mềm Quản Lý Sinh Viên";
            // 
            // HP_Name
            // 
            this.HP_Name.AutoSize = true;
            this.HP_Name.Font = new System.Drawing.Font("Candara", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HP_Name.ForeColor = System.Drawing.Color.White;
            this.HP_Name.Location = new System.Drawing.Point(318, 271);
            this.HP_Name.Name = "HP_Name";
            this.HP_Name.Size = new System.Drawing.Size(251, 36);
            this.HP_Name.TabIndex = 1;
            this.HP_Name.Text = "SVMANAGERMENT";
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(171)))), ((int)(((byte)(185)))));
            this.Controls.Add(this.HP_Name);
            this.Controls.Add(this.HP_title);
            this.Name = "HomePage";
            this.Size = new System.Drawing.Size(880, 590);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label HP_title;
        private System.Windows.Forms.Label HP_Name;
    }
}
