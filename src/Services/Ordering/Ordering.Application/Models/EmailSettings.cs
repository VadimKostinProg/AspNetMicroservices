using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Models
{
    public class EmailSettings
    {
        public string ApiKey { get; set; }
        public string SenderAddress { get; set; }
        public string SenderName { get; set; }
    }
}
