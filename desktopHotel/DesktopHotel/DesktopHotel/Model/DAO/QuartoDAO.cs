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
            query = $"INSERT INTO QUARTOS(QT_ANDAR, QT_VALOR, QT_TIPO, QT_DESC) values('{quarto.andar}', '{quarto.valorDiaria}', '{quarto.tipo}', '{quarto.descricao}')";
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
                        numero = int.Parse(dados.Rows[i]["QT_NUMERO"].ToString()),
                        andar = dados.Rows[i]["QT_ANDAR"].ToString(),
                        valorDiaria = Double.Parse(dados.Rows[i]["QT_VALOR"].ToString()),
                        tipo = dados.Rows[i]["QT_TIPO"].ToString(),
                        descricao = dados.Rows[i]["QT_DESC"].ToString(),
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
            query = $"UPDATE QUARTOS SET QT_ANDAR = '{quartoModel.andar}', QT_VALOR = REPLACE('{quartoModel.valorDiaria}', ',', '.'), QT_TIPO = '{quartoModel.tipo}',  QT_DESC = '{quartoModel.descricao}' WHERE QT_NUMERO = '{quartoModel.numero}'";
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
            query = $"SELECT * FROM QUARTOS WHERE QT_NUMERO = '{quartoModel.numero}'";

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
