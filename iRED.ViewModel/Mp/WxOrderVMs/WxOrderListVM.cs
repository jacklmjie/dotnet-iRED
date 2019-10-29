using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxOrderVMs
{
    public partial class WxOrderListVM : BasePagedListVM<WxOrder_View, WxOrderSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                //this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.Create, "新建","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.Edit, "修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.Delete, "删除", "Mp",dialogWidth: 800),
                this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.Details, "详细","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.BatchEdit, "批量修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.BatchDelete, "批量删除","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.Import, "导入","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxOrder", GridActionStandardTypesEnum.ExportExcel, "导出","Mp"),
            };
        }

        protected override IEnumerable<IGridColumn<WxOrder_View>> InitGridHeader()
        {
            return new List<GridColumn<WxOrder_View>>{
                this.MakeGridHeader(x => x.OrderNumber),
                this.MakeGridHeader(x => x.OrderTotal),
                this.MakeGridHeader(x => x.NickName_view),
                this.MakeGridHeader(x => x.UserAddress),
                this.MakeGridHeader(x => x.UserPhone),
                this.MakeGridHeader(x => x.CreateTime),
                this.MakeGridHeader(x => x.OrderStatus),
                this.MakeGridHeader(x => x.PayStatus),
                this.MakeGridHeader(x => x.GoodsStatus),
                this.MakeGridHeaderAction(width: 200)
            };
        }

        public override IOrderedQueryable<WxOrder_View> GetSearchQuery()
        {
            var query = DC.Set<WxOrder>()
                .CheckContain(Searcher.OrderNumber, x=>x.OrderNumber)
                .CheckEqual(Searcher.OrderStatus, x=>x.OrderStatus)
                .CheckEqual(Searcher.PayStatus, x=>x.PayStatus)
                .CheckEqual(Searcher.GoodsStatus, x=>x.GoodsStatus)
                .Select(x => new WxOrder_View
                {
				    ID = x.ID,
                    OrderNumber = x.OrderNumber,
                    OrderTotal = x.OrderTotal,
                    NickName_view = x.User.NickName,
                    UserAddress = x.UserAddress,
                    UserPhone = x.UserPhone,
                    CreateTime = x.CreateTime,
                    OrderStatus = x.OrderStatus,
                    PayStatus = x.PayStatus,
                    GoodsStatus = x.GoodsStatus,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class WxOrder_View : WxOrder{
        [Display(Name = "昵称")]
        public String NickName_view { get; set; }

    }
}
