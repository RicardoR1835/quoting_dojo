using System;
using System.ComponentModel.DataAnnotations;

namespace quoting_dojoCsharp.Models
{
    public class Quote
    {
    
        [Required]
        [MinLength(3)]
        public string Name {get;set;} 

        [Required]
        [MinLength(10)]
        public string Content {get;set;} 

    }
}