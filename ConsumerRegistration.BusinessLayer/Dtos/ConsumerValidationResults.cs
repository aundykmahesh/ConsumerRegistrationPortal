using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumerRegistrationPortal.BusinessLayer.Dtos
{
   public class ConsumerValidationResults
    {
        public long RecordId { get; set; }
        public long CampaignId { get; set; }
        public long ConsumerId { get; set; }
        public string ResultItem1 { get; set; }
        public string ResultItem2 { get; set; }
        public string ResultItem3 { get; set; }
        
    }
}
