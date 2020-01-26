using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Fliek.Models
{
    public class Customer
    {
        private DateTime? _dob;


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name="First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOFBirth
        {
            get { return _dob; }
            set { _dob = value.HasValue ? (DateTime?)value.Value : null; }
        }
            
       // public DateTime DateOFBirth { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }
        public MembershipType MembershipType { get; set; }
        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }
    }
}