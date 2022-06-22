using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NotaTask.Models
{
    [Table("PersonPhone")]
    public class PersonPhone
    {
      
        public int Id { get; set; }
        [StringLength(maximumLength:50,MinimumLength = 5)]
        public string Name { get; set; }
        [StringLength(maximumLength: 25, MinimumLength = 10)]
        public string Phone { get; set; }

    }
}
