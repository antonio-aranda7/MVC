using GigHub.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData
            (
                new User
                {
                    Id = "ff3a36c1-df1b-4fcc-9567-5776743ad04f",
                    Name = "Jose Jose"
                },
                new User
                {
                    Id = "598cfc07-bdc3-4676-a92f-1bb8e951bd60",
                    Name = "Kick Hammer"
                    
                }
            );
        }
    }
}
