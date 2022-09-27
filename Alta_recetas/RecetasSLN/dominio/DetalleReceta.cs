using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class DetalleReceta
    {
        

        private Ingredientes ingediente;

        private int cantidad;

        private Receta receta;

        public Receta pReceta
        {
            get { return receta; }
            set { receta = value; }
        }


        public DetalleReceta()
        {
            pIngrediente = new Ingredientes();
            cantidad = 0;
        }

        public DetalleReceta(Ingredientes ingediente, int cantidad)
        {
            this.ingediente = ingediente;
            this.cantidad = cantidad;
        }

        public int pCantidad
        {
            get { return cantidad; }
            set { cantidad = value; }
        }


        public Ingredientes pIngrediente
        {
            get { return ingediente; }
            set { ingediente = value; }
        }


    }
}
