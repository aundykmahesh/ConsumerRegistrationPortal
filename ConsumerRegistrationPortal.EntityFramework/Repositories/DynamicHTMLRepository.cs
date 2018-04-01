using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ConsumerRegistrationPortal.EntityFramework.Repositories
{
    class DynamicHTMLRepository : Interfaces.IDynamicHTMLRepository
    {
        private readonly ConsumerRegistrationEntities _dbcontext;
        public DynamicHTMLRepository(ConsumerRegistrationEntities context)
        {
            _dbcontext = context;
        }

        public DbSet<ValidationMaster> ValidationMasters { get => _dbcontext.ValidationMasters; set => ValidationMasters = value; }
        public DbSet<HTMLMaster> HTMLMasters { get => _dbcontext.HTMLMasters; set => HTMLMasters = value; }
        public DbSet<Terminology> Terminologies { get => _dbcontext.Terminologies; set => Terminologies = value; }
        public DbSet<TerminologiesDetail> TerminologiesDetails { get => _dbcontext.TerminologiesDetails; set => TerminologiesDetails=value; }

        public IQueryable GetHTMLDbSet(long campaignid)
        {
            IQueryable result = from terminology in Terminologies
                         join
                         terminologydetails in TerminologiesDetails
                         on terminology.Id equals terminologydetails.TerminologiesId into terminologygroup
                         from m in terminologygroup.DefaultIfEmpty()
                         join
                         htmls in HTMLMasters
                         on terminology.HTMLElementID equals htmls.Id
                         join
                         validations in ValidationMasters
                         on terminology.ValidationId equals validations.ValidationId into validationgroup
                         from n in validationgroup.DefaultIfEmpty()
                         select new
                         {
                             recordid = terminology.Id,
                             campaignid = terminology.CampaignId,
                             htmlelement = htmls.ElementName,
                             labeltext = terminology.TerminologyText,
                             searchable = terminology.Searchable,
                             sortorder = terminology.SortOrder,
                             ismandatory = terminology.isMandatory,
                             validationtext = n.ValidationName,
                             detailsvalue = (m == null ? "0" : m.Value),
                             detailssortorder = (m == null ? 0 : m.SortOrder),
                             detailsselected = m.Selected
                         };
            //var config = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<IQueryable, List<HTMLGenerationEntity>>();
            //} );
            //var mapper = config.CreateMapper();
            //List<HTMLGenerationEntity> returnresult = new List<HTMLGenerationEntity>();
            //mapper.Map(result,returnresult);

            return result;
        }
    }
}
