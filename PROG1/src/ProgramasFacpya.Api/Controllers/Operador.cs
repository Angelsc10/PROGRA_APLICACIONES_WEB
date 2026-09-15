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

    [HttpGet("Saber si es igual, menor o mayor a 0/{numero:int}")]
    public IActionResult CompararConCero(int numero)
    {
        if (numero > 0)
        {
            return Ok("El número es mayor que 0");
        }
        else if (numero < 0)
        {
            return Ok("El número es menor que 0");
        }
        else
        {
            return Ok("El número es igual a 0");
        }
    }   

    [HttpGet("promedio5materias/{nota1:int}/{nota2:int}/{nota3:int}/{nota4:int}/{nota5:int}")]
    public IActionResult Promedio5Materias(int nota1, int nota2, int nota3, int nota4, int nota5)
    {
        double promedio = (nota1 + nota2 + nota3 + nota4 + nota5) / 5.0;

        if (promedio >= 60 && promedio <= 100)
        {
            return Ok(new { promedio, resultado = "Aprobado" });
        }
        else if (promedio >= 0 && promedio < 60)
        {
            return Ok(new { promedio, resultado = "Reprobado" });
        }
        else
        {
            return BadRequest("Notas inválidas");
        }
    }

    [HttpGet("Par o Impar/{numero:int}")]
    public IActionResult ParOImpar(int numero)
    {
        if (numero % 2 == 0)
        {
            return Ok("El número es par");
        }
        else
        {
            return Ok("El número es impar");
        }
    }

    [HttpGet("Ingresar 3 números y mostrar el menor/{numero1:int}/{numero2:int}/{numero3:int}")]
    public IActionResult MenorDeTres(int numero1, int numero2, int numero3)
    {
        int menor = Math.Min(numero1, Math.Min(numero2, numero3));
        return Ok($"El número menor es: {menor}");
    }

    [HttpGet("Determinar si la letra es vocal o no/{letra}")]
    public IActionResult EsVocal(string letra)
    {
        if (letra.Length != 1 || !char.IsLetter(letra[0]))
        {
            return BadRequest("Debe ingresar una sola letra.");
        }

        char letraMinuscula = char.ToLower(letra[0]);
        if ("aeiou".Contains(letraMinuscula))
        {
            return Ok("La letra es una vocal.");
        }
        else
        {
            return Ok("La letra no es una vocal.");
        }
    }

    [HttpGet("Leer 3 valores alamcenarlos en Num1, Num2, Num3, mostrar el mayor y tienen que ser valores diferentes/{Num1:int}/{Num2:int}/{Num3:int}")]
    public IActionResult MayorDeTres(int Num1, int Num2, int Num3)
    {
        if (Num1 == Num2 || Num1 == Num3 || Num2 == Num3)
        {
            return BadRequest("Los valores deben ser diferentes.");
        }

        int mayor = Math.Max(Num1, Math.Max(Num2, Num3));
        return Ok($"El número mayor es: {mayor}");
    }
}