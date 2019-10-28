using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxActivityVMs
{
    public partial class WxActivitySearcher : BaseSearcher
    {
        [Display(Name = "名称")]
        public String Name { get; set; }
        [Display(Name = "开始时间")]
        public DateTime? BeginTime { get; set; }
        [Display(Name = "结束时间")]
        public DateTime? EndTime { get; set; }

        protected override void InitVM()
        {
        }

    }
}
