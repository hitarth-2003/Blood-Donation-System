namespace BloodDonationSystem.Models
{
    public class Donor
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string BloodGroup { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }

        public string City { get; set; }

        public DateTime LastDonationDate { get; set; }

        public string Address { get; set; }
    }
}