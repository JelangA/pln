namespace pe_el_en
{
    partial class tampilData
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
            this.tabel = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.tabel)).BeginInit();
            this.SuspendLayout();
            // 
            // tabel
            // 
            this.tabel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.tabel.Location = new System.Drawing.Point(34, 93);
            this.tabel.Name = "tabel";
            this.tabel.RowTemplate.Height = 25;
            this.tabel.Size = new System.Drawing.Size(739, 184);
            this.tabel.TabIndex = 0;
            this.tabel.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // tampilData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabel);
            this.Name = "tampilData";
            this.Text = "tampilData";
            this.Load += new System.EventHandler(this.tampilData_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView tabel;
    }
}