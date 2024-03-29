using SahoBackend.Mapping.Interfaces;
using Domain.DTOs;
using Entities;
using SahoBackend.Models;

namespace SahoBackend.Mapping;

public class UserMapper : IUserMapper
{
    public UserEntity? DtoToEntity(UserDto user)
    {
        return user is not null ? new UserEntity {
            Id = user.Id.Value,
            Nickname = user.Nickname,
            RoleId = user.RoleId
        } : null;
    }

    public UserDto? EntityToDto(UserEntity user) {
        return user is not null ? new UserDto {
            Id = user.Id,
            Nickname = user.Nickname,
            RoleId = user.RoleId
        } : null;
    }

    public UserDto? ModelToDto(User user)
    {
        return user is not null ? new UserDto {
            Id = user.Id,
            Nickname = user.Nickname,
            RoleId = user.RoleId 
        } : null;
    }
}