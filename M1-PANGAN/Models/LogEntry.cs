using System;

namespace M1_PANGAN.Models
{
    public class LogEntry
    {
        public int Id { get; set; }
        public string Action { get; set; } = "";
        public int ItemId { get; set; }
        public string Username { get; set; } = "";
        public string? BeforeJson { get; set; }   
        public string? AfterJson { get; set; }   
        public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
    }
}
