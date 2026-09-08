using Microsoft.AspNetCore.Mvc;

namespace ProgramasFacpya.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class OperadorController : ControllerBase
{
    [HttpGet("Suma/{Numero1:int}/{Numero2:int}")]
    public IActionResult Suma(int Numero1, int Numero2)
    {
        return Ok(Numero1 + Numero2);
    }

    [HttpGet("Resta/{Numero1:int}/{Numero2:int}")]
    public IActionResult Resta(int Numero1, int Numero2)
    {
        return Ok(Numero1 - Numero2);
    }

    [HttpGet("Multiplicacion/{Numero1:int}/{Numero2:int}")]
    public IActionResult Multiplicacion(int Numero1, int Numero2)
    {
        return Ok(Numero1 * Numero2);
    }

    [HttpGet("Promedio3/{Numero1:int}/{Numero2:int}/{Numero3:int}")]
    public IActionResult Promedio3(int Numero1, int Numero2, int Numero3)
    {
        return Ok((Numero1 + Numero2 + Numero3) / 3);
    }

    [HttpGet("Cuadrado/{Numero:int}")]
    public IActionResult Cuadrado(int Numero)
    {
        return Ok(Numero * Numero);
    }

    [HttpGet("AreaCuadrado/{Lado:int}")]
    public IActionResult AreaCuadrado(int Lado)
    {
        return Ok(Lado * Lado);
    }

    [HttpGet("PerimetroCuadrado/{Lado:int}")]
    public IActionResult PerimetroCuadrado(int Lado)
    {
        return Ok(Lado * 4);
    }

    [HttpGet("AreaCirculo/{Radio:int}")]
    public IActionResult AreaCirculo(int Radio)
    {
        return Ok(Math.PI * Radio * Radio);
    }

    [HttpGet("PerimetroCirculo/{Radio:int}")]
    public IActionResult PerimetroCirculo(int Radio)
    {
        return Ok(2 * Math.PI * Radio);
    }

    [HttpGet("AreaRectangulo/{Base:int}/{Altura:int}")]
    public IActionResult AreaRectangulo(int Base, int Altura)
    {
        return Ok(Base * Altura);
    }

    [HttpGet("AreaTriangulo/{Base:int}/{Altura:int}")]
    public IActionResult AreaTriangulo(int Base, int Altura)
    {
        return Ok(0.5 * Base * Altura);
    }
}