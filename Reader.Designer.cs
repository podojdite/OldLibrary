﻿
namespace Library
{
    partial class Reader
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
            this.Out_AllBookExmpl = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.NewBooks = new System.Windows.Forms.Button();
            this.SearchBook1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.SearchBook2 = new System.Windows.Forms.Button();
            this.Popular = new System.Windows.Forms.Button();
            this.NotPopular = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Out_AllBookExmpl
            // 
            this.Out_AllBookExmpl.Location = new System.Drawing.Point(12, 12);
            this.Out_AllBookExmpl.Name = "Out_AllBookExmpl";
            this.Out_AllBookExmpl.Size = new System.Drawing.Size(112, 71);
            this.Out_AllBookExmpl.TabIndex = 2;
            this.Out_AllBookExmpl.Text = "Все книги";
            this.Out_AllBookExmpl.UseVisualStyleBackColor = true;
            this.Out_AllBookExmpl.Click += new System.EventHandler(this.Out_AllBookExmpl_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 89);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(1156, 556);
            this.dataGridView1.TabIndex = 3;
            // 
            // NewBooks
            // 
            this.NewBooks.Location = new System.Drawing.Point(130, 12);
            this.NewBooks.Name = "NewBooks";
            this.NewBooks.Size = new System.Drawing.Size(112, 71);
            this.NewBooks.TabIndex = 4;
            this.NewBooks.Text = "Мои книги";
            this.NewBooks.UseVisualStyleBackColor = true;
            this.NewBooks.Click += new System.EventHandler(this.NewBooks_Click);
            // 
            // SearchBook1
            // 
            this.SearchBook1.Location = new System.Drawing.Point(248, 48);
            this.SearchBook1.Name = "SearchBook1";
            this.SearchBook1.Size = new System.Drawing.Size(295, 35);
            this.SearchBook1.TabIndex = 5;
            this.SearchBook1.Text = "Найти книги";
            this.SearchBook1.UseVisualStyleBackColor = true;
            this.SearchBook1.Click += new System.EventHandler(this.SearchBook1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Название",
            "Автор",
            "Жанр"});
            this.comboBox1.Location = new System.Drawing.Point(430, 19);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(113, 23);
            this.comboBox1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(324, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 23);
            this.textBox1.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(248, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 25);
            this.label1.TabIndex = 8;
            this.label1.Text = "Поиск:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(549, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(153, 25);
            this.label2.TabIndex = 9;
            this.label2.Text = "Название книги:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(708, 17);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(160, 23);
            this.textBox2.TabIndex = 10;
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Экземпляры",
            "Издания"});
            this.comboBox2.Location = new System.Drawing.Point(874, 18);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(88, 23);
            this.comboBox2.TabIndex = 11;
            // 
            // SearchBook2
            // 
            this.SearchBook2.Location = new System.Drawing.Point(549, 48);
            this.SearchBook2.Name = "SearchBook2";
            this.SearchBook2.Size = new System.Drawing.Size(413, 35);
            this.SearchBook2.TabIndex = 12;
            this.SearchBook2.Text = "Поиск";
            this.SearchBook2.UseVisualStyleBackColor = true;
            this.SearchBook2.Click += new System.EventHandler(this.SearchBook2_Click);
            // 
            // Popular
            // 
            this.Popular.Location = new System.Drawing.Point(968, 17);
            this.Popular.Name = "Popular";
            this.Popular.Size = new System.Drawing.Size(95, 66);
            this.Popular.TabIndex = 13;
            this.Popular.Text = "Просмотреть свои штрафы";
            this.Popular.UseVisualStyleBackColor = true;
            this.Popular.Click += new System.EventHandler(this.Popular_Click);
            // 
            // NotPopular
            // 
            this.NotPopular.Location = new System.Drawing.Point(1069, 17);
            this.NotPopular.Name = "NotPopular";
            this.NotPopular.Size = new System.Drawing.Size(99, 66);
            this.NotPopular.TabIndex = 14;
            this.NotPopular.Text = "Оплатить штраф";
            this.NotPopular.UseVisualStyleBackColor = true;
            this.NotPopular.Click += new System.EventHandler(this.NotPopular_Click);
            // 
            // Reader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1179, 657);
            this.Controls.Add(this.NotPopular);
            this.Controls.Add(this.Popular);
            this.Controls.Add(this.SearchBook2);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.SearchBook1);
            this.Controls.Add(this.NewBooks);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Out_AllBookExmpl);
            this.Name = "Reader";
            this.Text = "Reader";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Out_AllBookExmpl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button NewBooks;
        private System.Windows.Forms.Button SearchBook1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button SearchBook2;
        private System.Windows.Forms.Button Popular;
        private System.Windows.Forms.Button NotPopular;
    }
}