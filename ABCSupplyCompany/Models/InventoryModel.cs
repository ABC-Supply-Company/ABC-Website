using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ABCSupplyCompany.CustomValidation;


namespace ABCSupplyCompany.Models
{
    public class InventoryItem
    {
            public int id { get; set; }
            [Required]
            public string lottag_number { get; set; }
            [Required]
            public string lottag_description { get; set; }
            [Required]
            public string weight_net { get; set; }
            [Required]
            public string on_hand_balance { get; set; }
            [Required]
            public string unit_of_measure { get; set; }
            [Required]
            public Boolean active { get; set; }

    }
}
