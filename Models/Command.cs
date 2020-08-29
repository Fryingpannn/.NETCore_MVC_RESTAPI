using System.ComponentModel.DataAnnotations;

namespace Commander.Models //namespace: the name of our project (similar to Java package (?))
{
    public class Command
    {
        //This one doesn't need [Required] because by convention, migration will know that id is primary key (not nullable by nature)
        [Key] //optional
        public int id { get; set; }

        [Required] //attribute to specify value cannot be null
        [MaxLength(250)] //attribute to specify max string length
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; } //command line snippet we'll store in database

        [Required]
        public string Platform { get; set; } //application platform 
    }
}