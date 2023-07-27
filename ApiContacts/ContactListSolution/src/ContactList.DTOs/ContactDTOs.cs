using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactList.DTOs
{
    public class ContactDTOs
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string? FirstName { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string? SecondName { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public DateTime? DateBirth { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string? Adresses { get; set; }
        [Required(ErrorMessage = "Campo Requerido")]
        public string? PhoneNumber { get; set; }

        public string? Image { get; set; }
    }
}
