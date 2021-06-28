using System.ComponentModel.DataAnnotations;

namespace ProjetoUCDB.API.ViewModels
{
    public class CreateOrderViewModel
    {
        [Required(ErrorMessage = "O nome do produto não pode ser vazio.")]
        public string nome_produto { get; set; } //mantido minusculo igual solicitado na prova

        [Required(ErrorMessage = "O valor não pode ser vazio.")]
        public decimal valor { get; set; } //mantido minusculo igual solicitado na prova
        public decimal desconto { get; set; } //mantido minusculo igual solicitado na prova

        [Required(ErrorMessage = "A data de vencimento não pode ser vazia.")]
        public string data_vencimento { get; set; } //mantido minusculo igual solicitado na prova
    }
}
