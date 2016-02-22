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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_popupwindow));
            this.lst_main = new System.Windows.Forms.ListBox();
            this.btn_prev = new System.Windows.Forms.Button();
            this.btn_next = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lbl_selectiontype = new System.Windows.Forms.Label();
            this.txt_displaytext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lst_main
            // 
            this.lst_main.BackColor = System.Drawing.Color.Wheat;
            this.lst_main.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_main.FormattingEnabled = true;
            this.lst_main.ItemHeight = 18;
            this.lst_main.Location = new System.Drawing.Point(96, 46);
            this.lst_main.Name = "lst_main";
            this.lst_main.Size = new System.Drawing.Size(308, 220);
            this.lst_main.TabIndex = 0;
            this.lst_main.SelectedIndexChanged += new System.EventHandler(this.lst_main_SelectedIndexChanged);
            this.lst_main.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lst_main_KeyDown);
            // 
            // btn_prev
            // 
            this.btn_prev.BackColor = System.Drawing.Color.Transparent;
            this.btn_prev.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_prev.BackgroundImage")));
            this.btn_prev.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_prev.Location = new System.Drawing.Point(35, 152);
            this.btn_prev.Name = "btn_prev";
            this.btn_prev.Size = new System.Drawing.Size(42, 41);
            this.btn_prev.TabIndex = 1;
            this.btn_prev.UseVisualStyleBackColor = false;
            this.btn_prev.Click += new System.EventHandler(this.btn_prev_Click);
            // 
            // btn_next
            // 
            this.btn_next.BackColor = System.Drawing.Color.Transparent;
            this.btn_next.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_next.BackgroundImage")));
            this.btn_next.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_next.Location = new System.Drawing.Point(424, 152);
            this.btn_next.Name = "btn_next";
            this.btn_next.Size = new System.Drawing.Size(41, 41);
            this.btn_next.TabIndex = 2;
            this.btn_next.UseVisualStyleBackColor = false;
            this.btn_next.Click += new System.EventHandler(this.btn_next_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // lbl_selectiontype
            // 
            this.lbl_selectiontype.AutoSize = true;
            this.lbl_selectiontype.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_selectiontype.ForeColor = System.Drawing.Color.Maroon;
            this.lbl_selectiontype.Location = new System.Drawing.Point(93, 15);
            this.lbl_selectiontype.Name = "lbl_selectiontype";
            this.lbl_selectiontype.Size = new System.Drawing.Size(0, 16);
            this.lbl_selectiontype.TabIndex = 3;
            // 
            // txt_displaytext
            // 
            this.txt_displaytext.BackColor = System.Drawing.Color.Wheat;
            this.txt_displaytext.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_displaytext.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.txt_displaytext.Location = new System.Drawing.Point(96, 297);
            this.txt_displaytext.Multiline = true;
            this.txt_displaytext.Name = "txt_displaytext";
            this.txt_displaytext.Size = new System.Drawing.Size(308, 151);
            this.txt_displaytext.TabIndex = 4;
            // 
            // frm_popupwindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 498);
            this.Controls.Add(this.txt_displaytext);
            this.Controls.Add(this.lbl_selectiontype);
            this.Controls.Add(this.btn_next);
            this.Controls.Add(this.btn_prev);
            this.Controls.Add(this.lst_main);
            this.Name = "frm_popupwindow";
            this.Text = ":";
            this.Load += new System.EventHandler(this.frm_popupwindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.ListBox lst_main;
        private System.Windows.Forms.Button btn_prev;
        private System.Windows.Forms.Button btn_next;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Label lbl_selectiontype;
        private System.Windows.Forms.TextBox txt_displaytext;
    }
}