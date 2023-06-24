using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Authentication
    {
        public string email { get; set; }  
        public string senha { get; set; }

        public Authentication()
        {
            
        }

        public Authentication(string email, string senha)
        {
            this.email = email;
            this.senha = senha;
        }
    }
}
