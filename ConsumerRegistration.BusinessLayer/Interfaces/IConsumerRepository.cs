using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.EntityFramework.Interfaces
{
    public interface IConsumerRepository
    {
        DbSet<Campaign> Campaigns { get; set; }
        DbSet<Client_StoredProcedures> Client_StoredProcedures { get; set; }
        DbSet<Client_StoredProcedures_attr> Client_StoredProcedures_attr { get; set; }
        DbSet<Client> Clients { get; set; }

        DbSet<object> ValidateConsumer(long campaignig, string attributes);

    }
}
