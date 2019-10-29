using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxProductVMs
{
    public partial class WxProductSearcher : BaseSearcher
    {
        [Display(Name = "名称")]
        public String Name { get; set; }

        protected override void InitVM()
        {
        }

    }
}
