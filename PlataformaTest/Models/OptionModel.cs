using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace PlataformaTest.Models
{
    public class OptionModel
    {
        [Key, Column(Order = 0), ForeignKey("QuestionModel")]
        public int QuestionId { get; set; }

        [Key, Column(Order = 1), DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [JsonIgnore]
        public virtual QuestionModel QuestionModel { get; set; }

        [JsonIgnore]
        public bool IsCorrect { get; set; }
    }
}