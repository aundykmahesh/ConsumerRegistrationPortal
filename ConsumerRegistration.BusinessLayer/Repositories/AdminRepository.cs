using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumerRegistrationPortal.EntityFramework;

namespace ConsumerRegistrationPortal.BusinessLayer.Repositories
{
   public class AdminRepository : Repository<Dtos.AdminDtos>, Interfaces.IAdminRepository
    {
        private readonly ConsumerRegistrationEntities _dbcontext;
        public AdminRepository(ConsumerRegistrationEntities context) : base(context)
        {
            _dbcontext = context;
        }
    }
}
