using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    public class CustomerBO
    {

        public int Id { get; set; }
        /*[Required]
        [MaxLength(20)]
        [MinLength(2)]*/
        public String FirstName { get; set; }
        public String LastName { get; set; }
        
        public string FullName
        {
            get { return $"{FirstName} {LastName}"; }
        }
        public List<AddressBO> Addresses { get; set; }

        public List<int> AddressIds { get; set; }
        
    }
}
