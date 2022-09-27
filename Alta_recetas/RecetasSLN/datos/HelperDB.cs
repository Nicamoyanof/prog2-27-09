using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace RecetasSLN.datos
{
    internal class HelperDB
    {

        private static HelperDB instancia;
        private SqlConnection cnn;

        private HelperDB()
        {
            cnn = new SqlConnection(Properties.Resources.cnnString);

        }

        public static HelperDB ObtenerInstancia()
        {
            if(instancia == null)
            {
                instancia = new HelperDB();
            }
            return instancia;
        }

        public DataTable ConsultarSQL(string pNombre, List<Parameters> lParametros)
        {
            DataTable dt = new DataTable();

            cnn.Open();
            SqlCommand cmd = new SqlCommand(pNombre, cnn);

            cmd.CommandType = CommandType.StoredProcedure;

            if(lParametros != null)
            {
                foreach (Parameters parameters in lParametros)
                {
                    cmd.Parameters.AddWithValue(parameters.Name, parameters.Value);
                }
            }

            dt.Load(cmd.ExecuteReader());
            cnn.Close();

            return dt;
        }

        public int ConsultaEscalarSQL(string spNombre, string pOutNombre)
        {
            cnn.Open();
            SqlCommand cmd = new SqlCommand(spNombre, cnn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlParameter pOut = new SqlParameter();
            pOut.ParameterName = pOutNombre;
            pOut.DbType = DbType.Int32;
            pOut.Direction = ParameterDirection.Output;
            cmd.Parameters.Add(pOut);
            cmd.ExecuteNonQuery();
            cnn.Close();

            return (int)pOut.Value;
        }

        public int EjecutarSQL(string srtSql, List<Parameters> lParameters)
        {
            int filasAfectadas = 0;

            SqlTransaction t = null;

            try
            {
                SqlCommand cmd = new SqlCommand(srtSql, cnn);
                cnn.Open();
                t = cnn.BeginTransaction();
                cmd.Connection = cnn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = srtSql;
                cmd.Transaction = t;

                if(lParameters != null)
                {
                    foreach (Parameters parameters in lParameters)
                    {
                        cmd.Parameters.AddWithValue(parameters.Name, parameters.Value);
                    }
                }

                filasAfectadas = cmd.ExecuteNonQuery();
                t.Commit();

            }
            catch (SqlException)
            {
                if(t != null) { t.Rollback(); }
            }
            finally
            {
                if(cnn!=null && cnn.State == ConnectionState.Open)
                {
                    cnn.Close();
                }

            }
            
            return filasAfectadas;
        }

        public SqlConnection ObtenerConexion()
        {
            return cnn;
        }

    }
}
