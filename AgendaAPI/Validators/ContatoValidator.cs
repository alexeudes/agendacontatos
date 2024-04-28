using AgendaAPI.Models;
using FluentValidation;

namespace AgendaAPI.Validators
{
    public class ContatoValidator : AbstractValidator<Contato>
	{
		public ContatoValidator()
		{
            RuleFor(contato => contato.Nome).NotEmpty().Length(1, 100).WithMessage("O nome não pode ser vazio/espaço em branco, deve conter ao menos 1 e no máximo 100 caracteres.");
            RuleFor(contato => contato.Email).NotEmpty().Length(1, 100).EmailAddress().WithMessage("O e-mail deve seguir o seguinte formato: email@email.com, deve conter ao menos 1 e no máximo 100 caracteres.");
            RuleFor(contato => contato.Telefone).NotEmpty()
                .Length(15)
                .Matches("^\\([1-9]{2}\\) (?:[2-8]|9[0-9])[0-9]{3}\\-[0-9]{4}$")
                .WithMessage("O telefone deve estar no formato (DDD) 92111-1111");
        }
	}
}

