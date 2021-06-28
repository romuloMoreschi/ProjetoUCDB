using ProjetoUCDB.Services.Useful;

namespace ProjetoUCDB.Services.DTO
{
    public class OrderDTO
    {
        public long Id { get; set; }
        public string nome_produto { get; set; } //mantido minusculo igual solicitado na prova
        public decimal valor { get; set; } //mantido minusculo igual solicitado na prova
        public decimal desconto { get; set; } //mantido minusculo igual solicitado na prova
        public string data_vencimento { get; set; } //mantido minusculo igual solicitado na prova
        public string situacao { get; set; } //mantido minusculo igual solicitado na prova
        public OrderDTO()
        {
        }
        public OrderDTO(string nome_produto, decimal valor, decimal desconto, string data_vencimento, string situacao)
        {
            this.nome_produto = nome_produto;
            this.valor = valor;
            this.desconto = desconto;
            this.data_vencimento = UsefulMethods.DateFormatForDateOnly(data_vencimento);
            this.situacao = situacao;
        }
    }
}
