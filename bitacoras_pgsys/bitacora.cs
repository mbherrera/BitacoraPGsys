using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace bitacoras_pgsys
{
    class bitacora
    {
        private int cod;
        private string descripcion, empresa, titulo;
        private DateTime ultmod;

        public int codigo_bitacora {
            get { return cod; }
            set { cod = value; }
        }
        public string empresa_bitacora {
            get { return empresa; }
            set { empresa = value; }
        }
        public string titulo_bitacora {
            get { return titulo; }
            set { titulo = value; }
        }
        public string descripcion_bitacora {
            get { return descripcion; }
            set { descripcion = value; }
        }
        public DateTime  ultmod_bitacora {
            get { return ultmod; }
            set { ultmod = value; }
        }
    }
}
