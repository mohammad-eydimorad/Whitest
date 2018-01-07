using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SampleWebAPI01.Models
{
    public class Customer
    {
        public long Id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
    }
}