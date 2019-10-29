using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxOrderVMs
{
    public partial class WxOrderVM : BaseCRUDVM<WxOrder>
    {
        public List<ComboSelectListItem> AllUsers { get; set; }

        public WxOrderVM()
        {
            SetInclude(x => x.User);
        }

        protected override void InitVM()
        {
            AllUsers = DC.Set<WxUser>().GetSelectListItems(LoginUserInfo?.DataPrivileges, null, y => y.NickName);
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
