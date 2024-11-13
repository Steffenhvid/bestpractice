using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bp.domain.Models
{
    public class Product(string name, string model) : BaseEntity
    {
        public string Name { get; set; } = name;
        public string Model { get; set; } = model;
    }
}