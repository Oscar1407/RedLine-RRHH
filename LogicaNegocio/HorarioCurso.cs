using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaNegocio
{
    public class HorarioCurso
    {
        public string IDCurso { set; get; }

        public string dia { set; get; }

        public int horaInicio { set; get; }

        public int horaFin { set; get; }

        public int comprobacionHorario(int horaIni, int horaFin)
        {
            int correcto = 0;

            if (horaIni > 0 && horaIni < 24)
            {
                correcto = 1;
            }
            if (horaFin > 0 && horaFin < 24)
            {
                correcto = 1;
            }

            return correcto;
        }
    }
}
