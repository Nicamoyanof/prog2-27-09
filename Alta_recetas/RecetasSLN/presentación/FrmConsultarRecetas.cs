using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecetasSLN.dominio;
using RecetasSLN.datos;
using RecetasSLN.presentación;

namespace RecetasSLN.presentación
{
    public partial class FrmConsultarRecetas : Form
    {

        //private HelperDB helper;

        public FrmConsultarRecetas()
        {
            InitializeComponent();
        }

        private void FrmConsultarRecetas_Load(object sender, EventArgs e)
        {
            CargarRecetas();

        }

        public void CargarRecetas()
        {
            List<Receta> lRecetas = new List<Receta>();
            string sp = "SP_CONSULTAR_RECETAS";
            DataTable t = HelperDB.ObtenerInstancia().ConsultarSQL(sp, null);

            foreach (DataRow dr in t.Rows)
            {
                int recetaNro = int.Parse(dr["id_receta"].ToString());

                string nombre = dr["nombre"].ToString();

                int tipoReceta = int.Parse(dr["tipo_receta"].ToString());

                string cheff = dr["cheff"].ToString();

                lRecetas.Add(new Receta(recetaNro, nombre, tipoReceta, cheff));
                dgvRecetas.Rows.Add(new object[]
                {
                    nombre, tipoReceta, cheff
                });

            }

        }
        public void CargarIngredientes()
        {
            List<Ingredientes> lIngredientes = new List<Ingredientes>();
            string sp = "SP_CONSULTAR_INGREDIENTES";
            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSQL(sp, null);

            foreach (DataRow dr in dt.Rows)
            {
                int ingedienteId  = int.Parse(dr["[id_ingrediente]"].ToString());

                string nombre = dr["[n_ingrediente]"].ToString();

                string unidad = dr["[unidad_medida]"].ToString();

                lIngredientes.Add(new Ingredientes(ingedienteId, nombre, unidad));

            }

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            FrmNuevaReceta nuevaReceta = new FrmNuevaReceta();

            nuevaReceta.Show();
        }
    }
}
