﻿using RestWithASP_NET.Model.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET.Model
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Gender { get; set; }
    }
}
