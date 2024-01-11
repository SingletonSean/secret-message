using System;

namespace SecretMessage.WPF.Features.SecretMessage.ViewSecretMessage
{
    public class ViewedSecretMessageDto
    {
        public Guid Id { get; set; }
        public string UserId { get; set; }
        public string Content { get; set; }
        public DateTimeOffset DateViewed { get; set; }
    }
}
