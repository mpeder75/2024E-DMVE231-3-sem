using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnionDemo.Application.Command.CommandDto
{
    public class DeleteAccommodationDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Id skal være positivt")]
        public int Id { get; set; }
        public byte[] RowVersion { get; set; } = null!;
    }
}
