using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Modelo
    {
        //atributos
        private string id;
        private string marca;
        private string descripcion;

        //constructor
        public Modelo(string pId, string pMarca, string pDescripcion)
        {
            this.Id = pId;
            this.Marca = pMarca;
            this.Descripcion = pDescripcion;
        }

        //get y set
        public string Id
        {
            get  {return id;  }
            set    { id = value; }
        }

        public string Marca
        {
            get    { return marca;  }
            set  { marca = value; }
        }

        public string Descripcion
        {
            get {return descripcion; }
            set{ descripcion = value;}   
        }

        //tostring
        public override string ToString()
        {
            return this.id+this.marca+this.descripcion;
        }

    }
}
