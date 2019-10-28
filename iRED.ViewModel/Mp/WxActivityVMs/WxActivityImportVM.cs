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
    public partial class WxActivityTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<WxActivity>(x => x.Name);
        [Display(Name = "描述")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<WxActivity>(x => x.Description);
        [Display(Name = "开始时间")]
        public ExcelPropety BeginTime_Excel = ExcelPropety.CreateProperty<WxActivity>(x => x.BeginTime);
        [Display(Name = "结束时间")]
        public ExcelPropety EndTime_Excel = ExcelPropety.CreateProperty<WxActivity>(x => x.EndTime);

	    protected override void InitVM()
        {
        }

    }

    public class WxActivityImportVM : BaseImportVM<WxActivityTemplateVM, WxActivity>
    {

    }

}
