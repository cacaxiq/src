﻿using System;

namespace Base.ViewModel.Model.Prospect
{
    public class ProspectDTO : BaseDTO
    {
        public string Address { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CellPhone { get; set; }
        public bool IsWhatsApp { get; set; }
        public string HomePhone { get; set; }
    }
}
