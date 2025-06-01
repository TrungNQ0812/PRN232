namespace PRN232TestAPI.DTOs
{
    public class GetStudentDetails
    {
        public int StudentId { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public DateOnly? BirthDate { get; set; }

        public string? Gender { get; set; }

        public string? Email { get; set; }

        public string? Phone { get; set; }
    }
}
