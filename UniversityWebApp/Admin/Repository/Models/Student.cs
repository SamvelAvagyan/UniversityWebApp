namespace Repository.Models
{
    public class Student : BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Mark { get; set; }
    }
}
