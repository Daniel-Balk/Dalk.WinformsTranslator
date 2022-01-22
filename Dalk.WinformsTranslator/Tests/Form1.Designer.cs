namespace Tests
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.goGer = new System.Windows.Forms.Button();
            this.goEng = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(74, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "#test";
            // 
            // goGer
            // 
            this.goGer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.goGer.Location = new System.Drawing.Point(713, 12);
            this.goGer.Name = "goGer";
            this.goGer.Size = new System.Drawing.Size(75, 23);
            this.goGer.TabIndex = 1;
            this.goGer.Text = "#german";
            this.goGer.UseVisualStyleBackColor = true;
            this.goGer.Click += new System.EventHandler(this.goGer_Click);
            // 
            // goEng
            // 
            this.goEng.Location = new System.Drawing.Point(713, 41);
            this.goEng.Name = "goEng";
            this.goEng.Size = new System.Drawing.Size(75, 23);
            this.goEng.TabIndex = 2;
            this.goEng.Text = "#english";
            this.goEng.UseVisualStyleBackColor = true;
            this.goEng.Click += new System.EventHandler(this.goEng_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.goEng);
            this.Controls.Add(this.goGer);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "aaa";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button goGer;
        private System.Windows.Forms.Button goEng;
    }
}
