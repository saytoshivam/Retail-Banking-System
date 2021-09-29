using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankUI.Models
{
    public class Customer
    {
      
        
        public int CustId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }

        //[Required(ErrorMessage ="Enter DOB")]

        //[DataType(DataType.DateTime)]
        //[DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? DOB { get; set; }

        [Required(ErrorMessage = "Enter PANno")]
        [Range(10000, Int32.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public int PANno { get; set; }

    }
}
