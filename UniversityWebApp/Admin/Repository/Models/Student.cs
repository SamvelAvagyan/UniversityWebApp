namespace Repository.Models
{
    public class Student : BaseModel
    {
        private byte mark;
        public string Name { get; set; }
        public string Surname { get; set; }
        public byte Mark
        {
            get { return mark; }
            set
            {
                if (value > 0 && value < 21)
                {
                    mark = value;
                }
            }
        }
    }
}
