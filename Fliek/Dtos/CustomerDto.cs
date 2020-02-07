using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fliek.Models;


namespace Fliek.Dtos
{
    public class CustomerDto
    {

        private DateTime? _dob;
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        public DateTime? DateOFBirth
        {
            get { return _dob; }
            set { _dob = value.HasValue ? (DateTime?)value.Value : null; }
        }

        public bool IsSuscribedToNewsletter { get; set; }

        public MembershipTypeDto MembershipType { get; set; }
        public byte MembershipTypeID { get; set; }

    }
}