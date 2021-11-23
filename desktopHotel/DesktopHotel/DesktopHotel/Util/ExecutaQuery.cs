using System;
using System.Collections.Generic;
using System.Data;
using MySql.Data.MySqlClient;
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
            MySqlCommand comando = new MySqlCommand();
            comando.CommandText = query;

            try
            {
                comando.Connection = conn.conectar();
                comando.ExecuteNonQuery();
                conn.desconectar();

            }
            catch (MySqlException ex)
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

                 MySqlDataAdapter dataAdapter = new MySqlDataAdapter(query, conn.conectar());
               
                DataTable dados = new DataTable();

                dataAdapter.Fill(dados);
                return dados;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("Erro ao executar o comando sql: " + ex.Message);
                return null;
            }


        }




    }
}
