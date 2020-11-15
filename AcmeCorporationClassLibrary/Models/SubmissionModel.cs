using System;

namespace AcmeCorporationClassLibrary.Models
{
    public class SubmissionModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public Guid SerialNumber { get; set; }
    }
}
