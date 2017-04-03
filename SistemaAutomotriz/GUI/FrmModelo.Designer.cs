namespace frmFramesProyecto.Vista
{
    partial class FrmModelo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmModelo));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tpNuevo = new System.Windows.Forms.ToolStripButton();
            this.tpEditar = new System.Windows.Forms.ToolStripButton();
            this.tpEliminar = new System.Windows.Forms.ToolStripButton();
            this.dtModelo = new System.Windows.Forms.DataGridView();
            this.colIdModelo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDesc_marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDescripcion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtModelo)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tpNuevo,
            this.tpEditar,
            this.tpEliminar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(374, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tpNuevo
            // 
            this.tpNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
           // this.tpNuevo.Image = global::SistemaAutomotriz.Properties.Resources._1489309838_circle_add_plus_new_glyph;
            this.tpNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpNuevo.Name = "tpNuevo";
            this.tpNuevo.Size = new System.Drawing.Size(23, 22);
            this.tpNuevo.Text = "Nuevo Modelo";
            this.tpNuevo.Click += new System.EventHandler(this.tpNuevo_Click);
            // 
            // tpEditar
            // 
            this.tpEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            //this.tpEditar.Image = global::SistemaAutomotriz.Properties.Resources._1489309881_edit2;
            this.tpEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpEditar.Name = "tpEditar";
            this.tpEditar.Size = new System.Drawing.Size(23, 22);
            this.tpEditar.Text = "Editar modelo";
            this.tpEditar.Click += new System.EventHandler(this.tpEditar_Click);
            // 
            // tpEliminar
            // 
            this.tpEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpEliminar.Image = global::SistemaAutomotriz.Properties.Resources._1486712585_trash_bin;
            this.tpEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpEliminar.Name = "tpEliminar";
            this.tpEliminar.Size = new System.Drawing.Size(23, 22);
            this.tpEliminar.Text = "Eliminar modelo";
            this.tpEliminar.Click += new System.EventHandler(this.tpEliminar_Click);
            // 
            // dtModelo
            // 
            this.dtModelo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtModelo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colIdModelo,
            this.colDesc_marca,
            this.colDescripcion});
            this.dtModelo.Location = new System.Drawing.Point(12, 28);
            this.dtModelo.Name = "dtModelo";
            this.dtModelo.ReadOnly = true;
            this.dtModelo.Size = new System.Drawing.Size(348, 221);
            this.dtModelo.TabIndex = 1;
            // 
            // colIdModelo
            // 
            this.colIdModelo.DataPropertyName = "idmodelo";
            this.colIdModelo.HeaderText = "Id Modelo";
            this.colIdModelo.Name = "colIdModelo";
            this.colIdModelo.ReadOnly = true;
            // 
            // colDesc_marca
            // 
            this.colDesc_marca.DataPropertyName = "desc_marca";
            this.colDesc_marca.HeaderText = "Desc. Marca";
            this.colDesc_marca.Name = "colDesc_marca";
            this.colDesc_marca.ReadOnly = true;
            // 
            // colDescripcion
            // 
            this.colDescripcion.DataPropertyName = "descripcion";
            this.colDescripcion.HeaderText = "Descripción";
            this.colDescripcion.Name = "colDescripcion";
            this.colDescripcion.ReadOnly = true;
            // 
            // FrmModelo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(374, 261);
            this.Controls.Add(this.dtModelo);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmModelo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModelo";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtModelo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tpNuevo;
        private System.Windows.Forms.ToolStripButton tpEditar;
        private System.Windows.Forms.ToolStripButton tpEliminar;
        private System.Windows.Forms.DataGridView dtModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colIdModelo;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDesc_marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDescripcion;
    }
}