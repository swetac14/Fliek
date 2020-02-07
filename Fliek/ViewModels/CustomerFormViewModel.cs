using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Fliek.Models;
using System.ComponentModel.DataAnnotations;

namespace Fliek.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DateOFBirth { get; set; }

        public bool IsSuscribedToNewsletter { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }

        public string PageTitle
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }

        }

        public CustomerFormViewModel()
        {
            Id = 0;

        }
        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            FirstName = customer.FirstName;
            LastName = customer.LastName;
            IsSuscribedToNewsletter = customer.IsSuscribedToNewsletter;
            DateOFBirth = customer.DateOFBirth;
            MembershipTypeID = customer.MembershipTypeID;
        }
    }
}