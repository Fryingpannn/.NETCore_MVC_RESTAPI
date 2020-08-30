using System.ComponentModel.DataAnnotations;

namespace Commander.Dtos //namespace: the name of our project (similar to Java package (?))
{
    //Maps to our internal Command model
    public class CommandCreateDto
    { 
       // public int id { get; set; } --> remove because db will create itself the id number

         //data annotation validators here will require these during creation; in case of error, return 400 instead of 500 to client
        [Required]
        [MaxLength(250)]
        public string HowTo { get; set; }

        [Required]
        public string Line { get; set; } 

        [Required]
        public string Platform { get; set; } //cannot remove platform in create class because it's required when reading
    }
}