﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Repository
{
    public class Customer
    {
        [Key]
        public int Cid { get; set; }
        public string Cname { get; set; }
        public string Caddress { get; set; }
    }
}