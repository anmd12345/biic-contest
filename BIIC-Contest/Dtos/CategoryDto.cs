using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIIC_Contest.Dtos
{
    public class CategoryDto
    {
        private short id;
        private string categoryName;
        private string description;

        public short Id { get => id; set => id = value; }
        public string CategoryName { get => categoryName; set => categoryName = value; }
        public string Description { get => description; set => description = value; }
    }
}