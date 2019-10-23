using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxUserVMs
{
    public partial class WxUserSearcher : BaseSearcher
    {
        [Display(Name = "OpenId")]
        public String OpenId { get; set; }
        [Display(Name = "昵称")]
        public String NickName { get; set; }
        [Display(Name = "性别")]
        public WxSexEnum? Gender { get; set; }

        protected override void InitVM()
        {
        }

    }
}
