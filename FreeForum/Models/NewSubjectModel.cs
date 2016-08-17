using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreeForum.Models
{
    public class NewSubjectModel
    {
        [Display(Name="Название беседы")]
        [MinLength(6)]
        [MaxLength(140)]
        public string Title { get; set; }

        [Display(Name = "Текст сообщения")]
        [MinLength(6)]
        [MaxLength(512)]
        public string MessageText { get; set; }
    }
}