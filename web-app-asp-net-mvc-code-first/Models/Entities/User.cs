using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_code_first.Extensions;
using web_app_asp_net_mvc_code_first.Models.Attributes;
using web_app_asp_net_mvc_code_first.Models.Enums;

namespace web_app_asp_net_mvc_code_first.Models.Entities
{
    public class User
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Название
        /// </summary>    
        [Required]
        [Display(Name = "Имя пользователя", Order = 5)]
        public string Name { get; set; }

        /// <summary>
        /// Пол
        /// </summary> 
        [ScaffoldColumn(false)]
        public Gender Gender { get; set; }

        [Display(Name = "Пол", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("Gender")]
        [NotMapped]
        public IEnumerable<SelectListItem> GenderDictionary
        {
            get
            {
                var dictionary = new List<SelectListItem>();

                foreach (Gender type in Enum.GetValues(typeof(Gender)))
                {
                    dictionary.Add(new SelectListItem
                    {
                        Value = ((int)type).ToString(),
                        Text = type.GetDisplayValue(),
                        Selected = type == Gender
                    });
                }

                return dictionary;
            }
        }

        /// <summary>
        /// Список книг
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<Error> Errors { get; set; }
    }
}