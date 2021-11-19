using System;
using System.Collections.Generic;

#nullable disable

namespace AuthTestApp.Models
{
    public partial class VicidialApiLog
    {
        public string ApiId { get; set; }
        public int User { get; set; }
        public DateTime ApiDate { get; set; }
        public string ApiScript { get; set; }
        public string Function { get; set; }
        public string AgentUser { get; set; }
        public string Value { get; set; }
        public string Result { get; set; }
        public string ResultReason { get; set; }
        public string Source { get; set; }
        public string Data { get; set; }
        public double RunTime { get; set; }
        public int Webserver { get; set; }
        public int ApiUrl { get; set; }
    }
}
