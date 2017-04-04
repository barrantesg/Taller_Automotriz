namespace GUI
{
    partial class FrmCliente
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmCliente));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tpNuevo = new System.Windows.Forms.ToolStripButton();
            this.tpEditar = new System.Windows.Forms.ToolStripButton();
            this.tpEliminar = new System.Windows.Forms.ToolStripButton();
            this.tpRefrescar = new System.Windows.Forms.ToolStripButton();
            this.dtCliente = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCliente)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tpNuevo,
            this.tpEditar,
            this.tpEliminar,
            this.tpRefrescar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(985, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tpNuevo
            // 
            this.tpNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpNuevo.Image = global::SistemaAutomotriz.Properties.Resources._1486713005_add_user;
            this.tpNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpNuevo.Name = "tpNuevo";
            this.tpNuevo.Size = new System.Drawing.Size(23, 22);
            this.tpNuevo.Text = "Nuevo";
            this.tpNuevo.Click += new System.EventHandler(this.tpNuevo_Click);
            // 
            // tpEditar
            // 
            this.tpEditar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpEditar.Image = global::SistemaAutomotriz.Properties.Resources._1486712785_user_profile_edit;
            this.tpEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpEditar.Name = "tpEditar";
            this.tpEditar.Size = new System.Drawing.Size(23, 22);
            this.tpEditar.Text = "Editar";
            this.tpEditar.Click += new System.EventHandler(this.tpEditar_Click);
            // 
            // tpEliminar
            // 
            this.tpEliminar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpEliminar.Image = global::SistemaAutomotriz.Properties.Resources._1486712585_trash_bin;
            this.tpEliminar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpEliminar.Name = "tpEliminar";
            this.tpEliminar.Size = new System.Drawing.Size(23, 22);
            this.tpEliminar.Text = "Eliminar";
            this.tpEliminar.Click += new System.EventHandler(this.tpEliminar_Click);
            // 
            // tpRefrescar
            // 
            this.tpRefrescar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tpRefrescar.Image = global::SistemaAutomotriz.Properties.Resources._1486506487_refresh;
            this.tpRefrescar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tpRefrescar.Name = "tpRefrescar";
            this.tpRefrescar.Size = new System.Drawing.Size(23, 22);
            this.tpRefrescar.Text = "Refrescar";
            this.tpRefrescar.Click += new System.EventHandler(this.tpRefrescar_Click);
            // 
            // dtCliente
            // 
            this.dtCliente.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtCliente.Location = new System.Drawing.Point(0, 28);
            this.dtCliente.Name = "dtCliente";
            this.dtCliente.ReadOnly = true;
            this.dtCliente.Size = new System.Drawing.Size(982, 306);
            this.dtCliente.TabIndex = 1;
            this.dtCliente.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtCliente_CellContentClick);
            // 
            // FrmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 337);
            this.Controls.Add(this.dtCliente);
            this.Controls.Add(this.toolStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FrmCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cliente";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtCliente)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tpNuevo;
        private System.Windows.Forms.ToolStripButton tpEditar;
        private System.Windows.Forms.ToolStripButton tpEliminar;
        private System.Windows.Forms.ToolStripButton tpRefrescar;
        private System.Windows.Forms.DataGridView dtCliente;
    }
}