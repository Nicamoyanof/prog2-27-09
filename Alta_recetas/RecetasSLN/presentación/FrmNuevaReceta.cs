using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RecetasSLN.datos;
using RecetasSLN.dominio;

namespace RecetasSLN.presentación
{
    public partial class FrmNuevaReceta : Form
    {



        public FrmNuevaReceta()
        {
            InitializeComponent();
        }

        private void FrmNuevaReceta_Load(object sender, EventArgs e)
        {
            CargarIngredientesCombo();
        }

        public void CargarIngredientesCombo()
        {
            List<Ingredientes> lIngredientes = new List<Ingredientes>();
            string sp = "SP_CONSULTAR_INGREDIENTES";

            DataTable dt = HelperDB.ObtenerInstancia().ConsultarSQL(sp, null);

            foreach (DataRow dr in dt.Rows)
            {
                int ingedienteId = int.Parse(dr["id_ingrediente"].ToString());

                string nombre = dr["n_ingrediente"].ToString();

                string unidad = dr["unidad_medida"].ToString();

                lIngredientes.Add(new Ingredientes(ingedienteId, nombre, unidad));
                cboIngredientes.Items.Add(new Ingredientes(ingedienteId, nombre, unidad).ToString());
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}
