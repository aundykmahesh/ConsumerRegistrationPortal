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
using ConsumerRegistrationPortal.DomainLayer;

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
                         //join
                         //terminologydetails in _dbcontext.TerminologiesDetails
                         //on terminology.Id equals terminologydetails.TerminologiesId into terminologygroup
                         //from m in terminologygroup.DefaultIfEmpty()
                         join
                         campaigns in _dbcontext.Campaigns
                         on terminology.CampaignId equals campaigns.Id
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
                             TerminologyId = terminology.Id,
                             CampaignName = campaigns.CampaignName,
                             terminology.CampaignId,
                             ElementName = htmls.ElementName,
                             HTMLElementId = terminology.TerminologyKey,
                             LabelText = terminology.TerminologyText,
                             HoverText = terminology.Description,
                             searchable = terminology.Searchable,
                             sortorder = terminology.SortOrder,
                             required = (terminology.isMandatory) ? "required" : string.Empty,
                             validationtext = n.ValidationName,
                             HTMLDetails = string.Empty
                         };
            var config = new MapperConfiguration(cfg => cfg.CreateMissingTypeMaps = true);
            var mapper = config.CreateMapper();
            var returnresults = result.Select(mapper.Map<HTMLGenerationEntity>).ToList();
            returnresults.ForEach(c => c.HTMLDetails = GetHTMLDetails(c.TerminologyId));
            returnresults.ForEach(c => c.HTMLDetails.ForEach(d => d.ParsedSelectedString = ParseSelectString(c.ElementName,d.Selected)));

            return returnresults;
        }

        public List<HTMLGenerationEntity> GetHTMLMasterTags(List<HTMLGenerationEntity> _htmls)
        {
            var results = _htmls.Select(c => new HTMLGenerationEntity()
                                                 {
                                                     CampaignName = c.CampaignName,
                                                     required = c.required,
                                                     TerminologyId = c.TerminologyId,
                                                     HoverText = c.HoverText,
                                                     HTMLDetails = null,
                                                     ElementName = c.ElementName,
                                                     HTMLElementId = c.HTMLElementId,
                                                     LabelText = c.LabelText,
                                                     Searchable = c.Searchable,
                                                     SortOrder = c.SortOrder,
                                                     ValidationText = c.ValidationText
                                                 }).Distinct().ToList().GroupBy(c => c.TerminologyId);

            List<HTMLGenerationEntity> returnresults = new List<HTMLGenerationEntity>();
            results.ToList().ForEach(c => returnresults.Add(c.First()));

            returnresults.ForEach(c => c.HTMLDetails = GetHTMLDetails(c.TerminologyId));
            returnresults.ForEach(c => c.HTMLDetails.ForEach(d => d.ParsedSelectedString = ParseSelectString(c.ElementName,d.Selected)));
            return returnresults;
        }

        public List<HTMLGenerationMultipleEntity> GetHTMLDetails(long _masterTagId)
            => Configurations.MappingConfiguration<TerminologiesDetail,HTMLGenerationMultipleEntity>.GetDestinationAsList(
                _dbcontext.TerminologiesDetails
                    .Where(d => d.TerminologiesId == _masterTagId).ToList()
                );

        private string ParseSelectString(string elementname, bool selected) {
            string result = string.Empty;

            if (!selected) return result;

            HTMLControls hTMLControls = EnumHelper<HTMLControls>.Parse(elementname.ToLower());
            switch (hTMLControls)
            {
                case HTMLControls.textbox:
                    break;
                case HTMLControls.checkbox:
                    result = "checked";
                    break;
                case HTMLControls.listbox:
                    break;
                case HTMLControls.radiobutton:
                    break;
                case HTMLControls.dropdownlist:
                    result = "selected";
                    break;
                case HTMLControls.textarea:
                    break;
                default:
                    break;
            }
            return result;
        }

        public HTMLControls GetHTMLControlNameFromId(long terminologyid)
        {
            var results = (from _term in _dbcontext.Terminologies
                           join
                           _htmls in _dbcontext.HTMLMasters on _term.HTMLElementID equals _htmls.Id
                           where _term.Id == terminologyid
                           select new { TagName = _htmls.ElementName }).SingleOrDefault().ToString();
            return EnumHelper<HTMLControls>.Parse(results);
        }
    }
}
