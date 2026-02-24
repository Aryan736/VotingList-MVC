using System.ComponentModel.DataAnnotations;

namespace VotingList.Models
{
    public class Votermod
    {
        [Key]
        public int VoterId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [Display(Name = "First name")]
        public string firstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        [Display(Name = "Last name")]
        public string lastName { get; set; }

        [Required(ErrorMessage = "Date of birth is required.")]
        [DataType(DataType.Date)]
        [Display(Name = "Date of birth")]
        public DateTime? dob { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [Display(Name = "Email address")]
        public string email { get; set; }

        [Required(ErrorMessage = "Street address is required.")]
        [Display(Name = "Street address")]
        public string address1 { get; set; }

        [Display(Name = "Apt / Suite / Other")]
        public string address2 { get; set; }

        [Required(ErrorMessage = "City is required.")]
        [Display(Name = "City")]
        public string city { get; set; }

        [Required(ErrorMessage = "State / UT is required.")]
        [Display(Name = "State / UT")]
        public string state { get; set; }

        [Required(ErrorMessage = "ZIP code is required.")]
        [Display(Name = "ZIP code")]
        public string pin { get; set; }

        [DataType(DataType.PhoneNumber)]
        [Display(Name = "Phone number")]
        public string phone { get; set; }

        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhaar number must be exactly 12 digits.")]
        [Display(Name = "Aadhaar Number")]
        public string addhar { get; set; }

        [Required(ErrorMessage = "You must confirm that you are a citizen.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must confirm citizenship.")]
        [Display(Name = "Citizen confirmation")]
        public bool citizenCheck { get; set; }

        [Required(ErrorMessage = "You must declare the information is true.")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "You must declare that the information is true.")]
        [Display(Name = "Truthfulness confirmation")]
        public bool truthfulCheck { get; set; }

        //here i m doing some changes
        public enum VoterStatus
        {
            Pending,
            Approved,
            Rejected
        }

        public VoterStatus Status { get; set; } = VoterStatus.Pending;

    }
}
