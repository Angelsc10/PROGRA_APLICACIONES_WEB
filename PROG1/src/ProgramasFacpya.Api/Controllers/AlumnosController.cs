using Microsoft.AspNetCore.Mvc;
using ProgramasFacpya.Api.Features.Alumnos;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;
using ProgramasFacpya.Api.Models;
using ProgramasFacpya.Api.Servicios;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AlumnosController(AlumnoService service) : ControllerBase
{
    private readonly AlumnoService _service = service;
    
    [HttpGet("ObtenerTodos")]
    public async Task<IActionResult> ObtenerTodos()
    {
        return Ok(await _service.ObtenerTodos());
    }

    [HttpGet("ObtenerPorId/{idAlumno:int}")]
    public async Task<IActionResult> ObtenerPorId(int idAlumno)
    {
        return Ok(await _service.ObtenerPorId(idAlumno));
    }

    [HttpPost("Crear")]
    public async Task<IActionResult> Crear([FromBody] AlumnoDTO dto)
    {
        return Ok(await _service.Crear(dto));
    }

    // public async Task<IActionResult> Actualizar(int idAlumno, [FromBody] AlumnoDTO dto)
    // {
    //     return Ok(await _service.Actualizar(idAlumno, dto));
    // }

    [HttpDelete("Eliminar/{idAlumno}")]
    public async Task<IActionResult> Eliminar(int idAlumno)
    {
        return Ok(await _service.Eliminar(idAlumno));
    }

    [HttpPost("RegistroAlumno")]
    public IActionResult RegistroAlumno([FromBody] ALUMNO Alumno)
    {
        List<string> lstErrores = BL_ALUMNO.Validaciones(Alumno.Nombre, Alumno.APaterno, Alumno.AMaterno);

        if (lstErrores.Count == 0)
        {
            return Ok(new
            {
                Code = "00"
                , Value = ""
                , Msg = ""
            });
        }
        else
        {
            return Ok(new
            {
                Code = "01"
                , Value = lstErrores 
                , Msg = ""
            });
        }
    //     string Nombre, APaterno, AMaterno;        

    //     Nombre = "Juan"; 
    //     APaterno = "Perez";
    //     AMaterno = "Martinez";

    //     return Ok();
    }


static bool ValidaTexto(string P_texto)
    {
        bool Resultado = false;

        

        return Resultado;    
    }

}