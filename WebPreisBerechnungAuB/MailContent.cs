using Microsoft.AspNetCore.Http;

namespace WebPreisBerechnungAuB
{
    public class MailContent
    {
        public int Id { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public IFormFileCollection Attachments { get; set; }
    }
}
