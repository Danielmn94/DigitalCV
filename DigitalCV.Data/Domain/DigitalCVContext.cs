using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DigitalCV.Data.Domain
{
    public class DigitalCVContext : IdentityDbContext
    {
        public DigitalCVContext(DbContextOptions<DigitalCVContext> options)
            : base(options)
        {
        }
    }
}
