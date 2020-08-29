namespace Commander.Models //namespace: the name of our project (similar to Java package (?))
{
    //our first and only model
    public class Command
    {
        public int id { get; set; }
        public string HowTo { get; set; }
        public string Line { get; set; } //command line snippet we'll store in database
        public string Platform { get; set; } //application platform 
    }
}