using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp.domain.Models
{
    public class Assignment : BaseEntity
    {
        public AssignmentType AssignmentType { get; set; } = null!;
        public Customer Customer { get; set; } = null!;
        public string Description { get; set; } = string.Empty;

        public Assignment(Customer customer, AssignmentType assignmentType, string description = "")
        {
            Customer = customer;
            AssignmentType = assignmentType;
            Description = description;
        }

        private Assignment()
        { }
    }
}