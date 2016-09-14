using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IntegrationTool.Models
{
    public class IntegrationSchedule
    {
        public int IntegrationId { get; set; }
        public string Name { get; set; }
        public DateTime NextExecutionDate { get; set; }
    }
}