using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.BusinessLayer.Dtos
{
   public class HTMLGenerationEntity
    {
        public long TerminologyId { get; set; }
        public long CampaignId { get; set; }
        public string   CampaignName { get; set; }
        public string ElementName { get; set; }
        public string HTMLElementId { get; set; }
        public string LabelText { get; set; }
        public string HoverText { get; set; }
        public bool Searchable { get; set; }
        public int SortOrder { get; set; }
        public string required { get; set; }
        public string ValidationText { get; set; }

        public List<HTMLGenerationMultipleEntity> HTMLDetails { get; set; }
    }

    public class HTMLGenerationMultipleEntity
    {
        public long Id { get; set; }
        public long TerminologyId { get; set; }
        public string DisplayText { get; set; }
        public string Value { get; set; }
        public int SortOrder { get; set; }
        public bool Selected { get; set; }
    }
}
