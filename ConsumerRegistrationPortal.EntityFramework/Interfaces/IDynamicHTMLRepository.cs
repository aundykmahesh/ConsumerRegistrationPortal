using System;
using System.Collections.Generic;
using System.Data.Entity;
using ConsumerRegistrationPortal.BusinessLayer.Dtos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.EntityFramework.Interfaces
{
    interface IDynamicHTMLRepository
    {
        DbSet<ValidationMaster> ValidationMasters { get; set; }
        DbSet<HTMLMaster> HTMLMasters { get; set; }
        DbSet<Terminology> Terminologies { get; set; }
        DbSet<TerminologiesDetail> TerminologiesDetails { get; set; }

        IQueryable GetHTMLDbSet(long campaignid);
    }
}
