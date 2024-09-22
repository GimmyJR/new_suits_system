namespace new_suits_system.PL
{
    partial class FRM_LOGIN
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textuser_name = new System.Windows.Forms.TextBox();
            this.textpwd = new System.Windows.Forms.TextBox();
            this.btnlogin = new System.Windows.Forms.Button();
            this.btncancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "اسم المستخدم :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 131);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "كلمة المرور :";
            // 
            // textuser_name
            // 
            this.textuser_name.Location = new System.Drawing.Point(120, 45);
            this.textuser_name.Name = "textuser_name";
            this.textuser_name.Size = new System.Drawing.Size(340, 22);
            this.textuser_name.TabIndex = 2;
            this.textuser_name.TextChanged += new System.EventHandler(this.textuser_name_TextChanged);
            this.textuser_name.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textuser_name_KeyDown);
            // 
            // textpwd
            // 
            this.textpwd.Location = new System.Drawing.Point(120, 128);
            this.textpwd.Name = "textpwd";
            this.textpwd.PasswordChar = '*';
            this.textpwd.Size = new System.Drawing.Size(340, 22);
            this.textpwd.TabIndex = 3;
            this.textpwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textpwd_KeyDown);
            // 
            // btnlogin
            // 
            this.btnlogin.Location = new System.Drawing.Point(359, 177);
            this.btnlogin.Name = "btnlogin";
            this.btnlogin.Size = new System.Drawing.Size(106, 34);
            this.btnlogin.TabIndex = 4;
            this.btnlogin.Text = "الدخول ";
            this.btnlogin.UseVisualStyleBackColor = true;
            this.btnlogin.Click += new System.EventHandler(this.btnlogin_Click);
            // 
            // btncancel
            // 
            this.btncancel.Location = new System.Drawing.Point(231, 177);
            this.btncancel.Name = "btncancel";
            this.btncancel.Size = new System.Drawing.Size(105, 34);
            this.btncancel.TabIndex = 5;
            this.btncancel.Text = "الغاء";
            this.btncancel.UseVisualStyleBackColor = true;
            this.btncancel.Click += new System.EventHandler(this.btncancel_Click);
            // 
            // FRM_LOGIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 250);
            this.Controls.Add(this.btncancel);
            this.Controls.Add(this.btnlogin);
            this.Controls.Add(this.textpwd);
            this.Controls.Add(this.textuser_name);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_LOGIN";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "التسجيل";
            this.Load += new System.EventHandler(this.FRM_LOGIN_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textuser_name;
        private System.Windows.Forms.TextBox textpwd;
        private System.Windows.Forms.Button btnlogin;
        private System.Windows.Forms.Button btncancel;
    }
}