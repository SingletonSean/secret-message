using Refit;
using SecretMessage.Core.Responses;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Queries
{
    public interface IGetSecretMessageQuery
    {
        [Get("/")]
        Task<SecretMessageResponse> Execute();
    }
}
