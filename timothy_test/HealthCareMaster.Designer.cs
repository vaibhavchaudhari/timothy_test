namespace timothy_test
{
    partial class HealthCareMaster
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HealthCareMaster));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txt_description = new System.Windows.Forms.RichTextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lst_disease = new System.Windows.Forms.ListBox();
            this.btn_showall = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.Sync = new System.Windows.Forms.Button();
            this.test_grid = new System.Windows.Forms.DataGridView();
            this.lbl_mainmenuname = new System.Windows.Forms.Label();
            this.lst_grid = new System.Windows.Forms.DataGridView();
            this.serial_no = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.test_grid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Wheat;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.txt_description);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.btn_new);
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.lst_disease);
            this.panel1.Controls.Add(this.btn_showall);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(76, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(766, 275);
            this.panel1.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Firebrick;
            this.label5.Location = new System.Drawing.Point(287, 11);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(207, 29);
            this.label5.TabIndex = 17;
            this.label5.Text = "Health Care Master";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(251, 111);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(254, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "NOTE: Insert Text in (#) to Treat as MENU";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.ImageLocation = "0";
            this.pictureBox1.Location = new System.Drawing.Point(41, 59);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(22, 19);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // txt_description
            // 
            this.txt_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_description.Location = new System.Drawing.Point(254, 130);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(495, 125);
            this.txt_description.TabIndex = 2;
            this.txt_description.Text = "";
            this.txt_description.TextChanged += new System.EventHandler(this.txt_description_TextChanged);
            this.txt_description.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_description_KeyDown);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.Location = new System.Drawing.Point(652, 65);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 32);
            this.btn_delete.TabIndex = 7;
            this.btn_delete.Text = "Delete";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_save
            // 
            this.btn_save.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_save.Location = new System.Drawing.Point(571, 65);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 32);
            this.btn_save.TabIndex = 3;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_new
            // 
            this.btn_new.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_new.Location = new System.Drawing.Point(490, 65);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 32);
            this.btn_new.TabIndex = 0;
            this.btn_new.Text = "New";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_name.Location = new System.Drawing.Point(305, 71);
            this.txt_name.MaxLength = 200;
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(124, 24);
            this.txt_name.TabIndex = 1;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_name.Location = new System.Drawing.Point(251, 71);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(48, 18);
            this.lbl_name.TabIndex = 4;
            this.lbl_name.Text = "Name";
            // 
            // lst_disease
            // 
            this.lst_disease.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lst_disease.FormattingEnabled = true;
            this.lst_disease.ItemHeight = 18;
            this.lst_disease.Location = new System.Drawing.Point(41, 89);
            this.lst_disease.Name = "lst_disease";
            this.lst_disease.Size = new System.Drawing.Size(190, 166);
            this.lst_disease.TabIndex = 8;
            this.lst_disease.Click += new System.EventHandler(this.lst_disease_Click);
            // 
            // btn_showall
            // 
            this.btn_showall.BackColor = System.Drawing.Color.Transparent;
            this.btn_showall.BackgroundImage = global::timothy_test.Properties.Resources.clear;
            this.btn_showall.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btn_showall.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_showall.ForeColor = System.Drawing.Color.Black;
            this.btn_showall.Location = new System.Drawing.Point(205, 59);
            this.btn_showall.Name = "btn_showall";
            this.btn_showall.Size = new System.Drawing.Size(26, 24);
            this.btn_showall.TabIndex = 6;
            this.btn_showall.UseVisualStyleBackColor = false;
            this.btn_showall.Click += new System.EventHandler(this.btn_showall_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearch.Location = new System.Drawing.Point(64, 59);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(138, 24);
            this.txtSearch.TabIndex = 4;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Wheat;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.Sync);
            this.panel2.Controls.Add(this.test_grid);
            this.panel2.Controls.Add(this.lbl_mainmenuname);
            this.panel2.Controls.Add(this.lst_grid);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(76, 293);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(766, 330);
            this.panel2.TabIndex = 0;
            // 
            // Sync
            // 
            this.Sync.Font = new System.Drawing.Font("Corbel", 11.25F, System.Drawing.FontStyle.Bold);
            this.Sync.Location = new System.Drawing.Point(45, 277);
            this.Sync.Name = "Sync";
            this.Sync.Size = new System.Drawing.Size(70, 38);
            this.Sync.TabIndex = 18;
            this.Sync.Text = "Sync";
            this.Sync.UseVisualStyleBackColor = true;
            this.Sync.Click += new System.EventHandler(this.Sync_Click);
            // 
            // test_grid
            // 
            this.test_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.test_grid.BackgroundColor = System.Drawing.Color.White;
            this.test_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.test_grid.GridColor = System.Drawing.Color.Maroon;
            this.test_grid.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.test_grid.Location = new System.Drawing.Point(254, 46);
            this.test_grid.Name = "test_grid";
            this.test_grid.RowHeadersVisible = false;
            this.test_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.test_grid.Size = new System.Drawing.Size(495, 225);
            this.test_grid.TabIndex = 16;
            this.test_grid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.test_grid_CellContentClick_1);
            this.test_grid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.test_grid_CellValueChanged_1);
            // 
            // lbl_mainmenuname
            // 
            this.lbl_mainmenuname.AutoSize = true;
            this.lbl_mainmenuname.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_mainmenuname.ForeColor = System.Drawing.Color.Blue;
            this.lbl_mainmenuname.Location = new System.Drawing.Point(170, 14);
            this.lbl_mainmenuname.Name = "lbl_mainmenuname";
            this.lbl_mainmenuname.Size = new System.Drawing.Size(0, 18);
            this.lbl_mainmenuname.TabIndex = 3;
            // 
            // lst_grid
            // 
            this.lst_grid.AllowDrop = true;
            this.lst_grid.AllowUserToAddRows = false;
            this.lst_grid.AllowUserToDeleteRows = false;
            this.lst_grid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.lst_grid.BackgroundColor = System.Drawing.Color.White;
            this.lst_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lst_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial_no});
            this.lst_grid.GridColor = System.Drawing.Color.Maroon;
            this.lst_grid.Location = new System.Drawing.Point(45, 46);
            this.lst_grid.Name = "lst_grid";
            this.lst_grid.ReadOnly = true;
            this.lst_grid.RowHeadersVisible = false;
            this.lst_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.lst_grid.Size = new System.Drawing.Size(186, 225);
            this.lst_grid.TabIndex = 16;
            this.lst_grid.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.lst_grid_CellClick_1);
            // 
            // serial_no
            // 
            this.serial_no.HeaderText = "Sr.No.";
            this.serial_no.MaxInputLength = 100;
            this.serial_no.MinimumWidth = 2;
            this.serial_no.Name = "serial_no";
            this.serial_no.ReadOnly = true;
            this.serial_no.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F);
            this.label1.Location = new System.Drawing.Point(46, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name of Disease:";
            // 
            // HealthCareMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(938, 649);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "HealthCareMaster";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Health Care Master";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.test_grid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lst_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ListBox lst_disease;
        private System.Windows.Forms.RichTextBox txt_description;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btn_showall;
        private System.Windows.Forms.DataGridView lst_grid;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_no;
        private System.Windows.Forms.Label lbl_mainmenuname;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView test_grid;
        private System.Windows.Forms.Button Sync;
    }
}

