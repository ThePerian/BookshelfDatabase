namespace WinFormsDataBinding
{
    partial class MainForm
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
            this.bookInventoryGridView = new System.Windows.Forms.DataGridView();
            this.lblRowToRemove = new System.Windows.Forms.Label();
            this.txtRowToRemove = new System.Windows.Forms.TextBox();
            this.btnRemoveRow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnDisplayAuthor = new System.Windows.Forms.Button();
            this.txtAuthorToView = new System.Windows.Forms.TextBox();
            this.lblAuthorToView = new System.Windows.Forms.Label();
            this.btnChangeReads = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bookInventoryGridView)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bookInventoryGridView
            // 
            this.bookInventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.bookInventoryGridView.Location = new System.Drawing.Point(12, 12);
            this.bookInventoryGridView.Name = "bookInventoryGridView";
            this.bookInventoryGridView.Size = new System.Drawing.Size(558, 283);
            this.bookInventoryGridView.TabIndex = 0;
            // 
            // lblRowToRemove
            // 
            this.lblRowToRemove.AutoSize = true;
            this.lblRowToRemove.Location = new System.Drawing.Point(3, 0);
            this.lblRowToRemove.Name = "lblRowToRemove";
            this.lblRowToRemove.Size = new System.Drawing.Size(181, 13);
            this.lblRowToRemove.TabIndex = 1;
            this.lblRowToRemove.Text = "Введите ID, чтобы удалить запись";
            // 
            // txtRowToRemove
            // 
            this.txtRowToRemove.Location = new System.Drawing.Point(3, 16);
            this.txtRowToRemove.Name = "txtRowToRemove";
            this.txtRowToRemove.Size = new System.Drawing.Size(100, 20);
            this.txtRowToRemove.TabIndex = 2;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(109, 14);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRow.TabIndex = 3;
            this.btnRemoveRow.Text = "Удалить";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lblRowToRemove);
            this.panel1.Controls.Add(this.btnRemoveRow);
            this.panel1.Controls.Add(this.txtRowToRemove);
            this.panel1.Location = new System.Drawing.Point(12, 301);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 66);
            this.panel1.TabIndex = 4;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnDisplayAuthor);
            this.panel2.Controls.Add(this.txtAuthorToView);
            this.panel2.Controls.Add(this.lblAuthorToView);
            this.panel2.Location = new System.Drawing.Point(218, 301);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 66);
            this.panel2.TabIndex = 5;
            // 
            // btnDisplayAuthor
            // 
            this.btnDisplayAuthor.Location = new System.Drawing.Point(112, 14);
            this.btnDisplayAuthor.Name = "btnDisplayAuthor";
            this.btnDisplayAuthor.Size = new System.Drawing.Size(75, 23);
            this.btnDisplayAuthor.TabIndex = 2;
            this.btnDisplayAuthor.Text = "Показать";
            this.btnDisplayAuthor.UseVisualStyleBackColor = true;
            this.btnDisplayAuthor.Click += new System.EventHandler(this.btnDisplayAuthor_Click);
            // 
            // txtAuthorToView
            // 
            this.txtAuthorToView.Location = new System.Drawing.Point(6, 16);
            this.txtAuthorToView.Name = "txtAuthorToView";
            this.txtAuthorToView.Size = new System.Drawing.Size(100, 20);
            this.txtAuthorToView.TabIndex = 1;
            // 
            // lblAuthorToView
            // 
            this.lblAuthorToView.AutoSize = true;
            this.lblAuthorToView.Location = new System.Drawing.Point(3, 0);
            this.lblAuthorToView.Name = "lblAuthorToView";
            this.lblAuthorToView.Size = new System.Drawing.Size(153, 13);
            this.lblAuthorToView.TabIndex = 0;
            this.lblAuthorToView.Text = "Поиск книг по имени автора";
            // 
            // btnChangeReads
            // 
            this.btnChangeReads.Location = new System.Drawing.Point(424, 314);
            this.btnChangeReads.Name = "btnChangeReads";
            this.btnChangeReads.Size = new System.Drawing.Size(146, 42);
            this.btnChangeReads.TabIndex = 6;
            this.btnChangeReads.Text = "Отметить все как прочитанное";
            this.btnChangeReads.UseVisualStyleBackColor = true;
            this.btnChangeReads.Click += new System.EventHandler(this.btnChangeReads_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 408);
            this.Controls.Add(this.btnChangeReads);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bookInventoryGridView);
            this.Name = "MainForm";
            this.Text = "Windows Forms Data Binding";
            ((System.ComponentModel.ISupportInitialize)(this.bookInventoryGridView)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView bookInventoryGridView;
        private System.Windows.Forms.Label lblRowToRemove;
        private System.Windows.Forms.TextBox txtRowToRemove;
        private System.Windows.Forms.Button btnRemoveRow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDisplayAuthor;
        private System.Windows.Forms.TextBox txtAuthorToView;
        private System.Windows.Forms.Label lblAuthorToView;
        private System.Windows.Forms.Button btnChangeReads;
    }
}

