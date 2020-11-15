using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class Despido
    {
        public string IDInstitucional { set; get; }

        public string cedula { set; get; }

        public string nombre { set; get; }

        public string primerApellido { set; get; }

        public string segundoApellido { set; get; }

        public string correo { set; get; }

        public string telefono { set; get; }

        public string puestoTrabajo { get; set; }

        public string motivoDespido { set; get; }

    }// Fin de la clase
}// Fin del namespace
