using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos //namespace: the name of our project (similar to Java package (?))
{
    //Maps to our internal Command model
    public class CommandCreateDto
    { 
       // public int id { get; set; } --> remove because db will create itself the id number

        public string HowTo { get; set; }

        public string Line { get; set; } 

       public string Platform { get; set; } //cannot remove platform in create class because it's required when reading
    }
}