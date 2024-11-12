using FluentValidation;
using TechLottery.DTOs;

namespace TechLottery.Validators
{
    public class UserRegisterValidator : AbstractValidator<UsuarioRequestDto>
    {
        public UserRegisterValidator()
        {
            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(x=>x.Correo).NotEmpty().WithMessage("El correo es obligatorio")
                .EmailAddress().WithMessage("El correo no es válido");
            RuleFor(x => x.Password).NotEmpty().WithMessage("La contraseña es obligatoria")
                .MinimumLength(6).WithMessage("La contraseña debe tener al menos 6 caracteres")
                .Matches("[A-Z]").WithMessage("La contraseña debe contener al menos una letra mayúscula")
                .Matches("[0-9]").WithMessage("La contraseña debe contener al menos un número");
            RuleFor(x => x.Telefono)
                .NotEmpty().WithMessage("El teléfono es obligatorio");
                


        }
    }
}
