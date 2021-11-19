using System;
using System.Collections.Generic;

#nullable disable

namespace AuthTestApp.Models
{
    public partial class VicidialCarrierLog
    {
        [Key]
        public double Uniqueid { get; set; }
        public DateTime CallDate { get; set; }
        public string ServerIp { get; set; }
        public int LeadId { get; set; }
        public string HangupCause { get; set; }
        public string Dialstatus { get; set; }
        public string Channel { get; set; }
        public string DialTime { get; set; }
        public string AnsweredTime { get; set; }
        public string SipHangupCause { get; set; }
        public string SipHangupReason { get; set; }
        public string CallerCode { get; set; }
    }
}
