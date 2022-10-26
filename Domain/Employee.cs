using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain
{
    public class Employee
    {
        [Column("EmployeeId")]
        public Guid? Id { get; set; }
       
        public string? Name { get; set; }
        public int? Age { get; set; }
      
        public string? Position { get; set; }

        [ForeignKey(nameof(Company))]
        public Guid CompanyId { get; set; }
    }

}
