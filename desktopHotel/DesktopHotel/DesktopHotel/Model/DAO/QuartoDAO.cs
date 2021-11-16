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
    class QuartoDAO
    {
        Conexao conn = new Conexao();
        ExecutaQuery executaQuery = new ExecutaQuery();
        String query = "";

        public void cadastrarQuartos(QuartoModel quarto)
        {
            query = $"INSERT INTO QUARTOS(QT_ANDAR, QT_VALOR, QT_TIPO, QT_DESC) values('{quarto.QT_ANDAR}', '{quarto.QT_VALOR}', '{quarto.QT_TIPO}', '{quarto.QT_DESC}')";
            try
            {
                executaQuery.executaComando(query);
                conn.desconectar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERRO: ", ex.Message);
            }
        }

        public List<QuartoModel> getAll()
        {
            query = $"SELECT * FROM QUARTOS";
            List<QuartoModel> quartoModel = new List<QuartoModel>();

            try
            {
                QuartoModel item;
                DataTable dados = executaQuery.executaComandoLista(query);

                for(int i = 0; i < dados.Rows.Count; i++)
                {
                    item = new QuartoModel()
                    {
                        QT_NUMERO = int.Parse(dados.Rows[i]["QT_NUMERO"].ToString()),
                        QT_ANDAR = dados.Rows[i]["QT_ANDAR"].ToString(),
                        QT_VALOR = Double.Parse(dados.Rows[i]["QT_VALOR"].ToString()),
                        QT_TIPO = dados.Rows[i]["QT_TIPO"].ToString(),
                        QT_DESC = dados.Rows[i]["QT_DESC"].ToString(),
                    };
                    quartoModel.Add(item);
                }
                conn.desconectar();
                return quartoModel;
            }
            catch(SqlException ex)
            {
                MessageBox.Show("ERRO: ", ex.Message);
                return null;
            }
        }

        public void alterarQuarto(QuartoModel quartoModel)
        {
            query = $"UPDATE QUARTOS SET QT_ANDAR = '{quartoModel.QT_ANDAR}', QT_VALOR = REPLACE('{quartoModel.QT_VALOR}', ',', '.'), QT_TIPO = '{quartoModel.QT_TIPO}',  QT_DESC = '{quartoModel.QT_DESC}' WHERE QT_NUMERO = '{quartoModel.QT_NUMERO}'";
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

        public void excluirQuartos(String numero)
        {
            ExecutaQuery executaQuery = new ExecutaQuery();

            query = $"DELETE FROM QUARTOS WHERE QT_NUMERO = '{numero}'";

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

        public bool buscarPorNumero(String numero)
        {
            query = $"SELECT * FROM QUARTOS WHERE QT_NUMERO = '{numero}'";

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

        public bool verificaSeExisteQuarto(QuartoModel quartoModel)
        {
            query = $"SELECT * FROM QUARTOS WHERE QT_NUMERO = '{quartoModel.QT_NUMERO}'";

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
                MessageBox.Show("Erro ao buscar quarto" + ex.Message);
                return false;
            }
        }
    }
}
