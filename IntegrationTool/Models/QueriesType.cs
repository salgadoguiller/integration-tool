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
    
    public partial class QueriesType
    {
        public QueriesType()
        {
            this.HeadersQueryTypes = new HashSet<HeadersQueryType>();
            this.Queries = new HashSet<Query>();
        }
    
        public int QueryTypeId { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<HeadersQueryType> HeadersQueryTypes { get; set; }
        public virtual ICollection<Query> Queries { get; set; }
    }
}
