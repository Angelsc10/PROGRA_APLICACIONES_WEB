using Microsoft.AspNetCore.Mvc;
using ProgramasFacpya.Api.Servicios;
using ProgramasFacpya.Api.Models;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class Alumnos : ControllerBase
{
    
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