using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Marca
    {
        private string descMarca;
        private string codigoMarca;

        //constructores
        public Marca(string codigoMarca, string descMarca)
        {
            this.CodigoMarca = codigoMarca;
            this.DescMarca = descMarca;

        }

        public Marca(string descMarca)
        {
            this.DescMarca = descMarca;
        }

        //get y set
        public string DescMarca
        {
            get { return descMarca; }
            set { descMarca = value; }
        }

        public string CodigoMarca
        {
            get { return codigoMarca; }
            set { codigoMarca = value; }
        }

        //tostring
        public override string ToString()
        {
            return this.descMarca;
        }
    }
}
