using System;
using System.Collections.Generic;
using System.Text;
using DigitalCV.Data.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalCV.Data.Domain
{
    public class DigitalCVContext : IdentityDbContext<ApplicationUser>
    {
        public DigitalCVContext(DbContextOptions<DigitalCVContext> options)
            : base(options)
        {
        }
    }
}
