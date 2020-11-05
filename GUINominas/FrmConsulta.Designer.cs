namespace GUINominas
{
    partial class FrmConsulta
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
            this.dtempleados = new System.Windows.Forms.DataGridView();
            this.BtnConsultar = new System.Windows.Forms.Button();
            this.TxtBusqueda = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtempleados)).BeginInit();
            this.SuspendLayout();
            // 
            // dtempleados
            // 
            this.dtempleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtempleados.Location = new System.Drawing.Point(12, 92);
            this.dtempleados.Name = "dtempleados";
            this.dtempleados.Size = new System.Drawing.Size(639, 199);
            this.dtempleados.TabIndex = 0;
            this.dtempleados.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtempleados_CellDoubleClick);
            // 
            // BtnConsultar
            // 
            this.BtnConsultar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnConsultar.Image = global::GUINominas.Properties.Resources.icons8_mostrar_propiedad_30;
            this.BtnConsultar.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.BtnConsultar.Location = new System.Drawing.Point(494, 297);
            this.BtnConsultar.Name = "BtnConsultar";
            this.BtnConsultar.Size = new System.Drawing.Size(157, 38);
            this.BtnConsultar.TabIndex = 1;
            this.BtnConsultar.Text = "CONSULTAR";
            this.BtnConsultar.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.BtnConsultar.UseVisualStyleBackColor = true;
            this.BtnConsultar.Click += new System.EventHandler(this.BtnConsultar_Click);
            // 
            // TxtBusqueda
            // 
            this.TxtBusqueda.Location = new System.Drawing.Point(12, 55);
            this.TxtBusqueda.Name = "TxtBusqueda";
            this.TxtBusqueda.Size = new System.Drawing.Size(194, 20);
            this.TxtBusqueda.TabIndex = 2;
            this.TxtBusqueda.TextChanged += new System.EventHandler(this.TxtBusqueda_TextChanged);
            // 
            // FrmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 347);
            this.Controls.Add(this.TxtBusqueda);
            this.Controls.Add(this.BtnConsultar);
            this.Controls.Add(this.dtempleados);
            this.Name = "FrmConsulta";
            this.Text = "FrmConsulta";
            ((System.ComponentModel.ISupportInitialize)(this.dtempleados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtempleados;
        private System.Windows.Forms.Button BtnConsultar;
        private System.Windows.Forms.TextBox TxtBusqueda;
    }
}