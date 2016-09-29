//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntegrationTool.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class DatabaseParameter
    {
        public DatabaseParameter()
        {
            this.Integrations = new HashSet<Integration>();
        }
    
        public int DatabaseParametersId { get; set; }
        public string Ip { get; set; }
        public string Port { get; set; }
        public string Instance { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int EngineId { get; set; }
    
        public virtual Engine Engine { get; set; }
        [JsonIgnore]
        public virtual ICollection<Integration> Integrations { get; set; }
    }
}
