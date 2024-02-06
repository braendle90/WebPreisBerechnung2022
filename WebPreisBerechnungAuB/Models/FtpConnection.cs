namespace WebPreisBerechnungAuB.Models
{
    public class FtpConnection
    {
        public string FTPServer { get; set; } = string.Empty;
        public string FTPUser { get; set; } = string.Empty;
        public string FTPPassword { get; set; } = string.Empty;
        public int FTPPort { get; set; }
        public string FTPFileName { get; set; } = string.Empty;
    }
}
