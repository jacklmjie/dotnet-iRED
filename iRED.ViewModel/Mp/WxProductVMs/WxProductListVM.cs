using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxProductVMs
{
    public partial class WxProductListVM : BasePagedListVM<WxProduct_View, WxProductSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.Create, "新建","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.Edit, "修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.Delete, "删除", "Mp",dialogWidth: 800),
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.Details, "详细","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.BatchEdit, "批量修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.BatchDelete, "批量删除","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.Import, "导入","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxProduct", GridActionStandardTypesEnum.ExportExcel, "导出","Mp"),
            };
        }

        protected override IEnumerable<IGridColumn<WxProduct_View>> InitGridHeader()
        {
            return new List<GridColumn<WxProduct_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Name_view),
                this.MakeGridHeader(x => x.PictureId).SetFormat(PictureIdFormat),
                this.MakeGridHeader(x => x.Price),
                this.MakeGridHeader(x => x.AvailableStock),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PictureIdFormat(WxProduct_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PictureId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PictureId,640,480),
            };
        }


        public override IOrderedQueryable<WxProduct_View> GetSearchQuery()
        {
            var query = DC.Set<WxProduct>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new WxProduct_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Name_view = x.Venue.Name,
                    PictureId = x.PictureId,
                    Price = x.Price,
                    AvailableStock = x.AvailableStock,
                    Description = x.Description,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class WxProduct_View : WxProduct{
        [Display(Name = "名称")]
        public String Name_view { get; set; }

    }
}
