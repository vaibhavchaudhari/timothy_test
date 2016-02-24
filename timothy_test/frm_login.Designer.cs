namespace timothy_test
{
    partial class frm_login
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
            this.panellogin = new System.Windows.Forms.Panel();
            this.btn_login = new System.Windows.Forms.Button();
            this.txtpass = new System.Windows.Forms.TextBox();
            this.txtuid = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.link_to_register = new System.Windows.Forms.LinkLabel();
            this.panellogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // panellogin
            // 
            this.panellogin.Controls.Add(this.link_to_register);
            this.panellogin.Controls.Add(this.btn_login);
            this.panellogin.Controls.Add(this.txtpass);
            this.panellogin.Controls.Add(this.txtuid);
            this.panellogin.Controls.Add(this.label2);
            this.panellogin.Controls.Add(this.label1);
            this.panellogin.Location = new System.Drawing.Point(1, 44);
            this.panellogin.Name = "panellogin";
            this.panellogin.Size = new System.Drawing.Size(281, 192);
            this.panellogin.TabIndex = 0;
            // 
            // btn_login
            // 
            this.btn_login.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.btn_login.Location = new System.Drawing.Point(102, 114);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(65, 27);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "Login";
            this.btn_login.UseVisualStyleBackColor = true;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // txtpass
            // 
            this.txtpass.Location = new System.Drawing.Point(92, 75);
            this.txtpass.Name = "txtpass";
            this.txtpass.Size = new System.Drawing.Size(157, 20);
            this.txtpass.TabIndex = 3;
            // 
            // txtuid
            // 
            this.txtuid.Location = new System.Drawing.Point(92, 40);
            this.txtuid.Name = "txtuid";
            this.txtuid.Size = new System.Drawing.Size(157, 20);
            this.txtuid.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(11, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(11, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "UserId:";
            // 
            // link_to_register
            // 
            this.link_to_register.AutoSize = true;
            this.link_to_register.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold);
            this.link_to_register.Location = new System.Drawing.Point(56, 166);
            this.link_to_register.Name = "link_to_register";
            this.link_to_register.Size = new System.Drawing.Size(138, 16);
            this.link_to_register.TabIndex = 5;
            this.link_to_register.TabStop = true;
            this.link_to_register.Text = "New User Register";
            // 
            // frm_login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panellogin);
            this.Name = "frm_login";
            this.Text = "frm_login";
            this.panellogin.ResumeLayout(false);
            this.panellogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panellogin;
        private System.Windows.Forms.Button btn_login;
        private System.Windows.Forms.TextBox txtpass;
        private System.Windows.Forms.TextBox txtuid;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.LinkLabel link_to_register;
    }
}