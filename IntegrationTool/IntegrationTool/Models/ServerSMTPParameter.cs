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
    using System;
    using System.Collections.Generic;
    
    public partial class ServerSMTPParameter
    {
        public int ServerSMTPParametersId { get; set; }
        public string NameServerSMTP { get; set; }
        public string Port { get; set; }
        public string UsernameSMTP { get; set; }
        public string PasswordSMTP { get; set; }
        public string EmailFrom { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
