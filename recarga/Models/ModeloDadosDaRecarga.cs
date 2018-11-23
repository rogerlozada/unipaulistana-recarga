namespace recarga.Models
{
    public class ModeloDadosDaRecarga
    {
        public ModeloDadosDaRecarga()
        {

        }

        public ModeloDadosDaRecarga(int id, int operadora, string ddd, string numero, string valor, int pgto)
        {
            this.ID = id;
            this.Operadora = operadora;
            this.DDD = ddd;
            this.Numero = numero;
            this.Valor = valor;
            this.Forma_Pgto = pgto;
        }

        public int ID { get; set; }

        public int Operadora { get; set; }

        public string DDD { get; set; }

        public string Numero { get; set; }

        public string Valor { get; set; }

        public int Forma_Pgto { get; set; }
    }
}
