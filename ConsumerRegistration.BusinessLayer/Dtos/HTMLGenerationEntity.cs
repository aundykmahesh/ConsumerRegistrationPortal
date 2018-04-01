using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.BusinessLayer.Dtos
{
   public class HTMLGenerationEntity
    {
        public long RecordId { get; set; }
        public long CampaignId { get; set; }
        public string HTMLElement { get; set; }
        public string LabelText { get; set; }
        public string HoverText { get; set; }
        public bool Searchable { get; set; }
        public int SortOrder { get; set; }
        public string required { get; set; }
        public string ValidationText { get; set; }
        public string DetailsValue { get; set; }
        public int DetailsSortOrder { get; set; }
        public bool DetailsSelected { get; set; }
    }
}
