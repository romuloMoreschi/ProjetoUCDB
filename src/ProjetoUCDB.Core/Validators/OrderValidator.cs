using FluentValidation;
using ProjetoUCDB.Core.Entities;

namespace ProjetoUCDB.Core.Validators
{
    public class OrderValidator : AbstractValidator<Order>
    {
        public OrderValidator()
        {
            RuleFor(x => x)
                .NotEmpty()
                .WithMessage("Entidade não pode ser vazia!")

                .NotNull()
                .WithMessage("Entidade não pode ser nula !");

            RuleFor(x => x.nome_produto)
                .NotEmpty()
                .WithMessage("Nome do produto não pode ser vazio!")

                .NotNull()
                .WithMessage("Nome do produto não pode ser nulo!");

            RuleFor(x => x.valor)
                .NotEmpty()
                .WithMessage("Valor não pode ser vazio!")

                .NotNull()
                .WithMessage("Valor não pode ser nulo!")

                .GreaterThanOrEqualTo(0)
                .WithMessage("Valor deve ser maior que 0 !");

            RuleFor(x => x.data_vencimento)
                .NotEmpty()
                .WithMessage("Data de vencimento não pode ser vazia!")

                .NotNull()
                .WithMessage("Data de vencimento não pode ser nula!");
        }
    }
}
