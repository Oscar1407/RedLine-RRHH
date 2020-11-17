using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Colaborador
    {
        double deduccion { set; get; }

        public string IDInstitucional { set; get; }

        public string cedula { set; get; }

        public string nombre { set; get; }

        public string primerApellido { set; get; }

        public string segundoApellido { set; get; }

        public string correo { set; get; }

        public string correoSecundario { set; get; }

        public string telefono { set; get; }

        public string telefonoSecundario { set; get; }

        public string puestoTrabajo { get; set; }

        public double SalarioBruto { get; set; }

        public double SalarioNeto { set; get; }

        public string direccion { set; get; }

        public string tipoHorario { set; get; }

        public double aguinaldoNeto { set; get; }
        
        public double aguinaldoBruto { set; get; }

        public double salarioBruto(string puesto)
        {
            double salario = 0.0;

            if (puesto.Equals("Administracion de bases de datos"))
            {
                salario = 500000.0;
            } else if (puesto.Equals("Desarrollador Junior"))
            {
                salario = 350000.0;
            }
            else if (puesto.Equals("Analista de sistemas"))
            {
                salario = 400000.0;
            }
            else if (puesto.Equals("Scrum Master"))
            {
                salario = 1200000.0;
            }
            else if (puesto.Equals("Contador"))
            {
                salario = 300000.0;
            }
            else if (puesto.Equals("Asistente contable"))
            {
                salario = 270000.0;
            }
            else if (puesto.Equals("Secretaria"))
            {
                salario = 250000.0;
            }

            return salario;
        }

        public double calculoSalarioNeto(string puesto)
        {
            double salarioNeto;

            deduccion = this.salarioBruto(puesto) * 0.20;
            salarioNeto = this.salarioBruto(puesto) - deduccion;

            return salarioNeto;
        }
    }
}
