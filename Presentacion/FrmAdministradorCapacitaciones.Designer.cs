namespace Presentacion
{
    partial class FrmAdministradorCapacitaciones
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdministradorCapacitaciones));
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAgregarColaborador = new System.Windows.Forms.Button();
            this.btnConsultarLista = new System.Windows.Forms.Button();
            this.btnBuscarColaborador = new System.Windows.Forms.Button();
            this.btnNuevaCapacitacion = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnLogOut = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel1.Controls.Add(this.btnLogOut);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1408, 78);
            this.panel1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.DarkGreen;
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBox1.Controls.Add(this.btnNuevaCapacitacion);
            this.groupBox1.Controls.Add(this.btnBuscarColaborador);
            this.groupBox1.Controls.Add(this.btnConsultarLista);
            this.groupBox1.Controls.Add(this.btnAgregarColaborador);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.groupBox1.Location = new System.Drawing.Point(0, 78);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(274, 596);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // btnAgregarColaborador
            // 
            this.btnAgregarColaborador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarColaborador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAgregarColaborador.Location = new System.Drawing.Point(6, 116);
            this.btnAgregarColaborador.Name = "btnAgregarColaborador";
            this.btnAgregarColaborador.Size = new System.Drawing.Size(262, 35);
            this.btnAgregarColaborador.TabIndex = 0;
            this.btnAgregarColaborador.Text = "Agregar nuevos colaboradores";
            this.btnAgregarColaborador.UseVisualStyleBackColor = true;
            // 
            // btnConsultarLista
            // 
            this.btnConsultarLista.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsultarLista.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnConsultarLista.Location = new System.Drawing.Point(6, 186);
            this.btnConsultarLista.Name = "btnConsultarLista";
            this.btnConsultarLista.Size = new System.Drawing.Size(262, 35);
            this.btnConsultarLista.TabIndex = 1;
            this.btnConsultarLista.Text = "Consultar lista de colaboradores\r\n";
            this.btnConsultarLista.UseVisualStyleBackColor = true;
            // 
            // btnBuscarColaborador
            // 
            this.btnBuscarColaborador.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscarColaborador.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBuscarColaborador.Location = new System.Drawing.Point(6, 254);
            this.btnBuscarColaborador.Name = "btnBuscarColaborador";
            this.btnBuscarColaborador.Size = new System.Drawing.Size(262, 35);
            this.btnBuscarColaborador.TabIndex = 2;
            this.btnBuscarColaborador.Text = "Buscar un colaborador";
            this.btnBuscarColaborador.UseVisualStyleBackColor = true;
            // 
            // btnNuevaCapacitacion
            // 
            this.btnNuevaCapacitacion.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevaCapacitacion.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNuevaCapacitacion.Location = new System.Drawing.Point(6, 320);
            this.btnNuevaCapacitacion.Name = "btnNuevaCapacitacion";
            this.btnNuevaCapacitacion.Size = new System.Drawing.Size(262, 35);
            this.btnNuevaCapacitacion.TabIndex = 3;
            this.btnNuevaCapacitacion.Text = "Nueva capacitación";
            this.btnNuevaCapacitacion.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.BackgroundImage = global::Presentacion.Properties.Resources._339_3396821_png_file_svg_download_icon_logout_transparent_png;
            this.panel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel2.Location = new System.Drawing.Point(1245, 20);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(30, 32);
            this.panel2.TabIndex = 4;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel3.BackgroundImage = global::Presentacion.Properties.Resources.RedLine_logo;
            this.panel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(152, 72);
            this.panel3.TabIndex = 1;
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.LightGray;
            this.btnLogOut.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(1281, 20);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(94, 32);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // FrmAdministradorCapacitaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(1408, 674);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmAdministradorCapacitaciones";
            this.Text = "FrmAdministradorCapacitaciones";
            this.Load += new System.EventHandler(this.FrmAdministradorCapacitaciones_Load);
            this.panel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnNuevaCapacitacion;
        private System.Windows.Forms.Button btnBuscarColaborador;
        private System.Windows.Forms.Button btnConsultarLista;
        private System.Windows.Forms.Button btnAgregarColaborador;
        private System.Windows.Forms.Button btnLogOut;
    }
}