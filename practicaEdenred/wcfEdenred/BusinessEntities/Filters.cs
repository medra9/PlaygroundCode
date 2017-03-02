using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace wcfEdenred.BusinessEntities
{
    [DataContract]
    public class Filters
    {
        [DataMember]
        public int Page { get; set; }
        [DataMember]
        public int RowsPerPage { get; set; }
        [DataMember]
        public string Text { get; set; }
    }
}