namespace ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;

// Se usa tanto para Crear como para Actualizar (IdCarrera es IDENTITY)
public class CarreraDTO
{
    public string Descripcion { get; set; } = string.Empty;
}