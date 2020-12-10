using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiRoutesResponses.Models
{
    public class User
    {
        public Guid userId{get;set;} = Guid.NewGuid();

        public string name{get;set;}

        public string lastName {get;set;}

        public string phone{get;set;}
        public DateTime dateCreated{get;set;} = DateTime.Now;

        public bool active {get;set;} = true;

        public virtual UserRole userRole{get;set;}
    }
}