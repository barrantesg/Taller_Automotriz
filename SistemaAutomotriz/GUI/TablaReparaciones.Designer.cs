namespace SistemaAutomotriz.GUI
{
    partial class TablaReparaciones
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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tpNuevo = new System.Windows.Forms.ToolStripButton();
            this.tpEditar = new System.Windows.Forms.ToolStripButton();
            this.tpEliminar = new System.Windows.Forms.ToolStripButton();
            this.dtReparacion = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtReparacion)).BeginInit();
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
            this.toolStrip1.Size = new System.Drawing.Size(532, 25);
            this.toolStrip1.TabIndex = 4;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tpNuevo
            // 
            this.tpNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpNuevo.Name = "tpNuevo";
            this.tpNuevo.Size = new System.Drawing.Size(90, 22);
            this.tpNuevo.Text = "Nuevo Modelo";
            this.tpNuevo.Click += new System.EventHandler(this.tpNuevo_Click);
            // 
            // tpEditar
            // 
            this.tpEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpEditar.Name = "tpEditar";
            this.tpEditar.Size = new System.Drawing.Size(85, 22);
            this.tpEditar.Text = "Editar modelo";
            this.tpEditar.Click += new System.EventHandler(this.tpEditar_Click);
            // 
            // tpEliminar
            // 
            this.tpEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpEliminar.Name = "tpEliminar";
            this.tpEliminar.Size = new System.Drawing.Size(98, 22);
            this.tpEliminar.Text = "Eliminar modelo";
            this.tpEliminar.Click += new System.EventHandler(this.tpEliminar_Click);
            // 
            // dtReparacion
            // 
            this.dtReparacion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtReparacion.Location = new System.Drawing.Point(12, 39);
            this.dtReparacion.Name = "dtReparacion";
            this.dtReparacion.ReadOnly = true;
            this.dtReparacion.Size = new System.Drawing.Size(508, 266);
            this.dtReparacion.TabIndex = 3;
            // 
            // TablaReparaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(532, 317);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.dtReparacion);
            this.Name = "TablaReparaciones";
            this.Text = "TablaReparaciones";
            this.Load += new System.EventHandler(this.TablaReparaciones_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtReparacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tpNuevo;
        private System.Windows.Forms.ToolStripButton tpEditar;
        private System.Windows.Forms.ToolStripButton tpEliminar;
        private System.Windows.Forms.DataGridView dtReparacion;
    }
}