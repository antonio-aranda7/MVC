using GigHub.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Configuration
{
    public class GenreConfiguration : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.HasData
            (
                new Genre
                {
                    Id = 1,
                    Name = "Jazz",
                },
                new Genre
                {
                    Id = 2,
                    Name = "Blues",
                },
                new Genre
                {
                    Id = 3,
                    Name = "Rock",
                },
                new Genre
                {
                    Id = 4,
                    Name = "Country",
                }
            );
        }
    }
}
