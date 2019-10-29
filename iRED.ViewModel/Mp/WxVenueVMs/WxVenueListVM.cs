using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WalkingTec.Mvvm.Core;
using WalkingTec.Mvvm.Core.Extensions;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using iRED.Model;


namespace iRED.ViewModel.Mp.WxVenueVMs
{
    public partial class WxVenueListVM : BasePagedListVM<WxVenue_View, WxVenueSearcher>
    {
        protected override List<GridAction> InitGridAction()
        {
            return new List<GridAction>
            {
                this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.Create, "新建","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.Edit, "修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.Delete, "删除", "Mp",dialogWidth: 800),
                this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.Details, "详细","Mp", dialogWidth: 800),
                //this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.BatchEdit, "批量修改","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.BatchDelete, "批量删除","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.Import, "导入","Mp", dialogWidth: 800),
                this.MakeStandardAction("WxVenue", GridActionStandardTypesEnum.ExportExcel, "导出","Mp"),
            };
        }

        protected override IEnumerable<IGridColumn<WxVenue_View>> InitGridHeader()
        {
            return new List<GridColumn<WxVenue_View>>{
                this.MakeGridHeader(x => x.Name),
                this.MakeGridHeader(x => x.PictureId).SetFormat(PictureIdFormat),
                this.MakeGridHeader(x => x.Description),
                this.MakeGridHeaderAction(width: 200)
            };
        }
        private List<ColumnFormatInfo> PictureIdFormat(WxVenue_View entity, object val)
        {
            return new List<ColumnFormatInfo>
            {
                ColumnFormatInfo.MakeDownloadButton(ButtonTypesEnum.Button,entity.PictureId),
                ColumnFormatInfo.MakeViewButton(ButtonTypesEnum.Button,entity.PictureId,640,480),
            };
        }


        public override IOrderedQueryable<WxVenue_View> GetSearchQuery()
        {
            var query = DC.Set<WxVenue>()
                .CheckContain(Searcher.Name, x=>x.Name)
                .Select(x => new WxVenue_View
                {
				    ID = x.ID,
                    Name = x.Name,
                    PictureId = x.PictureId,
                    Description = x.Description,
                })
                .OrderBy(x => x.ID);
            return query;
        }

    }

    public class WxVenue_View : WxVenue{

    }
}
