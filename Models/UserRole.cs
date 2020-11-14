using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WebApiRoutesResponses.Models
{
    public class UserRole
    {
        public Guid userRoleId{get;set;} = Guid.NewGuid();

        public string role{set;get;}

        public string description{set;get;}
        public Guid userId{get;set;}

        [JsonIgnore]
        public bool active {get;set;} = true;

        public virtual User user {get; set;}
    }
}