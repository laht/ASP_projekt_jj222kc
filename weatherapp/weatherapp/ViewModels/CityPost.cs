using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace weatherapp.ViewModels
{
    //view model for index
    public class CityPost
    {
        [Required(AllowEmptyStrings=false, ErrorMessage="Du måste fylla i en stad!")]
        [DisplayName("City")]
        public string CityName { get; set; }
    }
}