using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Ingredientes
    {

        private int ingedienteId;

        private string nombre;

        private string unidad;

        public Ingredientes()
        {
            ingedienteId = 0;
            this.nombre = "sin nombre";
            this.unidad = "sin unidad";
        }

        public Ingredientes(int ingedienteId, string nombre, string unidad)
        {
            this.ingedienteId = ingedienteId;
            this.nombre = nombre;
            this.unidad = unidad;
        }

        public string pUnidad
        {
            get { return unidad; }
            set { unidad = value; }
        }


        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int pIngredienteid
        {
            get { return ingedienteId; }
            set { ingedienteId = value; }
        }

        public override string ToString()
        {
            return nombre;
        }

    }
}
