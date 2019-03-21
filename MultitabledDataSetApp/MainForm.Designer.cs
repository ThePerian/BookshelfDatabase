namespace MultitabledDataSetApp
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
            this.lblInventory = new System.Windows.Forms.Label();
            this.inventoryGridView = new System.Windows.Forms.DataGridView();
            this.lblStores = new System.Windows.Forms.Label();
            this.storesGridView = new System.Windows.Forms.DataGridView();
            this.lblOrders = new System.Windows.Forms.Label();
            this.ordersGridView = new System.Windows.Forms.DataGridView();
            this.btnUpdateDatabase = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblInventory
            // 
            this.lblInventory.AutoSize = true;
            this.lblInventory.Location = new System.Drawing.Point(12, 9);
            this.lblInventory.Name = "lblInventory";
            this.lblInventory.Size = new System.Drawing.Size(119, 13);
            this.lblInventory.TabIndex = 0;
            this.lblInventory.Text = "Текущее содержимое";
            // 
            // inventoryGridView
            // 
            this.inventoryGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.inventoryGridView.Location = new System.Drawing.Point(12, 25);
            this.inventoryGridView.Name = "inventoryGridView";
            this.inventoryGridView.Size = new System.Drawing.Size(539, 150);
            this.inventoryGridView.TabIndex = 1;
            // 
            // lblStores
            // 
            this.lblStores.AutoSize = true;
            this.lblStores.Location = new System.Drawing.Point(9, 178);
            this.lblStores.Name = "lblStores";
            this.lblStores.Size = new System.Drawing.Size(59, 13);
            this.lblStores.TabIndex = 2;
            this.lblStores.Text = "Магазины";
            // 
            // storesGridView
            // 
            this.storesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.storesGridView.Location = new System.Drawing.Point(12, 194);
            this.storesGridView.Name = "storesGridView";
            this.storesGridView.Size = new System.Drawing.Size(539, 150);
            this.storesGridView.TabIndex = 3;
            // 
            // lblOrders
            // 
            this.lblOrders.AutoSize = true;
            this.lblOrders.Location = new System.Drawing.Point(12, 347);
            this.lblOrders.Name = "lblOrders";
            this.lblOrders.Size = new System.Drawing.Size(46, 13);
            this.lblOrders.TabIndex = 4;
            this.lblOrders.Text = "Заказы";
            // 
            // ordersGridView
            // 
            this.ordersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ordersGridView.Location = new System.Drawing.Point(12, 363);
            this.ordersGridView.Name = "ordersGridView";
            this.ordersGridView.Size = new System.Drawing.Size(539, 150);
            this.ordersGridView.TabIndex = 5;
            // 
            // btnUpdateDatabase
            // 
            this.btnUpdateDatabase.Location = new System.Drawing.Point(390, 519);
            this.btnUpdateDatabase.Name = "btnUpdateDatabase";
            this.btnUpdateDatabase.Size = new System.Drawing.Size(161, 23);
            this.btnUpdateDatabase.TabIndex = 6;
            this.btnUpdateDatabase.Text = "Обновить базу данных";
            this.btnUpdateDatabase.UseVisualStyleBackColor = true;
            this.btnUpdateDatabase.Click += new System.EventHandler(this.btnUpdateDatabase_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 548);
            this.Controls.Add(this.btnUpdateDatabase);
            this.Controls.Add(this.ordersGridView);
            this.Controls.Add(this.lblOrders);
            this.Controls.Add(this.storesGridView);
            this.Controls.Add(this.lblStores);
            this.Controls.Add(this.inventoryGridView);
            this.Controls.Add(this.lblInventory);
            this.Name = "MainForm";
            this.Text = "База данных Bookshelf";
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInventory;
        private System.Windows.Forms.DataGridView inventoryGridView;
        private System.Windows.Forms.Label lblStores;
        private System.Windows.Forms.DataGridView storesGridView;
        private System.Windows.Forms.Label lblOrders;
        private System.Windows.Forms.DataGridView ordersGridView;
        private System.Windows.Forms.Button btnUpdateDatabase;
    }
}

