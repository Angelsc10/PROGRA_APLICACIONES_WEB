namespace ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;

// Se usa tanto para Crear como para Acturalizar (IdAlumno es IDENTITY)
public class AlumnoDTO
{
    public string Nombre { get; set; } = string.Empty;
    public string APaterno { get; set; } = string.Empty;
    public string AMaterno { get; set; } = string.Empty;
    public byte IdCarrera { get; set; }
}