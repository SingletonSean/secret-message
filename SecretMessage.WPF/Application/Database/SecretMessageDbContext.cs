using Microsoft.EntityFrameworkCore;
using SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Application.Database
{
    public class SecretMessageDbContext : DbContext, IViewSecretMessageDbContext
    {
        public SecretMessageDbContext(DbContextOptions options) : base(options) { }

        public DbSet<ViewedSecretMessageDto> ViewedSecretMessages { get; set; }

        public Task SaveChangesAsync() => base.SaveChangesAsync();
    }
}
