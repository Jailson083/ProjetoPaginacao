using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoPaginacao.ViewModel
{
    public class TodoViewModel
    {
        [Required]
        public string Title { get; set; }

        public bool Done { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
