using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHotel.Util
{
    class ExecutaQuery
    {
        


        //Realiza UPDATE, INSERT, DELETE
        public void executaComando(String query)
        {
            Conexao conn = new Conexao();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = query;

            try
            {
                comando.Connection = conn.conectar();
                comando.ExecuteNonQuery();
                conn.desconectar();

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao executar o comando sql: "+ex.Message);
            }

        }

        //Executa e retorna valores SELECT
        public DataTable executaComandoLista(String query)
        {
            Conexao conn = new Conexao();

            try
            {
                //Passar a query e a conexao

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn.conectar());
               
                DataTable dados = new DataTable();

                dataAdapter.Fill(dados);
                return dados;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + ex.Message);
                return null;
            }


        }




    }
}
