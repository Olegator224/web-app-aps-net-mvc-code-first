using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace web_app_asp_net_mvc_code_first.Models.Entities
{
    public class ErrorType
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Тип
        /// </summary>    
        [Required]
        [Display(Name = "Тип", Order = 5)]
        public string Type { get; set; }

        /// <summary>
        /// Ошибки
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Error> Errors { get; set; }
    }
}