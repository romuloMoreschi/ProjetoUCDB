using System;
using System.Collections.Generic;
using ProjetoUCDB.Core.Exceptions;
using ProjetoUCDB.Core.Validators;

namespace ProjetoUCDB.Core.Entities
{
    public class Order : Base
    {
        public string nome_produto { get; private set; } //mantido minusculo igual solicitado na prova
        public decimal valor { get; private set; } //mantido minusculo igual solicitado na prova
        public decimal desconto { get; private set; } //mantido minusculo igual solicitado na prova
        public DateTime data_vencimento { get; private set; } //mantido minusculo igual solicitado na prova
        public string situacao { get; private set; } //mantido minusculo igual solicitado na prova

        public Order(string nome_produto, decimal valor, decimal desconto, DateTime data_vencimento, string situacao)
        {
            this.nome_produto = nome_produto;
            this.valor = valor;
            this.desconto = desconto;
            this.data_vencimento = data_vencimento;
            this.situacao = situacao;
            _errors = new List<string>();
            Validate();
        }
        public void ChangeNome_produto(string nome_produto)
        {
            this.nome_produto = nome_produto;
            Validate();
        }
        public void ChangeValor(decimal valor)
        {
            this.valor = valor;
            Validate();
        }
        public void ChangeDesconto(decimal desconto)
        {
            this.desconto = desconto;
            Validate();
        }
        public void ChangeDate(DateTime data_vencimento)
        {
            this.data_vencimento = data_vencimento;
            Validate();
        }
        public void ChangeSituacao(string situacao)
        {
            this.situacao = situacao;
            Validate();
        }
        public override bool Validate()
        {
            var validator = new OrderValidator();
            var validation = validator.Validate(this);

            if (!validation.IsValid)
            {
                foreach (var error in validation.Errors)
                    _errors.Add(error.ErrorMessage);

                throw new CoreException("Alguns campos estão inválidos, por favor corrija-os!", _errors);
            }

            return true;
        }
    }
}
