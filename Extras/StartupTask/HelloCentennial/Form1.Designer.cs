namespace HelloCentennial
{
    partial class Form1
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
            this.button1 = new System.Windows.Forms.Button();
            this.chkBoxStartup = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(190, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(196, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create file on desktop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnCreateFile);
            // 
            // chkBoxStartup
            // 
            this.chkBoxStartup.AutoSize = true;
            this.chkBoxStartup.Location = new System.Drawing.Point(216, 225);
            this.chkBoxStartup.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkBoxStartup.Name = "chkBoxStartup";
            this.chkBoxStartup.Size = new System.Drawing.Size(130, 24);
            this.chkBoxStartup.TabIndex = 1;
            this.chkBoxStartup.Text = "Run at startup";
            this.chkBoxStartup.UseVisualStyleBackColor = true;
            this.chkBoxStartup.Click += new System.EventHandler(this.chkBoxStartup_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 368);
            this.Controls.Add(this.chkBoxStartup);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox chkBoxStartup;
    }
}

