using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Presentacion
{
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            try
            {
                FrmLogin login = new FrmLogin();

                login.padre(this);

                login.ShowDialog();

                login.Close();

                login.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Debe completar los campos", "Proceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
