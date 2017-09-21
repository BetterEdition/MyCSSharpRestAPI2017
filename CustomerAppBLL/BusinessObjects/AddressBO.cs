using System;
using System.Collections.Generic;
using System.Text;

namespace CustomerAppBLL.BusinessObjects
{
    public class AddressBO
    {
        public int Id { get; set; }
        public String Street { get; set; }
        public String Number { get; set; }
        
        public String City { get; set; }
    }
}
