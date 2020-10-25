namespace C_Sharp_Customizar_DataGridView
{
    partial class frmDataGridView
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
            this.dtgNorthwind = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgNorthwind)).BeginInit();
            this.SuspendLayout();
            // 
            // dtgNorthwind
            // 
            this.dtgNorthwind.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgNorthwind.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgNorthwind.Location = new System.Drawing.Point(0, 0);
            this.dtgNorthwind.Name = "dtgNorthwind";
            this.dtgNorthwind.RowHeadersWidth = 62;
            this.dtgNorthwind.RowTemplate.Height = 28;
            this.dtgNorthwind.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgNorthwind.Size = new System.Drawing.Size(1035, 474);
            this.dtgNorthwind.TabIndex = 2;
            this.dtgNorthwind.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtgNorthwind_CellFormatting);
            this.dtgNorthwind.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dtgNorthwind_RowPostPaint);
            this.dtgNorthwind.Paint += new System.Windows.Forms.PaintEventHandler(this.dtgNorthwind_Paint);
            // 
            // frmDataGridView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 474);
            this.Controls.Add(this.dtgNorthwind);
            this.Name = "frmDataGridView";
            this.Text = "C# - Customizar DataGridView | DB Northwind";
            this.Load += new System.EventHandler(this.frmDataGridView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgNorthwind)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgNorthwind;
    }
}