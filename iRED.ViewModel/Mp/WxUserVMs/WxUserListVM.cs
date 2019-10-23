using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxUserVMs
{
    public partial class WxUserListVM : BasePagedListVM<WxUser_View, WxUserSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                //this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.Create, "新建","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.Edit, "修改","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.Delete, "删除", "Mp",dialogWidth: 800),
                this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.Details, "详细","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.BatchEdit, "批量修改","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.BatchDelete, "批量删除","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.Import, "导入","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxUser", GridActionStandardTypesEnum.ExportExcel, "导出","Mp"),
            };
        }

        protected override IEnumerable<IGridColumn<WxUser_View>> InitGridHeader()
        {
            return new List<GridColumn<WxUser_View>>{
                this.MakeGridHeader(x => x.OpenId).SetWidth(250),
                this.MakeGridHeader(x => x.NickName),
                this.MakeGridHeader(x => x.AvatarUrl).SetFormat(PhotoIdFormat),
                this.MakeGridHeader(x => x.Gender),
                this.MakeGridHeader(x => x.Country),
                this.MakeGridHeader(x => x.Province),
                this.MakeGridHeader(x => x.City),
                this.MakeGridHeader(x => x.Language),
                this.MakeGridHeader(x => x.CreateTime).SetSort(true).SetWidth(180),
                this.MakeGridHeaderAction(width: 100)
            };
        }

        private string PhotoIdFormat(WxUser_View entity, object val)
        {
            return $"<img src='{entity.AvatarUrl}' width='50' height='30'/>";
        }

        public override IOrderedQueryable<WxUser_View> GetSearchQuery()
        {
            var query = DC.Set<WxUser>()
                .CheckContain(Searcher.OpenId, x => x.OpenId)
                .CheckContain(Searcher.NickName, x => x.NickName)
                .CheckEqual(Searcher.Gender, x => x.Gender)
                .Select(x => new WxUser_View
                {
                    ID = x.ID,
                    OpenId = x.OpenId,
                    NickName = x.NickName,
                    AvatarUrl = x.AvatarUrl,
                    Gender = x.Gender,
                    Country = x.Country,
                    Province = x.Province,
                    City = x.City,
                    Language = x.Language,
                    CreateTime = x.CreateTime,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class WxUser_View : WxUser
    {

    }
}
