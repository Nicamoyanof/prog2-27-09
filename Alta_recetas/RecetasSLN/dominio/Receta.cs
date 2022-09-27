using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecetasSLN.dominio
{
    internal class Receta
    {

        private int recetaNro;

        private string nombre;

        private int tipoReceta;

        private string cheff;

        public Receta()
        {
            this.recetaNro = 0;
            this.nombre = "sin nombre" ;
            this.tipoReceta = 0;
            this.cheff = "sin nombre";
        }

        public Receta(int recetaNro, string nombre, int tipoReceta, string cheff)
        {
            this.recetaNro = recetaNro;
            this.nombre = nombre;
            this.tipoReceta = tipoReceta;
            this.cheff = cheff;
        }

        public string pCheff
        {
            get { return cheff; }
            set { cheff = value; }
        }


        public int pTipoReceta
        {
            get { return tipoReceta; }
            set { tipoReceta = value; }
        }


        public string pNombre
        {
            get { return nombre; }
            set { nombre = value; }
        }


        public int pRecetaNro
        {
            get { return recetaNro; }
            set { recetaNro = value; }
        }


    }
}
