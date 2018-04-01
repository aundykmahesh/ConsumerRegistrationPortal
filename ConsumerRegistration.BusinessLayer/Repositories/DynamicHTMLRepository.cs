using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using ConsumerRegistrationPortal.EntityFramework;
using ConsumerRegistrationPortal.BusinessLayer.Interfaces;
using ConsumerRegistrationPortal.BusinessLayer.Dtos;

namespace ConsumerRegistrationPortal.BusinessLayer.Repositories
{
   public class DynamicHTMLRepository : Repository<HTMLGenerationEntity>, IDynamicHTMLRepository
    {
        private readonly ConsumerRegistrationEntities _dbcontext;
        public DynamicHTMLRepository(ConsumerRegistrationEntities context) : base(context)
        {
            _dbcontext = context;
        }

        public List<HTMLGenerationEntity> GetHTMLDbSet(long campaignid)
        {
            var result = from terminology in _dbcontext.Terminologies
                         join
                         terminologydetails in _dbcontext.TerminologiesDetails
                         on terminology.Id equals terminologydetails.TerminologiesId into terminologygroup
                         from m in terminologygroup.DefaultIfEmpty()
                         join
                         htmls in _dbcontext.HTMLMasters
                         on terminology.HTMLElementID equals htmls.Id
                         join
                         validations in _dbcontext.ValidationMasters
                         on terminology.ValidationId equals validations.ValidationId into validationgroup
                         from n in validationgroup.DefaultIfEmpty()
                         where terminology.CampaignId == campaignid
                         select new
                         {
                             RecordId = terminology.Id,
                             terminology.CampaignId,
                             HTMLElement = htmls.ElementName,
                             LabelText = terminology.TerminologyText,
                             HoverText = terminology.Description,
                             searchable = terminology.Searchable,
                             sortorder = terminology.SortOrder,
                             required = (terminology.isMandatory) ? "required" : string.Empty,
                             validationtext = n.ValidationName,
                             detailsvalue = (m == null ? "0" : m.Value),
                             detailssortorder = (m == null ? 0 : m.SortOrder),
                             detailsselected = m.Selected
                         };
            var config = new MapperConfiguration(cfg => cfg.CreateMissingTypeMaps = true);
            var mapper = config.CreateMapper();
            var returnresults = result.Select(mapper.Map<HTMLGenerationEntity>).ToList();   
            foreach (var item in result)
            {
                Console.Write(item);
            }
            
            return returnresults;
        }
    }
}
