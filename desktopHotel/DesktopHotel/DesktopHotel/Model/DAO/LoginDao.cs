using DesktopHotel.Util;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopHotel.Model.DAO
{
    class LoginDao
    {
        Conexao conn = new Conexao();
        ExecutaQuery executaQuery = new ExecutaQuery();
        String query = "";

        public bool validaLogin(LoginModel login) {
             query = $"SELECT * FROM LOGIN where LOG_USER = '{login.user}' AND LOG_SENHA = '{login.senha}'";

            try
            {
     
                LoginModel item;

                DataTable dados = executaQuery.executaComandoLista(query);
                
                if(dados.Rows.Count == 1)
                {
                    return true;
                    conn.desconectar();
                }
                else
                {
                    return false;
                    conn.desconectar();
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar login" + ex.Message);
                return false;
            }
        }



        public void cadastraOperador(LoginModel login)
        {
            
             query = $"INSERT INTO LOGIN (LOG_USER,LOG_USERNAME,LOG_SENHA,LOG_NIVEL,LOG_STATUS,LOG_CPF) VALUES ('{login.user}','{login.username}','{login.senha}','{login.nivel}','{login.status}','{login.cpf}')";
            try
            {
                executaQuery.executaComando(query);
                conn.desconectar();
                MessageBox.Show("Cadastro realizado com sucesso!","Sucesso",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }

        public List<LoginModel> getAll()
        {
             query = "SELECT * FROM LOGIN WHERE LOG_STATUS = 'A'";
            List<LoginModel> lista = new List<LoginModel>();

            try
            {
                LoginModel item;
                DataTable dados = executaQuery.executaComandoLista(query);

                for (int i = 0; i < dados.Rows.Count; i++)
                {
                    item = new LoginModel()
                    {
                        codigo = Convert.ToInt32(dados.Rows[i]["log_cod"].ToString()),
                        user = dados.Rows[i]["log_user"].ToString(),
                        username = dados.Rows[i]["log_username"].ToString(),
                        senha = dados.Rows[i]["log_senha"].ToString(),
                        nivel = dados.Rows[i]["log_nivel"].ToString(),
                        status = dados.Rows[i]["log_status"].ToString(),
                        cpf = dados.Rows[i]["log_cpf"].ToString()
                    };
                    lista.Add(item);

               
                }
                conn.desconectar();
                return lista;
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return null;
            }
        }

        public LoginModel getLoginUser(String user)
        {
             query = $"SELECT * FROM LOGIN WHERE LOG_USER = '{user}' AND LOG_STATUS <> 'I'";

            try
            {
                LoginModel item;

                DataTable dados = executaQuery.executaComandoLista(query);

                if (dados.Rows.Count == 1)
                {
                    item = new LoginModel()
                    {
                        codigo = Convert.ToInt32(dados.Rows[0]["log_cod"].ToString()),
                        user = dados.Rows[0]["log_user"].ToString(),
                        username = dados.Rows[0]["log_username"].ToString(),
                        senha = dados.Rows[0]["log_senha"].ToString(),
                        nivel = dados.Rows[0]["log_nivel"].ToString(),
                        status = dados.Rows[0]["log_status"].ToString(),
                        cpf = dados.Rows[0]["log_cpf"].ToString()
                    };
                    conn.desconectar();
                    return item;
                }
                else
                {
                    conn.desconectar();
                    return null;
                }

                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return null;
            }



        }

        public bool verificaNivel(String user, String senha)
        {
             query = $"SELECT * FROM LOGIN WHERE LOG_USER = '{user}' AND LOG_SENHA = '{senha}' AND LOG_NIVEL = 'ADM'";

            try
            {
                DataTable dados = executaQuery.executaComandoLista(query);

                if(dados.Rows.Count == 1)
                {
                    conn.desconectar();
                    return true;
                   
                }else
                {
                    conn.desconectar();
                    return false;
                }
                
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return false;
            }
            
        }

        public void excluirLogin(String codigo)
        {
            ExecutaQuery executaQuery = new ExecutaQuery();

             query = $"DELETE FROM LOGIN WHERE LOG_COD = '{codigo}'";

            try
            {
                executaQuery.executaComando(query);
                conn.desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }


        public bool buscaPorCodigo(String codigo)
        {
            query = $"SELECT * FROM LOGIN WHERE LOG_COD  = '{codigo}'";

            try
            {
                DataTable dados = executaQuery.executaComandoLista(query);

                if (dados.Rows.Count == 1)
                {
                    conn.desconectar();
                    return true;
                }
                else
                {
                    conn.desconectar();
                    return false;
                }

            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
                return false;
            }
        }


        public void alterarOperador(LoginModel login)
        {
            query = $"UPDATE LOGIN SET LOG_USER = '{login.user}', LOG_USERNAME = '{login.username}'," +
                $" LOG_SENHA = '{login.senha}', LOG_NIVEL = '{login.nivel}', LOG_STATUS = '{login.status}', LOG_CPF = '{login.cpf} '" +
                $" WHERE LOG_COD = '{login.codigo}' ";

            try {
                executaQuery.executaComando(query);
                conn.desconectar();
                MessageBox.Show("Alteração realizada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }

        }


        public bool verificaSeExisteUser(LoginModel login)
        {
            query = $"SELECT * FROM LOGIN where LOG_USER = '{login.user}' AND LOG_STATUS <> 'I'";

            try
            {
                DataTable dados = executaQuery.executaComandoLista(query);

                if (dados.Rows.Count == 1)
                {
                    conn.desconectar();
                    return true;
                }
                else
                {
                    conn.desconectar();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar login" + ex.Message);
                return false;
            }
        }


        public bool verificaCPFCadastrado(LoginModel login)
        {
            query = $"SELECT * FROM LOGIN where LOG_CPF = '{login.cpf}' AND LOG_STATUS <> 'I'";

            try
            {
                DataTable dados = executaQuery.executaComandoLista(query);

                if (dados.Rows.Count == 1)
                {
                    conn.desconectar();
                    return true;
                }
                else
                {
                    conn.desconectar();
                    return false;
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Erro ao buscar login" + ex.Message);
                return false;
            }
        }


    }
}
