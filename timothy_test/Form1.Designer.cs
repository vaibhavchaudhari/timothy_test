namespace timothy_test
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_description = new System.Windows.Forms.RichTextBox();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_new = new System.Windows.Forms.Button();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.lbl_name = new System.Windows.Forms.Label();
            this.lst_disease = new System.Windows.Forms.ListBox();
            this.btn_showall = new System.Windows.Forms.Button();
            this.btn_search = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txt_mainmenuname = new System.Windows.Forms.TextBox();
            this.lst_submenu = new System.Windows.Forms.ListBox();
            this.data_grid = new System.Windows.Forms.DataGridView();
            this.btn_delete_record = new System.Windows.Forms.Button();
            this.btn_update = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_record_id = new System.Windows.Forms.TextBox();
            this.txt_Value = new System.Windows.Forms.TextBox();
            this.serial_number = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txt_description);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_save);
            this.panel1.Controls.Add(this.btn_new);
            this.panel1.Controls.Add(this.txt_name);
            this.panel1.Controls.Add(this.lbl_name);
            this.panel1.Controls.Add(this.lst_disease);
            this.panel1.Controls.Add(this.btn_showall);
            this.panel1.Controls.Add(this.btn_search);
            this.panel1.Controls.Add(this.txtSearch);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(830, 229);
            this.panel1.TabIndex = 0;
            // 
            // txt_description
            // 
            this.txt_description.Location = new System.Drawing.Point(151, 105);
            this.txt_description.Name = "txt_description";
            this.txt_description.Size = new System.Drawing.Size(484, 119);
            this.txt_description.TabIndex = 10;
            this.txt_description.Text = "";
            this.txt_description.TextChanged += new System.EventHandler(this.txt_description_TextChanged);
            this.txt_description.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txt_description_KeyPress_1);
            // 
            // btn_delete
            // 
            this.btn_delete.Location = new System.Drawing.Point(560, 64);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_delete.TabIndex = 9;
            this.btn_delete.Text = "DELETE";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_save
            // 
            this.btn_save.Location = new System.Drawing.Point(459, 64);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(75, 23);
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "SAVE";
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_new
            // 
            this.btn_new.Location = new System.Drawing.Point(357, 64);
            this.btn_new.Name = "btn_new";
            this.btn_new.Size = new System.Drawing.Size(75, 23);
            this.btn_new.TabIndex = 7;
            this.btn_new.Text = "NEW";
            this.btn_new.UseVisualStyleBackColor = true;
            this.btn_new.Click += new System.EventHandler(this.btn_new_Click);
            // 
            // txt_name
            // 
            this.txt_name.Location = new System.Drawing.Point(171, 67);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(124, 20);
            this.txt_name.TabIndex = 5;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(168, 51);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(35, 13);
            this.lbl_name.TabIndex = 4;
            this.lbl_name.Text = "Name";
            // 
            // lst_disease
            // 
            this.lst_disease.FormattingEnabled = true;
            this.lst_disease.Location = new System.Drawing.Point(12, 51);
            this.lst_disease.Name = "lst_disease";
            this.lst_disease.Size = new System.Drawing.Size(133, 173);
            this.lst_disease.TabIndex = 3;
            this.lst_disease.Click += new System.EventHandler(this.lst_disease_Click);
            // 
            // btn_showall
            // 
            this.btn_showall.Location = new System.Drawing.Point(273, 12);
            this.btn_showall.Name = "btn_showall";
            this.btn_showall.Size = new System.Drawing.Size(75, 23);
            this.btn_showall.TabIndex = 2;
            this.btn_showall.Text = "Show All";
            this.btn_showall.UseVisualStyleBackColor = true;
            this.btn_showall.Click += new System.EventHandler(this.btn_showall_Click);
            // 
            // btn_search
            // 
            this.btn_search.Location = new System.Drawing.Point(171, 12);
            this.btn_search.Name = "btn_search";
            this.btn_search.Size = new System.Drawing.Size(75, 23);
            this.btn_search.TabIndex = 1;
            this.btn_search.Text = "Search";
            this.btn_search.UseVisualStyleBackColor = true;
            this.btn_search.Click += new System.EventHandler(this.btn_search_Click);
            // 
            // txtSearch
            // 
            this.txtSearch.Location = new System.Drawing.Point(12, 12);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(133, 20);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.txt_record_id);
            this.panel2.Controls.Add(this.txt_Value);
            this.panel2.Controls.Add(this.btn_delete_record);
            this.panel2.Controls.Add(this.btn_update);
            this.panel2.Controls.Add(this.btn_add);
            this.panel2.Controls.Add(this.data_grid);
            this.panel2.Controls.Add(this.txt_mainmenuname);
            this.panel2.Controls.Add(this.lst_submenu);
            this.panel2.Location = new System.Drawing.Point(0, 230);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(830, 277);
            this.panel2.TabIndex = 0;
            // 
            // txt_mainmenuname
            // 
            this.txt_mainmenuname.Location = new System.Drawing.Point(12, 20);
            this.txt_mainmenuname.Name = "txt_mainmenuname";
            this.txt_mainmenuname.Size = new System.Drawing.Size(133, 20);
            this.txt_mainmenuname.TabIndex = 6;
            // 
            // lst_submenu
            // 
            this.lst_submenu.FormattingEnabled = true;
            this.lst_submenu.Location = new System.Drawing.Point(12, 46);
            this.lst_submenu.Name = "lst_submenu";
            this.lst_submenu.Size = new System.Drawing.Size(133, 186);
            this.lst_submenu.TabIndex = 4;
            this.lst_submenu.SelectedIndexChanged += new System.EventHandler(this.lst_submenu_SelectedIndexChanged);
            // 
            // data_grid
            // 
            this.data_grid.AllowDrop = true;
            this.data_grid.AllowUserToAddRows = false;
            this.data_grid.AllowUserToDeleteRows = false;
            this.data_grid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.data_grid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serial_number});
            this.data_grid.Location = new System.Drawing.Point(151, 46);
            this.data_grid.Name = "data_grid";
            this.data_grid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.data_grid.Size = new System.Drawing.Size(484, 150);
            this.data_grid.TabIndex = 7;
            // 
            // btn_delete_record
            // 
            this.btn_delete_record.Location = new System.Drawing.Point(560, 224);
            this.btn_delete_record.Name = "btn_delete_record";
            this.btn_delete_record.Size = new System.Drawing.Size(75, 23);
            this.btn_delete_record.TabIndex = 10;
            this.btn_delete_record.Text = "DELETE";
            this.btn_delete_record.UseVisualStyleBackColor = true;
            this.btn_delete_record.Click += new System.EventHandler(this.btn_delete_record_Click);
            // 
            // btn_update
            // 
            this.btn_update.Location = new System.Drawing.Point(459, 224);
            this.btn_update.Name = "btn_update";
            this.btn_update.Size = new System.Drawing.Size(75, 23);
            this.btn_update.TabIndex = 9;
            this.btn_update.Text = "UPDATE";
            this.btn_update.UseVisualStyleBackColor = true;
            this.btn_update.Click += new System.EventHandler(this.btn_update_Click);
            // 
            // btn_add
            // 
            this.btn_add.Location = new System.Drawing.Point(357, 224);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(75, 23);
            this.btn_add.TabIndex = 8;
            this.btn_add.Text = "ADD RECORD";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(676, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Value";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(686, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(18, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "ID";
            // 
            // txt_record_id
            // 
            this.txt_record_id.Enabled = false;
            this.txt_record_id.Location = new System.Drawing.Point(712, 86);
            this.txt_record_id.Name = "txt_record_id";
            this.txt_record_id.Size = new System.Drawing.Size(100, 20);
            this.txt_record_id.TabIndex = 12;
            // 
            // txt_Value
            // 
            this.txt_Value.Location = new System.Drawing.Point(712, 113);
            this.txt_Value.Name = "txt_Value";
            this.txt_Value.Size = new System.Drawing.Size(100, 20);
            this.txt_Value.TabIndex = 11;
            // 
            // serial_number
            // 
            this.serial_number.HeaderText = "Sr. No";
            this.serial_number.Name = "serial_number";
            this.serial_number.ReadOnly = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(834, 505);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.data_grid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_showall;
        private System.Windows.Forms.Button btn_search;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_new;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.Label lbl_name;
        private System.Windows.Forms.ListBox lst_disease;
        private System.Windows.Forms.RichTextBox txt_description;
        private System.Windows.Forms.TextBox txt_mainmenuname;
        private System.Windows.Forms.ListBox lst_submenu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_record_id;
        private System.Windows.Forms.TextBox txt_Value;
        private System.Windows.Forms.Button btn_delete_record;
        private System.Windows.Forms.Button btn_update;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView data_grid;
        private System.Windows.Forms.DataGridViewTextBoxColumn serial_number;
    }
}

