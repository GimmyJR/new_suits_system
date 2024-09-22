namespace new_suits_system.PL
{
    partial class block
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
            this.dvg_block = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dvg_block)).BeginInit();
            this.SuspendLayout();
            // 
            // dvg_block
            // 
            this.dvg_block.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dvg_block.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dvg_block.Location = new System.Drawing.Point(0, 0);
            this.dvg_block.Name = "dvg_block";
            this.dvg_block.RowHeadersWidth = 51;
            this.dvg_block.RowTemplate.Height = 24;
            this.dvg_block.Size = new System.Drawing.Size(800, 450);
            this.dvg_block.TabIndex = 0;
            this.dvg_block.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // block
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dvg_block);
            this.Name = "block";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dvg_block)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dvg_block;
    }
}