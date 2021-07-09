
namespace Proje3
{
    partial class registerPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(registerPage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TextUserName = new System.Windows.Forms.TextBox();
            this.TextUserMail = new System.Windows.Forms.TextBox();
            this.TextUserCountryCode = new System.Windows.Forms.TextBox();
            this.TextUserPassword = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 184);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 228);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Email";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 273);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 321);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(99, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Country Code";
            // 
            // TextUserName
            // 
            this.TextUserName.Location = new System.Drawing.Point(131, 184);
            this.TextUserName.Name = "TextUserName";
            this.TextUserName.Size = new System.Drawing.Size(167, 27);
            this.TextUserName.TabIndex = 4;
            // 
            // TextUserMail
            // 
            this.TextUserMail.Location = new System.Drawing.Point(131, 273);
            this.TextUserMail.Name = "TextUserMail";
            this.TextUserMail.PasswordChar = '*';
            this.TextUserMail.Size = new System.Drawing.Size(167, 27);
            this.TextUserMail.TabIndex = 5;
            // 
            // TextUserCountryCode
            // 
            this.TextUserCountryCode.Location = new System.Drawing.Point(131, 318);
            this.TextUserCountryCode.Name = "TextUserCountryCode";
            this.TextUserCountryCode.Size = new System.Drawing.Size(167, 27);
            this.TextUserCountryCode.TabIndex = 6;
            this.TextUserCountryCode.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // TextUserPassword
            // 
            this.TextUserPassword.Location = new System.Drawing.Point(131, 225);
            this.TextUserPassword.Name = "TextUserPassword";
            this.TextUserPassword.Size = new System.Drawing.Size(167, 27);
            this.TextUserPassword.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Silver;
            this.button1.Location = new System.Drawing.Point(32, 410);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(266, 37);
            this.button1.TabIndex = 8;
            this.button1.Text = "Sign Up";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Silver;
            this.button2.Location = new System.Drawing.Point(32, 454);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(266, 41);
            this.button2.TabIndex = 9;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
            this.label5.Location = new System.Drawing.Point(407, 9);
            this.label5.MinimumSize = new System.Drawing.Size(600, 550);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(600, 550);
            this.label5.TabIndex = 10;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Image = ((System.Drawing.Image)(resources.GetObject("label7.Image")));
            this.label7.Location = new System.Drawing.Point(32, 51);
            this.label7.MinimumSize = new System.Drawing.Size(70, 80);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(70, 80);
            this.label7.TabIndex = 13;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label8.ForeColor = System.Drawing.Color.MediumAquamarine;
            this.label8.Location = new System.Drawing.Point(108, 42);
            this.label8.MinimumSize = new System.Drawing.Size(200, 80);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(239, 89);
            this.label8.TabIndex = 12;
            this.label8.Text = "MUSIC";
            // 
            // registerPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1009, 570);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextUserPassword);
            this.Controls.Add(this.TextUserCountryCode);
            this.Controls.Add(this.TextUserMail);
            this.Controls.Add(this.TextUserName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "registerPage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "registerPage";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TextUserName;
        private System.Windows.Forms.TextBox TextUserMail;
        private System.Windows.Forms.TextBox TextUserCountryCode;
        private System.Windows.Forms.TextBox TextUserPassword;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}