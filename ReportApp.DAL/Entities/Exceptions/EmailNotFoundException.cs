using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.DAL.Entities.Exceptions
{
    public sealed class EmailNotFoundException : NotFoundException
    {
        public EmailNotFoundException(string email) : 
            base($"{email} not found in our database")
        {
        }
    }
}
