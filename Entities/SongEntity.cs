﻿using System;
using System.Collections.Generic;

namespace Entities;

public partial class SongEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int ArtistId { get; set; }

    public int TimesPlayed { get; set; }

    public virtual UserEntity Artist { get; set; } = null!;

    public virtual ICollection<AlbumEntity> Albums { get; set; } = new List<AlbumEntity>();

    public virtual ICollection<PlaylistEntity> Playlists { get; set; } = new List<PlaylistEntity>();

    public virtual ICollection<UserEntity> LikedByUsers { get; set; } = new List<UserEntity>();
}
