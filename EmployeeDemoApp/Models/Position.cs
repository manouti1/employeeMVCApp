using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeDemoApp.Models
{
    public class Position
    {
        [Key]
        public Guid Id { get; set; } = new Guid();
        [StringLength(150)]
        [Required]
        public string Name { get; set; }
        public ICollection<UserPosition> UserPositions { get; set; }

    }
}
