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
            this.gbLookUpStoreOrder = new System.Windows.Forms.GroupBox();
            this.lblStoreId = new System.Windows.Forms.Label();
            this.txtStoreId = new System.Windows.Forms.TextBox();
            this.btnGetOrderInfo = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.inventoryGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.storesGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ordersGridView)).BeginInit();
            this.gbLookUpStoreOrder.SuspendLayout();
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
            // gbLookUpStoreOrder
            // 
            this.gbLookUpStoreOrder.Controls.Add(this.btnGetOrderInfo);
            this.gbLookUpStoreOrder.Controls.Add(this.txtStoreId);
            this.gbLookUpStoreOrder.Controls.Add(this.lblStoreId);
            this.gbLookUpStoreOrder.Location = new System.Drawing.Point(12, 519);
            this.gbLookUpStoreOrder.Name = "gbLookUpStoreOrder";
            this.gbLookUpStoreOrder.Size = new System.Drawing.Size(169, 118);
            this.gbLookUpStoreOrder.TabIndex = 7;
            this.gbLookUpStoreOrder.TabStop = false;
            this.gbLookUpStoreOrder.Text = "Поиск заказа в магазине";
            // 
            // lblStoreId
            // 
            this.lblStoreId.AutoSize = true;
            this.lblStoreId.Location = new System.Drawing.Point(6, 31);
            this.lblStoreId.Name = "lblStoreId";
            this.lblStoreId.Size = new System.Drawing.Size(49, 13);
            this.lblStoreId.TabIndex = 0;
            this.lblStoreId.Text = "Store ID:";
            // 
            // txtStoreId
            // 
            this.txtStoreId.Location = new System.Drawing.Point(61, 28);
            this.txtStoreId.Name = "txtStoreId";
            this.txtStoreId.Size = new System.Drawing.Size(102, 20);
            this.txtStoreId.TabIndex = 1;
            // 
            // btnGetOrderInfo
            // 
            this.btnGetOrderInfo.Location = new System.Drawing.Point(61, 54);
            this.btnGetOrderInfo.Name = "btnGetOrderInfo";
            this.btnGetOrderInfo.Size = new System.Drawing.Size(102, 58);
            this.btnGetOrderInfo.TabIndex = 2;
            this.btnGetOrderInfo.Text = "Получить информацию о заказе";
            this.btnGetOrderInfo.UseVisualStyleBackColor = true;
            this.btnGetOrderInfo.Click += new System.EventHandler(this.btnGetOrderInfo_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(563, 646);
            this.Controls.Add(this.gbLookUpStoreOrder);
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
            this.gbLookUpStoreOrder.ResumeLayout(false);
            this.gbLookUpStoreOrder.PerformLayout();
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
        private System.Windows.Forms.GroupBox gbLookUpStoreOrder;
        private System.Windows.Forms.Button btnGetOrderInfo;
        private System.Windows.Forms.TextBox txtStoreId;
        private System.Windows.Forms.Label lblStoreId;
    }
}

