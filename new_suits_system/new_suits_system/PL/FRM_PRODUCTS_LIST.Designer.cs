namespace new_suits_system.PL
{
    partial class FRM_PRODUCTS_LIST
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
            this.dgv_products_list = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products_list)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_products_list
            // 
            this.dgv_products_list.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_products_list.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_products_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_products_list.Location = new System.Drawing.Point(0, 0);
            this.dgv_products_list.Margin = new System.Windows.Forms.Padding(4);
            this.dgv_products_list.MultiSelect = false;
            this.dgv_products_list.Name = "dgv_products_list";
            this.dgv_products_list.ReadOnly = true;
            this.dgv_products_list.RowHeadersWidth = 51;
            this.dgv_products_list.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_products_list.Size = new System.Drawing.Size(1067, 554);
            this.dgv_products_list.TabIndex = 0;
            this.dgv_products_list.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_products_list_CellContentClick);
            this.dgv_products_list.DoubleClick += new System.EventHandler(this.dgv_products_list_DoubleClick);
            // 
            // FRM_PRODUCTS_LIST
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.dgv_products_list);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FRM_PRODUCTS_LIST";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لائحة جميع المنتجات";
            this.Load += new System.EventHandler(this.FRM_PRODUCTS_LIST_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_products_list)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgv_products_list;
    }
}