namespace WebApplication1.model
{
    public class Person
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Status Status { get; set; }

        public Person(string fullName, string phoneNumber, DateTime birthDate)
        {
            FullName = fullName;
            PhoneNumber = phoneNumber;
            BirthDate = birthDate;
            Status = Status.ACTIVE;
        }
    }

    public enum Status
    {
        ACTIVE,
        DELETED
    }
}
