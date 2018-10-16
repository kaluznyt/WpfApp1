using System;

namespace WpfApp1
{
    public class Author 
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DOB { get; set; }
        public string BookTitle { get; set; }
        public bool IsMVP { get; set; }
        public string Description { get; set; }
        public bool MyIsReadOnly { get; set; }
    }
}
