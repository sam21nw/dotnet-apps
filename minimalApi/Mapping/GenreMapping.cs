﻿using minimalApi.Dtos;
using minimalApi.Entities;

namespace minimalApi.Mapping;

public static class GenreMapping
{
    public static GenreDto ToDto(this Genre genre)
    {
        return new GenreDto(genre.Id, genre.Name);
    }
}
