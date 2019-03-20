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
            ((System.ComponentModel.ISupportInitialize)(this.bookInventoryGridView)).BeginInit();
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
            this.lblRowToRemove.Location = new System.Drawing.Point(13, 302);
            this.lblRowToRemove.Name = "lblRowToRemove";
            this.lblRowToRemove.Size = new System.Drawing.Size(181, 13);
            this.lblRowToRemove.TabIndex = 1;
            this.lblRowToRemove.Text = "Введите ID, чтобы удалить запись";
            // 
            // txtRowToRemove
            // 
            this.txtRowToRemove.Location = new System.Drawing.Point(12, 318);
            this.txtRowToRemove.Name = "txtRowToRemove";
            this.txtRowToRemove.Size = new System.Drawing.Size(100, 20);
            this.txtRowToRemove.TabIndex = 2;
            // 
            // btnRemoveRow
            // 
            this.btnRemoveRow.Location = new System.Drawing.Point(119, 316);
            this.btnRemoveRow.Name = "btnRemoveRow";
            this.btnRemoveRow.Size = new System.Drawing.Size(75, 23);
            this.btnRemoveRow.TabIndex = 3;
            this.btnRemoveRow.Text = "Удалить";
            this.btnRemoveRow.UseVisualStyleBackColor = true;
            this.btnRemoveRow.Click += new System.EventHandler(this.btnRemoveRow_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 408);
            this.Controls.Add(this.btnRemoveRow);
            this.Controls.Add(this.txtRowToRemove);
            this.Controls.Add(this.lblRowToRemove);
            this.Controls.Add(this.bookInventoryGridView);
            this.Name = "MainForm";
            this.Text = "Windows Forms Data Binding";
            ((System.ComponentModel.ISupportInitialize)(this.bookInventoryGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView bookInventoryGridView;
        private System.Windows.Forms.Label lblRowToRemove;
        private System.Windows.Forms.TextBox txtRowToRemove;
        private System.Windows.Forms.Button btnRemoveRow;
    }
}

