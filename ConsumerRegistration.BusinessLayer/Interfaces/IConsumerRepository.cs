using System.Collections.Generic;

namespace ConsumerRegistrationPortal.BusinessLayer.Interfaces
{
    public interface IConsumerRepository : IRepository<Dtos.ConsumerDtos>
    {
       List<Dtos.ConsumerValidationResults> ValidateConsumer(long campaignig, string attributes);
    }
}
