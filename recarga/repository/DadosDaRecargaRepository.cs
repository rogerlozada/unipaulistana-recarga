namespace recarga.repository
{
    using recarga.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.SqlClient;

    public class DadosDaRecargaRepository
    {
        string connString = "Persist Security Info=False;User ID=sa; Password=brujah231; Initial Catalog=recarga;Data Source=BRSAO1PW-2632\\SQLMAIN";
        
        public void Inserir(ModeloDadosDaRecarga obj)
        {
            var con = new SqlConnection(connString);
            var cmd = new SqlCommand();

            try
            {
                cmd.Connection = con;
                cmd.CommandText = "Insert into DadosDaRecarga (Operadora, DDD, Numero, Valor, Forma_Pgto) values (@Operadora, @DDD, @Numero, @Valor, @Forma_Pgto) select @@IDENTITY;";
                cmd.Parameters.AddWithValue("Operadora", obj.Operadora);
                cmd.Parameters.AddWithValue("DDD", obj.DDD);
                cmd.Parameters.AddWithValue("Numero", obj.Numero);
                cmd.Parameters.AddWithValue("Valor", obj.Valor);
                cmd.Parameters.AddWithValue("Forma_Pgto", obj.Forma_Pgto);
                con.Open();
                obj.ID = Convert.ToInt32(cmd.ExecuteScalar());
            }
            catch (Exception erro)
            {
                throw new Exception(erro.Message);
            }
            finally
            {
                con.Close();
            }
        }

        public IEnumerable<ModeloDadosDaRecarga> ObterTodos()
        {
            SqlConnection con = new SqlConnection(this.connString);
            con.Open();

            var cmd = new SqlCommand("select * from DadosDaRecarga", con);
            SqlDataReader sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
                yield return new ModeloDadosDaRecarga(
                    Convert.ToInt32(sqlDataReader.GetValue(0)),
                     Convert.ToInt32(sqlDataReader.GetValue(1)),
                    sqlDataReader.GetValue(2).ToString(),
                    sqlDataReader.GetValue(3).ToString(),
                    sqlDataReader.GetValue(4).ToString(),
                    Convert.ToInt32(sqlDataReader.GetValue(5).ToString())
                    );

            con.Close();
        }
    }
}
