using System;
using System.Collections.Generic;

#nullable disable

namespace HRMSFinal.Repository.Models
{
    public partial class Log
    {
        public string Activity { get; set; }
        public DateTime? ActivityDate { get; set; }
    }
}
