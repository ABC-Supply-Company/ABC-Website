using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ABCSupplyCompany.Models
{
    public class InventoryModel
    {
       
            public string lottag_number { get; set; }

            public string lottag_description { get; set; }

            public string weight_net { get; set; }

            public string on_hand_balance { get; set; }

            public string unit_of_measure { get; set; }
     
    }
}
