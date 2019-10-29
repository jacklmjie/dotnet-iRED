using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxVenueVMs
{
    public partial class WxVenueTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<WxVenue>(x => x.Name);
        [Display(Name = "描述")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<WxVenue>(x => x.Description);

	    protected override void InitVM()
        {
        }

    }

    public class WxVenueImportVM : BaseImportVM<WxVenueTemplateVM, WxVenue>
    {

    }

}
