using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Http;
using MimeKit;
using System.Collections.Generic;
using System.Linq;

namespace WebPreisBerechnungAuB
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public IFormFileCollection Attachments { get; set; }

        public Message(IEnumerable<string> to, string subject = "", string content="",IFormFileCollection attachments = null)
        {
            To = new List<MailboxAddress>();
            To.AddRange(to.Select(x => new MailboxAddress(string.Empty, x)));
            Subject = subject;
            Content = content;
            Attachments = attachments;
        }

        //public Message(IEnumerable<string> to, string subject, string content)
        //{
        //    To = new List<MailboxAddress>();
        //    To.AddRange(to.Select(x => new MailboxAddress(string.Empty, x)));
        //    Subject = subject;
        //    Content = content;
        //}
    }
}


