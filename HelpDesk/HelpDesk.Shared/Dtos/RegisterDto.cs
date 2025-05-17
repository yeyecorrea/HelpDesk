using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Shared.Dtos
{
    public class RegisterDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
        [Required]
        public string NombreCompleto { get; set; }
        public string? Departamento { get; set; }

        public DateTime FechaRegistro { get; set; } = DateTime.UtcNow;

    }
}
