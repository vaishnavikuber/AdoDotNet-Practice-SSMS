﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeePayRollAdo.Net
{
    internal class CustomerModel
    {

        public int CustomerId { get; set; }
        public string CustomerName {  get; set; }
        public string Email {  get; set; }
        public string PhoneNumber {  get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender {  get; set; }

    }
}
