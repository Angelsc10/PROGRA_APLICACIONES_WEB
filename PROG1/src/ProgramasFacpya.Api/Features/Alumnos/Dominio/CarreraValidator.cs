using FluentValidation;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;

namespace ProgramasFacpya.Api.Features.Alumnos;

public class CarreraValidator : AbstractValidator<CarreraDTO>
{
    public CarreraValidator()
    {
        RuleFor(x => x.Descripcion)
            .Cascade(CascadeMode.Stop)
            .NotEmpty().WithMessage("La descripcion es requerida")
            .Must(TenerMinimoDosLetras).WithMessage("La descripcion debe tener al menos 2 caracteres")
            .Must(SoloLetras).WithMessage("La descripcion solo debe contener letras")
            .MaximumLength(10).WithMessage("La descripcion no puede tener mas de 10 caracteres");
    }

    private static bool TenerMinimoDosLetras(string texto) =>
        texto.Replace(" ", "").Length >= 2;

    private static bool SoloLetras(string texto) =>
        texto.Replace(" ", "").All(char.IsLetter);
}