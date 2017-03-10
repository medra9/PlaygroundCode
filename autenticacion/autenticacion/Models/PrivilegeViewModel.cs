
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace autenticacion.Models
{
    public class PrivilegeViewModel
    {
        public bool CanEdit { get; set; }
        public bool CanRead { get; set; }
        public PrivilegeViewModel(IEnumerable<Claim> claims)
        {
            if (!object.ReferenceEquals(null, claims))
            {
                var find = claims.SingleOrDefault(x => x.Value == "Admin");
                var edit = false;
                if (!object.ReferenceEquals(null, find))
                {
                    edit = (find.Value == "Admin") ? true : false;
                }
                this.CanEdit = edit;
                this.CanRead = edit;
            }
        }
    }
}