using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos //namespace: the name of our project (similar to Java package (?))
{
    //Maps to our internal Command model
    public class CommandReadDto
    { 
        public int id { get; set; }

        public string HowTo { get; set; }

        public string Line { get; set; } 

       // public string Platform { get; set; } //we can remove this if we don't want to show it to client
    }
}