using System.Data;
using Dapper;
using FluentValidation;
using Microsoft.Data.SqlClient;
using ProgramasFacpya.Api.Common;
using ProgramasFacpya.Api.Data;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Dto;
using ProgramasFacpya.Api.Features.Alumnos.Dominio.Entidad;

namespace ProgramasFacpya.Api.Features.Alumnos;

public class CarreraService(DbContext db, IValidator<CarreraDTO> validator)
{
    private readonly DbContext _db = db;
    private readonly IValidator<CarreraDTO> _validator = validator;

    public async Task<ApiResponse<IEnumerable<Carrera>>> ObtenerTodos()
    {
        using var connection = _db.CreateConnection();
        var sql = @"SELECT IdCarrera, Descripcion
                    FROM CARRERA
                    ORDER BY IdCarrera";

        var carreras = await connection.QueryAsync<Carrera>(sql);
        return ApiResponse<IEnumerable<Carrera>>.Ok(carreras);
    }

    public async Task<ApiResponse<Carrera>> ObtenerPorId(byte idCarrera)
    {
        using var connection = _db.CreateConnection();
        var sql = @"SELECT IdCarrera, Descripcion
                    FROM CARRERA
                    WHERE IdCarrera = @IdCarrera";

        var carrera = await connection.QueryFirstOrDefaultAsync<Carrera>(sql, new { IdCarrera = idCarrera });

        if (carrera == null)
            return ApiResponse<Carrera>.Error("Carrera no encontrada");

        return ApiResponse<Carrera>.Ok(carrera);
    }

    public async Task<ApiResponse<byte>> Crear(CarreraDTO dto)
    {
        var validacion = await _validator.ValidateAsync(dto);
        if (!validacion.IsValid)
            return ApiResponse<byte>.Error(validacion.Errors.First().ErrorMessage);

        var descripcion = dto.Descripcion.Trim();

        using var connection = _db.CreateConnection();
        if (await ExisteDescripcion(connection, descripcion))
            return ApiResponse<byte>.Error("La carrera ya existe");

        var sql = @"INSERT INTO CARRERA (Descripcion)
                    VALUES (@Descripcion);
                    SELECT CAST(SCOPE_IDENTITY() AS TINYINT)";

        var idCarrera = await connection.ExecuteScalarAsync<byte>(sql, new { Descripcion = descripcion });
        return ApiResponse<byte>.Ok(idCarrera, "Carrera registrada");
    }

    public async Task<ApiResponse<string>> Actualizar(byte idCarrera, CarreraDTO dto)
    {
        var validacion = await _validator.ValidateAsync(dto);
        if (!validacion.IsValid)
            return ApiResponse<string>.Error(validacion.Errors.First().ErrorMessage);

        var descripcion = dto.Descripcion.Trim();

        using var connection = _db.CreateConnection();
        if (await ExisteDescripcion(connection, descripcion, idCarrera))
            return ApiResponse<string>.Error("Ya existe otra carrera con esa descripcion");

        var sql = @"UPDATE CARRERA
                    SET Descripcion = @Descripcion
                    WHERE IdCarrera = @IdCarrera";

        var rows = await connection.ExecuteAsync(sql, new { IdCarrera = idCarrera, Descripcion = descripcion });

        if (rows == 0)
            return ApiResponse<string>.Error("Carrera no encontrada");

        return ApiResponse<string>.Ok("Carrera actualizada");
    }

    public async Task<ApiResponse<string>> Eliminar(byte idCarrera)
    {
        using var connection = _db.CreateConnection();
        var sql = @"DELETE FROM CARRERA WHERE IdCarrera = @IdCarrera";

        try
        {
            var rows = await connection.ExecuteAsync(sql, new { IdCarrera = idCarrera });

            if (rows == 0)
                return ApiResponse<string>.Error("Carrera no encontrada");

            return ApiResponse<string>.Ok("Carrera eliminada");
        }
        catch (SqlException ex) when (ex.Number == 547) // llave foránea: hay alumnos con esa carrera
        {
            return ApiResponse<string>.Error("No se puede eliminar la carrera porque tiene alumnos registrados");
        }
    }

    // excluirId sirve en Actualizar para no compararse contra sí misma
    private static async Task<bool> ExisteDescripcion(IDbConnection connection, string descripcion, byte? excluirId = null)
    {
        var sql = @"SELECT COUNT(1) FROM CARRERA
                    WHERE Descripcion = @Descripcion
                      AND (@IdExcluir IS NULL OR IdCarrera <> @IdExcluir)";

        var cuantos = await connection.ExecuteScalarAsync<int>(sql, new { Descripcion = descripcion, IdExcluir = excluirId });
        return cuantos > 0;
    }
}