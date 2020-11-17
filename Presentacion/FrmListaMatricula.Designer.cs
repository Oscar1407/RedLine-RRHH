namespace Presentacion
{
    partial class FrmListaMatricula
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmListaMatricula));
            this.btnLogOut = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.PanelCapacitaciones = new System.Windows.Forms.Panel();
            this.dtgMatricula = new System.Windows.Forms.DataGridView();
            this.txtIDCurso = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblSubT = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnContraDesp = new System.Windows.Forms.Button();
            this.btnCapacitaciones = new System.Windows.Forms.Button();
            this.btnGestion = new System.Windows.Forms.Button();
            this.btnNomina = new System.Windows.Forms.Button();
            this.pnlTitulo = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBoxInsta = new System.Windows.Forms.PictureBox();
            this.pictureBoxFace = new System.Windows.Forms.PictureBox();
            this.PanelCapacitaciones.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatricula)).BeginInit();
            this.pnlMenu.SuspendLayout();
            this.pnlTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).BeginInit();
            this.SuspendLayout();
            // 
            // btnLogOut
            // 
            this.btnLogOut.BackColor = System.Drawing.Color.White;
            this.btnLogOut.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogOut.Location = new System.Drawing.Point(724, 10);
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(94, 32);
            this.btnLogOut.TabIndex = 5;
            this.btnLogOut.Text = "Log Out";
            this.btnLogOut.UseVisualStyleBackColor = false;
            this.btnLogOut.Click += new System.EventHandler(this.btnLogOut_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(61)))));
            this.btnRegresar.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegresar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRegresar.Location = new System.Drawing.Point(12, 406);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(130, 35);
            this.btnRegresar.TabIndex = 1;
            this.btnRegresar.Text = "Volver al menú";
            this.btnRegresar.UseVisualStyleBackColor = false;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // PanelCapacitaciones
            // 
            this.PanelCapacitaciones.BackColor = System.Drawing.SystemColors.ControlDark;
            this.PanelCapacitaciones.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.PanelCapacitaciones.Controls.Add(this.label1);
            this.PanelCapacitaciones.Controls.Add(this.btnRegresar);
            this.PanelCapacitaciones.Controls.Add(this.dtgMatricula);
            this.PanelCapacitaciones.Controls.Add(this.txtIDCurso);
            this.PanelCapacitaciones.Controls.Add(this.label2);
            this.PanelCapacitaciones.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelCapacitaciones.Location = new System.Drawing.Point(0, 188);
            this.PanelCapacitaciones.Name = "PanelCapacitaciones";
            this.PanelCapacitaciones.Size = new System.Drawing.Size(970, 478);
            this.PanelCapacitaciones.TabIndex = 7;
            // 
            // dtgMatricula
            // 
            this.dtgMatricula.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.dtgMatricula.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgMatricula.Location = new System.Drawing.Point(12, 101);
            this.dtgMatricula.Name = "dtgMatricula";
            this.dtgMatricula.Size = new System.Drawing.Size(944, 269);
            this.dtgMatricula.TabIndex = 16;
            // 
            // txtIDCurso
            // 
            this.txtIDCurso.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtIDCurso.Location = new System.Drawing.Point(84, 64);
            this.txtIDCurso.Name = "txtIDCurso";
            this.txtIDCurso.Size = new System.Drawing.Size(150, 26);
            this.txtIDCurso.TabIndex = 15;
            this.txtIDCurso.TextChanged += new System.EventHandler(this.txtIDCurso_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(9, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "ID Curso";
            // 
            // lblSubT
            // 
            this.lblSubT.AutoSize = true;
            this.lblSubT.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubT.Location = new System.Drawing.Point(401, 145);
            this.lblSubT.Name = "lblSubT";
            this.lblSubT.Size = new System.Drawing.Size(158, 27);
            this.lblSubT.TabIndex = 13;
            this.lblSubT.Text = "Capacitaciones";
            // 
            // pnlMenu
            // 
            this.pnlMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(61)))));
            this.pnlMenu.Controls.Add(this.btnLogOut);
            this.pnlMenu.Controls.Add(this.btnContraDesp);
            this.pnlMenu.Controls.Add(this.btnCapacitaciones);
            this.pnlMenu.Controls.Add(this.btnGestion);
            this.pnlMenu.Controls.Add(this.btnNomina);
            this.pnlMenu.Location = new System.Drawing.Point(0, 62);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(970, 57);
            this.pnlMenu.TabIndex = 12;
            // 
            // btnContraDesp
            // 
            this.btnContraDesp.BackColor = System.Drawing.Color.White;
            this.btnContraDesp.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnContraDesp.Location = new System.Drawing.Point(379, 16);
            this.btnContraDesp.Name = "btnContraDesp";
            this.btnContraDesp.Size = new System.Drawing.Size(195, 27);
            this.btnContraDesp.TabIndex = 3;
            this.btnContraDesp.Text = "Contrataciones y despidos";
            this.btnContraDesp.UseVisualStyleBackColor = false;
            // 
            // btnCapacitaciones
            // 
            this.btnCapacitaciones.BackColor = System.Drawing.Color.White;
            this.btnCapacitaciones.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapacitaciones.Location = new System.Drawing.Point(251, 16);
            this.btnCapacitaciones.Name = "btnCapacitaciones";
            this.btnCapacitaciones.Size = new System.Drawing.Size(122, 27);
            this.btnCapacitaciones.TabIndex = 2;
            this.btnCapacitaciones.Text = "Capacitaciones";
            this.btnCapacitaciones.UseVisualStyleBackColor = false;
            // 
            // btnGestion
            // 
            this.btnGestion.BackColor = System.Drawing.Color.White;
            this.btnGestion.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGestion.Location = new System.Drawing.Point(98, 16);
            this.btnGestion.Name = "btnGestion";
            this.btnGestion.Size = new System.Drawing.Size(147, 27);
            this.btnGestion.TabIndex = 1;
            this.btnGestion.Text = "Gestión de trabajo";
            this.btnGestion.UseVisualStyleBackColor = false;
            // 
            // btnNomina
            // 
            this.btnNomina.BackColor = System.Drawing.Color.White;
            this.btnNomina.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNomina.Location = new System.Drawing.Point(12, 16);
            this.btnNomina.Name = "btnNomina";
            this.btnNomina.Size = new System.Drawing.Size(80, 26);
            this.btnNomina.TabIndex = 0;
            this.btnNomina.Text = "Nómina";
            this.btnNomina.UseVisualStyleBackColor = false;
            // 
            // pnlTitulo
            // 
            this.pnlTitulo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(61)))));
            this.pnlTitulo.Controls.Add(this.lblTitulo);
            this.pnlTitulo.Controls.Add(this.pictureBox1);
            this.pnlTitulo.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTitulo.Location = new System.Drawing.Point(0, 0);
            this.pnlTitulo.Name = "pnlTitulo";
            this.pnlTitulo.Size = new System.Drawing.Size(970, 56);
            this.pnlTitulo.TabIndex = 11;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.ForeColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Location = new System.Drawing.Point(219, 9);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(289, 40);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Recursos Humanos";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Presentacion.Properties.Resources.RedLine_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(103, 56);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(335, 27);
            this.label1.TabIndex = 17;
            this.label1.Text = "Lista de matriculados en un curso";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(96)))), ((int)(((byte)(61)))));
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBoxInsta);
            this.panel2.Controls.Add(this.pictureBoxFace);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 661);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(970, 92);
            this.panel2.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Arial Rounded MT Bold", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.label9.Location = new System.Drawing.Point(375, 33);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(262, 24);
            this.label9.TabIndex = 2;
            this.label9.Text = "www.RedLine.ac.cr.com";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::Presentacion.Properties.Resources.twit;
            this.pictureBox2.Location = new System.Drawing.Point(127, 21);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(53, 50);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBoxInsta
            // 
            this.pictureBoxInsta.Image = global::Presentacion.Properties.Resources.insta1;
            this.pictureBoxInsta.Location = new System.Drawing.Point(71, 21);
            this.pictureBoxInsta.Name = "pictureBoxInsta";
            this.pictureBoxInsta.Size = new System.Drawing.Size(50, 49);
            this.pictureBoxInsta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInsta.TabIndex = 1;
            this.pictureBoxInsta.TabStop = false;
            // 
            // pictureBoxFace
            // 
            this.pictureBoxFace.Image = global::Presentacion.Properties.Resources.face;
            this.pictureBoxFace.Location = new System.Drawing.Point(12, 20);
            this.pictureBoxFace.Name = "pictureBoxFace";
            this.pictureBoxFace.Size = new System.Drawing.Size(53, 50);
            this.pictureBoxFace.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxFace.TabIndex = 0;
            this.pictureBoxFace.TabStop = false;
            // 
            // FrmListaMatricula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(970, 753);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblSubT);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlTitulo);
            this.Controls.Add(this.PanelCapacitaciones);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmListaMatricula";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Lista de matriculas";
            this.Load += new System.EventHandler(this.FrmListaMatricula_Load);
            this.PanelCapacitaciones.ResumeLayout(false);
            this.PanelCapacitaciones.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgMatricula)).EndInit();
            this.pnlMenu.ResumeLayout(false);
            this.pnlTitulo.ResumeLayout(false);
            this.pnlTitulo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInsta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFace)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnLogOut;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Panel PanelCapacitaciones;
        private System.Windows.Forms.DataGridView dtgMatricula;
        private System.Windows.Forms.TextBox txtIDCurso;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubT;
        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button btnContraDesp;
        private System.Windows.Forms.Button btnCapacitaciones;
        private System.Windows.Forms.Button btnGestion;
        private System.Windows.Forms.Button btnNomina;
        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBoxInsta;
        private System.Windows.Forms.PictureBox pictureBoxFace;
    }
}