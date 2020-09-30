using SQLite;

namespace LiaFinder.Shared
{
    public class Student
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string StudentEmail { get; set; }
        public int Age { get; set; }
    }
}
