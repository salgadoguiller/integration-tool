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
    
    public partial class Integration
    {
        public Integration()
        {
            this.Calendars = new HashSet<Calendar>();
            this.IntegrationLogs = new HashSet<IntegrationLog>();
            this.QueryParameters = new HashSet<QueryParameter>();
            this.SystemLogs = new HashSet<SystemLog>();
        }
    
        public int IntegrationId { get; set; }
        public System.DateTime IntegrationDate { get; set; }
        public int UserId { get; set; }
        public int WebServiceId { get; set; }
        public int DatabaseParametersId { get; set; }
        public int FlatFileId { get; set; }
        public int FlatFileParameterId { get; set; }
        public int IntegrationTypeId { get; set; }
        public int QueryId { get; set; }
        public int IntegrationCategoryId { get; set; }
        public string CurlParameters { get; set; }
        public int OperationWebServiceId { get; set; }
        public string IntegrationName { get; set; }
        public int StatusId { get; set; }
    
        public virtual ICollection<Calendar> Calendars { get; set; }
        public virtual DatabaseParameter DatabaseParameter { get; set; }
        public virtual FlatFile FlatFile { get; set; }
        public virtual FlatFilesParameter FlatFilesParameter { get; set; }
        public virtual IntegrationCategory IntegrationCategory { get; set; }
        public virtual ICollection<IntegrationLog> IntegrationLogs { get; set; }
        public virtual IntegrationsType IntegrationsType { get; set; }
        public virtual OperationsWebService OperationsWebService { get; set; }
        public virtual Query Query { get; set; }
        public virtual Status Status { get; set; }
        public virtual User User { get; set; }
        public virtual WebService WebService { get; set; }
        public virtual ICollection<QueryParameter> QueryParameters { get; set; }
        [JsonIgnore]
        public virtual ICollection<SystemLog> SystemLogs { get; set; }
    }
}
