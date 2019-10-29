using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxProductVMs
{
    public partial class WxProductVM : BaseCRUDVM<WxProduct>
    {
        public List<ComboSelectListItem> AllVenues { get; set; }

        public WxProductVM()
        {
            SetInclude(x => x.Venue);
        }

        protected override void InitVM()
        {
            AllVenues = DC.Set<WxVenue>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.Name);
        }

        public override void DoAdd()
        {           
            base.DoAdd();
        }

        public override void DoEdit(bool updateAllFields = false)
        {
            base.DoEdit(updateAllFields);
        }

        public override void DoDelete()
        {
            base.DoDelete();
        }
    }
}
