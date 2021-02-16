using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MainProgram.Templates
{
    public class ComboBoxTemplate
    {
        public int Value { get; set; }
        public string DisplayedText { get; set; }
    }

    public enum ComboBoxTemplateEnum
    {
        [Display(Name = "Select from a file")]
        FromDatabase = 1,

        [Display(Name = "Select from a database")]
        FromFile = 2,

        [Display(Name = "Input your own text")]
        UserInput = 3

    }
}
