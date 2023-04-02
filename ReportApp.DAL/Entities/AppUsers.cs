﻿using Microsoft.AspNetCore.Identity;
using ReportApp.DAL.Entities;

namespace ReportApp.BLL.Entities
{
    public class AppUsers : IdentityUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        public IList<Report> Products { get; set; } = new List<Report>();
    }
}
