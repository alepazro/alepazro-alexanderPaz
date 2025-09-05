using Properties.Service.Application.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Dynamic;
using System.Linq;
using System.Threading.Tasks;

namespace Properties.Service.Infrastructure.Http.Results.Owners
{
    public class CreateOwnerResult
    {
        public OwnerDto Owner { get; set; }
        public List<ValidationResult> ValidationErrors { get; set; } = new();
        public bool Success { get; set; }
    }
}