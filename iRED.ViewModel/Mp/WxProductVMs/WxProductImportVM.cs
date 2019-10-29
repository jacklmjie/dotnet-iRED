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
    public partial class WxProductTemplateVM : BaseTemplateVM
    {
        [Display(Name = "名称")]
        public ExcelPropety Name_Excel = ExcelPropety.CreateProperty<WxProduct>(x => x.Name);
        [Display(Name = "所属场馆")]
        public ExcelPropety Venue_Excel = ExcelPropety.CreateProperty<WxProduct>(x => x.VenueId);
        [Display(Name = "价格")]
        public ExcelPropety Price_Excel = ExcelPropety.CreateProperty<WxProduct>(x => x.Price);
        [Display(Name = "可用库存")]
        public ExcelPropety AvailableStock_Excel = ExcelPropety.CreateProperty<WxProduct>(x => x.AvailableStock);
        [Display(Name = "描述")]
        public ExcelPropety Description_Excel = ExcelPropety.CreateProperty<WxProduct>(x => x.Description);

	    protected override void InitVM()
        {
            Venue_Excel.DataType = ColumnDataType.ComboBox;
            Venue_Excel.ListItems = DC.Set<WxVenue>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.Name);
        }

    }

    public class WxProductImportVM : BaseImportVM<WxProductTemplateVM, WxProduct>
    {

    }

}
