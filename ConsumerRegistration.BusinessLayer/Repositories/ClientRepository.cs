using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumerRegistrationPortal.EntityFramework;

namespace ConsumerRegistrationPortal.BusinessLayer.Repositories
{

  public  class ClientRepository : Repository<Dtos.ClientDtos>, Interfaces.IClientRepository
    {
        private readonly ConsumerRegistrationEntities _dbcontext;
        public ClientRepository(ConsumerRegistrationEntities context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
