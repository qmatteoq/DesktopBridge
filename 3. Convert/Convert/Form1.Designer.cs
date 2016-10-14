namespace Convert
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
            this.parameter = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // parameter
            // 
            this.parameter.Location = new System.Drawing.Point(16, 179);
            this.parameter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.parameter.Name = "parameter";
            this.parameter.Size = new System.Drawing.Size(517, 34);
            this.parameter.TabIndex = 1;
            this.parameter.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(20, 91);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(513, 66);
            this.button2.TabIndex = 2;
            this.button2.Text = "Serialize data on desktop";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.OnSerializeData);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 18);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(514, 62);
            this.button1.TabIndex = 0;
            this.button1.Text = "Create file on desktop";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnCreateFile);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 458);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.parameter);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label parameter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
    }
}

