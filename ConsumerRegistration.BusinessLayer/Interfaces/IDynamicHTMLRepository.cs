using System;
using System.Collections.Generic;
using System.Data.Entity;
using ConsumerRegistrationPortal.BusinessLayer.Dtos;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.BusinessLayer.Interfaces
{
    public interface IDynamicHTMLRepository : IRepository<HTMLGenerationEntity>
    {
        List<HTMLGenerationEntity> GetHTMLDbSet(long campaignid);
        List<HTMLGenerationEntity> GetHTMLMasterTags(List<HTMLGenerationEntity> _htmls);
        List<HTMLGenerationMultipleEntity> GetHTMLDetails(long _masterTagId);
    }
}
