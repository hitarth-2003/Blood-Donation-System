namespace BloodDonationSystem.Models
{
    public class BloodRequest
    {
        public int Id { get; set; }

        public string PatientName { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }

        public string BloodGroup { get; set; }

        public int UnitsRequired { get; set; }

        public string HospitalName { get; set; }

        public string City { get; set; }

        public string ContactNumber { get; set; }

        public DateTime RequiredDate { get; set; }

        public string Priority { get; set; }

        public string Address { get; set; }

        public string? Status { get; set; } 
    }
}