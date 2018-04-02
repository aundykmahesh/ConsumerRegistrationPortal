using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumerRegistrationPortal.BusinessLayer.Dtos;
using ConsumerRegistrationPortal.EntityFramework;


namespace ConsumerRegistrationPortal.BusinessLayer.Repositories
{
   public class ConsumerRepository : Repository<ConsumerDtos>, Interfaces.IConsumerRepository
    {
        private readonly ConsumerRegistrationEntities _dbcontext;
        public ConsumerRepository(ConsumerRegistrationEntities context) : base(context)
        {
            _dbcontext = context;
        }

        public List<ConsumerValidationResults> ValidateConsumer(long campaignid, string attributes)
        {
            var qryresult= _dbcontext.Database.SqlQuery<ConsumerValidationResults>("EXEC	[dbo].[PerformMatch] @attributes = N'" + attributes + "',@campaignId = " + campaignid).AsEnumerable();
            return qryresult.ToList();
        }
    }
}
