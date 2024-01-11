using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage
{
    public interface IViewSecretMessageDbContext : IDisposable
    {
        DbSet<ViewedSecretMessageDto> ViewedSecretMessages { get; }

        Task SaveChangesAsync();
    }
}
