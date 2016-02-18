namespace timothy_test
{
    partial class frm_popupwindow
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
            this.lst_main = new System.Windows.Forms.ListBox();
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lst_main
            // 
            this.lst_main.BackColor = System.Drawing.SystemColors.Info;
            this.lst_main.FormattingEnabled = true;
            this.lst_main.Location = new System.Drawing.Point(101, 50);
            this.lst_main.Name = "lst_main";
            this.lst_main.Size = new System.Drawing.Size(120, 95);
            this.lst_main.TabIndex = 0;
            // 
            // btn_prev
            // 
            this.btn_prev.Location = new System.Drawing.Point(12, 91);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(75, 23);
            this.btn_prev.TabIndex = 1;
            this.btn_prev.Text = "previous";
            this.btn_prev.UseVisualStyleBackColor = true;
            // 
            // btn_next
            // 
            this.btn_next.Location = new System.Drawing.Point(236, 91);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(75, 23);
            this.btn_next.TabIndex = 2;
            this.btn_next.Text = "next";
            this.btn_next.UseVisualStyleBackColor = true;
            // 
            // frm_popupwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 261);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.lst_main);
            this.Name = "frm_popupwindow";
            this.Text = "frm_popupwindow";
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.ListBox lst_main;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Button btn_next;
    }
}