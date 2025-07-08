
namespace Library
{
    partial class Bibliographer
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
            this.Add_BookExmpl = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Add_edition = new System.Windows.Forms.Button();
            this.output_AllEdition = new System.Windows.Forms.Button();
            this.Delete_edition = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.View1 = new System.Windows.Forms.Button();
            this.Books = new System.Windows.Forms.Button();
            this.Update_edition = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Add_BookExmpl
            // 
            this.Add_BookExmpl.Location = new System.Drawing.Point(12, 12);
            this.Add_BookExmpl.Name = "Add_BookExmpl";
            this.Add_BookExmpl.Size = new System.Drawing.Size(174, 41);
            this.Add_BookExmpl.TabIndex = 0;
            this.Add_BookExmpl.Text = "Добавить книгу";
            this.Add_BookExmpl.UseVisualStyleBackColor = true;
            this.Add_BookExmpl.Click += new System.EventHandler(this.Add_BookExmpl_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 102);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(733, 336);
            this.dataGridView1.TabIndex = 1;
            // 
            // Add_edition
            // 
            this.Add_edition.Location = new System.Drawing.Point(12, 55);
            this.Add_edition.Name = "Add_edition";
            this.Add_edition.Size = new System.Drawing.Size(174, 41);
            this.Add_edition.TabIndex = 2;
            this.Add_edition.Text = "Добавить издание";
            this.Add_edition.UseVisualStyleBackColor = true;
            this.Add_edition.Click += new System.EventHandler(this.Add_edition_Click);
            // 
            // output_AllEdition
            // 
            this.output_AllEdition.Location = new System.Drawing.Point(192, 12);
            this.output_AllEdition.Name = "output_AllEdition";
            this.output_AllEdition.Size = new System.Drawing.Size(97, 84);
            this.output_AllEdition.TabIndex = 3;
            this.output_AllEdition.Text = "Вывод всех изданий";
            this.output_AllEdition.UseVisualStyleBackColor = true;
            this.output_AllEdition.Click += new System.EventHandler(this.output_AllEdition_Click);
            // 
            // Delete_edition
            // 
            this.Delete_edition.Location = new System.Drawing.Point(295, 68);
            this.Delete_edition.Name = "Delete_edition";
            this.Delete_edition.Size = new System.Drawing.Size(174, 28);
            this.Delete_edition.TabIndex = 4;
            this.Delete_edition.Text = "Удалить издание";
            this.Delete_edition.UseVisualStyleBackColor = true;
            this.Delete_edition.Click += new System.EventHandler(this.Delete_edition_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(392, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(77, 23);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(295, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 21);
            this.label1.TabIndex = 6;
            this.label1.Text = "ID издания:";
            // 
            // View1
            // 
            this.View1.Location = new System.Drawing.Point(475, 12);
            this.View1.Name = "View1";
            this.View1.Size = new System.Drawing.Size(270, 52);
            this.View1.TabIndex = 7;
            this.View1.Text = "Кол-во книг определенного издания";
            this.View1.UseVisualStyleBackColor = true;
            this.View1.Click += new System.EventHandler(this.View1_Click);
            // 
            // Books
            // 
            this.Books.Location = new System.Drawing.Point(475, 70);
            this.Books.Name = "Books";
            this.Books.Size = new System.Drawing.Size(270, 26);
            this.Books.TabIndex = 8;
            this.Books.Text = "Книги";
            this.Books.UseVisualStyleBackColor = true;
            this.Books.Click += new System.EventHandler(this.Books_Click);
            // 
            // Update_edition
            // 
            this.Update_edition.Location = new System.Drawing.Point(295, 36);
            this.Update_edition.Name = "Update_edition";
            this.Update_edition.Size = new System.Drawing.Size(174, 28);
            this.Update_edition.TabIndex = 9;
            this.Update_edition.Text = "Изменить издание";
            this.Update_edition.UseVisualStyleBackColor = true;
            this.Update_edition.Click += new System.EventHandler(this.Update_edition_Click);
            // 
            // Bibliographer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(757, 450);
            this.Controls.Add(this.Update_edition);
            this.Controls.Add(this.Books);
            this.Controls.Add(this.View1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.Delete_edition);
            this.Controls.Add(this.output_AllEdition);
            this.Controls.Add(this.Add_edition);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Add_BookExmpl);
            this.Name = "Bibliographer";
            this.Text = "Bibliographer";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Add_BookExmpl;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button Add_edition;
        private System.Windows.Forms.Button output_AllEdition;
        private System.Windows.Forms.Button Delete_edition;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button View1;
        private System.Windows.Forms.Button Books;
        private System.Windows.Forms.Button Update_edition;
    }
}