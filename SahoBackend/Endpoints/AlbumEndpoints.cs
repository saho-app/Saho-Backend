using Domain.Services;
using Microsoft.AspNetCore.Mvc;
using SahoBackend.Mapping.Interfaces;
using SahoBackend.Models;

namespace SahoBackend.Endpoints;

public class AlbumEndpoints
{
    public static async Task<IResult> GetAlbumById(int id, IAlbumService service, IAlbumMapper mapper)
    {
        var entity = await service.RetrieveAsync(id);
        return entity is not null ? Results.Ok(mapper.EntityToDto(entity)) : Results.NotFound();
    }

    public static async Task<IResult> GetAllAlbums(IAlbumService service, IAlbumMapper mapper)
    {
        return Results.Ok((from x in await service.GetAllAsync() select mapper.EntityToDto(x)).ToList());
    }

    public static async Task<IResult> PostAlbum([FromBody] Album album, IAlbumService service, IAlbumMapper mapper)
    {
        var dto = mapper.ModelToDto(album);
        return Results.CreatedAtRoute("albumById", new { Id = await service.CreateOrUpdateAsync(dto) });
    }

    public static async Task<IResult> PutAlbum([FromBody] Album album, IAlbumService service, IAlbumMapper mapper)
    {
        var dto = mapper.ModelToDto(album);
        var id = await service.CreateOrUpdateAsync(dto);

        if (id < 0)
        {
            return Results.StatusCode(StatusCodes.Status500InternalServerError);
        }

        if (album.Id is not null)
        {
            return Results.NoContent();
        }
        return Results.CreatedAtRoute("albumById", new { Id = id });
    }

    public static async Task<IResult> DeleteAlbum(int id, IAlbumService service)
    {
        return await service.DeleteAsync(id) ? Results.NoContent() : Results.NotFound();
    }

    public static async Task<IResult> GetSongs(int id, IAlbumService service, ISongMapper mapper)
    {
        var songs = await service.GetSongsAsync(id);
        return songs is not null ? Results.Ok((from x in songs select mapper.EntityToDto(x)).ToList()) : Results.NotFound();
    }
}