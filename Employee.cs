﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BusinessLayer
{
    public class Employee
    {
        //[Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        //public string Gender { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }

       internal void Add(Employee employee)
        {
            throw new NotImplementedException();
        }
        
    }
}
