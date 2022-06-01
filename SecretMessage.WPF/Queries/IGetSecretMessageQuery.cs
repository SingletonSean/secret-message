using Refit;
using SecretMessage.Core.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecretMessage.WPF.Queries
{
    public interface IGetSecretMessageQuery
    {
        [Get("/")]
        Task<SecretMessageResponse> Execute();
    }
}
