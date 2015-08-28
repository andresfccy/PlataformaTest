using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PlataformaTest.Models
{
    public class QuestionModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public virtual List<OptionModel> Options { get; set; }
    }
}