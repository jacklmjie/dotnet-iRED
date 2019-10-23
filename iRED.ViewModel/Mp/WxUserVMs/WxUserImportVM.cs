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
    public partial class WxUserTemplateVM : BaseTemplateVM
    {
        [Display(Name = "OpenId")]
        public ExcelPropety OpenId_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.OpenId);
        [Display(Name = "昵称")]
        public ExcelPropety NickName_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.NickName);
        [Display(Name = "头像")]
        public ExcelPropety AvatarUrl_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.AvatarUrl);
        [Display(Name = "性别")]
        public ExcelPropety Gender_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.Gender);
        [Display(Name = "所在国家")]
        public ExcelPropety Country_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.Country);
        [Display(Name = "所在省份")]
        public ExcelPropety Province_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.Province);
        [Display(Name = "所在城市")]
        public ExcelPropety City_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.City);
        [Display(Name = "所用语言")]
        public ExcelPropety Language_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.Language);
        [Display(Name = "创建时间")]
        public ExcelPropety CreateTime_Excel = ExcelPropety.CreateProperty<WxUser>(x => x.CreateTime);

	    protected override void InitVM()
        {
        }

    }

    public class WxUserImportVM : BaseImportVM<WxUserTemplateVM, WxUser>
    {

    }

}
