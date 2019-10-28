using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxActivityVMs
{
    public partial class WxActivityListVM : BasePagedListVM<WxActivity_View, WxActivitySearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.Create, "新建","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.Edit, "修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.Delete, "删除", "Mp",dialogWidth: 800),
                this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.Details, "详细","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.BatchEdit, "批量修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.BatchDelete, "批量删除","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.Import, "导入","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxActivity", GridActionStandardTypesEnum.ExportExcel, "导出","Mp"),
            };
        }

        protected override IEnumerable<IGridColumn<WxActivity_View>> InitGridHeader()
        {
            return new List<GridColumn<WxActivity_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeader(x => x.PictureId).SetFormat(PictureIdFormat),
                this.MakeGridHeader(x => x.BeginTime),
                this.MakeGridHeader(x => x.EndTime),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PictureIdFormat(WxActivity_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PictureId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PictureId,640,480),
            };
        }


        public override IOrderedQueryable<WxActivity_View> GetSearchQuery()
        {
            var query = DC.Set<WxActivity>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .CheckEqual(Searcher.BeginTime, x=>x.BeginTime)
                .CheckEqual(Searcher.EndTime, x=>x.EndTime)
                .Select(x => new WxActivity_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    Description = x.Description,
                    PictureId = x.PictureId,
                    BeginTime = x.BeginTime,
                    EndTime = x.EndTime,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class WxActivity_View : WxActivity{

    }
}
