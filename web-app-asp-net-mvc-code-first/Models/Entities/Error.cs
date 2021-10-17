using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;
using web_app_asp_net_mvc_code_first.Extensions;
using web_app_asp_net_mvc_code_first.Models.Attributes;

namespace web_app_asp_net_mvc_code_first.Models.Entities
{
    public class Error
    {
        /// <summary>
        /// Id
        /// </summary> 
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        /// <summary>
        /// Код ошибки
        /// </summary>    
        [Required]
        [Display(Name = "Код ошибки", Order = 5)]
        public string Code { get; set; }

        /// <summary>
        /// Тип ошибки
        /// </summary> 
        [ScaffoldColumn(false)]
        public virtual ICollection<ErrorType> ErrorTypes { get; set; }


        [ScaffoldColumn(false)]
        public List<int> ErrorTypeIds { get; set; }

        [Display(Name = "Тип ошибки", Order = 70)]
        [UIHint("MultipleDropDownList")]
        [TargetProperty("ErrorTypeIds")]
        
        [NotMapped]
        public IEnumerable<SelectListItem> ErrorTypeDictionary
        {
            get
            {
                var db = new ErrorLogContext();
                var query = db.ErrorTypes;

                if (query != null)
                {
                    var Ids = query.Where(s => s.Errors.Any(ss => ss.Id == Id)).Select(s => s.Id).ToList();
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.ToSelectList(c => c.Id, c => $"{c.Type}", c => Ids.Contains(c.Id)));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }


        /// <summary>
        /// Описание
        /// </summary>  
        [Display(Name = "Описание", Order = 40)]
        public string Description { get; set; }




        /// <summary>
        /// Пользователь
        /// </summary> 
        [ScaffoldColumn(false)]
        public int UserId { get; set; }
        [ScaffoldColumn(false)]
        public virtual User User { get; set; }

        [Display(Name = "Пользователь", Order = 50)]
        [UIHint("DropDownList")]
        [TargetProperty("UserId")]
        [NotMapped]
        public IEnumerable<SelectListItem> UsersDictionary
        {
            get
            {
                var db = new ErrorLogContext();
                var query = db.Users;

                if (query != null)
                {
                    var dictionary = new List<SelectListItem>();
                    dictionary.AddRange(query.OrderBy(d => d.Name).ToSelectList(c => c.Id, c => c.Name, c => c.Id == UserId));
                    return dictionary;
                }

                return new List<SelectListItem> { new SelectListItem { Text = "", Value = "" } };
            }
        }


        /// <summary>
        /// Дата возникнования ошибки
        /// </summary> 
        [ScaffoldColumn(false)]
        public DateTime Date { get; set; }


        /// <summary>
		/// фото ошиибки
		/// </summary> 
		[ScaffoldColumn(false)]
        public virtual ErrorImage ErrorImage { get; set; }
        [Display(Name = "Фото ошибки", Order = 60)]
        [NotMapped]
        public HttpPostedFileBase ErrorImageFile { get; set; }
    }
}