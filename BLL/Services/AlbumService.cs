using Domain.DTOs;
using Domain.Repositories;
using DOmain.Services;

namespace BLL.Services;

public class AlbumService : IAlbumService
{
    private readonly IAlbumRepository _albumRepository;
    public AlbumService(IAlbumRepository albumRepository)
    {
        _albumRepository = albumRepository;
    }
    public async Task<bool> DeleteAsync(int id)
    {
        return await _albumRepository.DeleteAsync(id) > 0;
    }

    public async Task<List<AlbumDto>> GetAllAsync()
    {
        return await _albumRepository.GetAllAsync();
    }
    public async Task<AlbumDto> RetrieveAsync(int id)
    {
        return await _albumRepository.RetrieveAsync(id);
    }
    public async Task<int> CreateOrUpdateAsync(AlbumDto album)
    {
        if (album?.Id is null)
        {
            return await _albumRepository.CreateAsync(album);
        }
        if (await _albumRepository.CreateAsync(album) > 0)
        {
            return album.Id;
        }
        return 0;
    }
    public async Task<bool> UpdateDescriptionAsync(int id, string description)
    {
        return await _albumRepository.UpdateDescriptionAsync(id, description) > 0;
    }