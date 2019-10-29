using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using iRED.Controllers;
using iRED.ViewModel.Mp.WxVenueVMs;
using iRED.Model;
using iRED.DataAccess;

namespace iRED.Test
{
    [TestClass]
    public class WxVenueControllerTest
    {
        private WxVenueController _controller;
        private string _seed;

        public WxVenueControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<WxVenueController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as WxVenueListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(WxVenueVM));

            WxVenueVM vm = rv.Model as WxVenueVM;
            WxVenue v = new WxVenue();
			
            v.ID = 85;
            v.Name = "2U5j0WVaf";
            v.Description = "JmD";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxVenue>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 85);
                Assert.AreEqual(data.Name, "2U5j0WVaf");
                Assert.AreEqual(data.Description, "JmD");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            WxVenue v = new WxVenue();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 85;
                v.Name = "2U5j0WVaf";
                v.Description = "JmD";
                context.Set<WxVenue>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxVenueVM));

            WxVenueVM vm = rv.Model as WxVenueVM;
            v = new WxVenue();
            v.ID = vm.Entity.ID;
       		
            v.Name = "w0t";
            v.Description = "FPoq8CN";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Description", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxVenue>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "w0t");
                Assert.AreEqual(data.Description, "FPoq8CN");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            WxVenue v = new WxVenue();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 85;
                v.Name = "2U5j0WVaf";
                v.Description = "JmD";
                context.Set<WxVenue>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxVenueVM));

            WxVenueVM vm = rv.Model as WxVenueVM;
            v = new WxVenue();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxVenue>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            WxVenue v = new WxVenue();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 85;
                v.Name = "2U5j0WVaf";
                v.Description = "JmD";
                context.Set<WxVenue>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            WxVenue v1 = new WxVenue();
            WxVenue v2 = new WxVenue();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 85;
                v1.Name = "2U5j0WVaf";
                v1.Description = "JmD";
                v2.Name = "w0t";
                v2.Description = "FPoq8CN";
                context.Set<WxVenue>().Add(v1);
                context.Set<WxVenue>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(WxVenueBatchVM));

            WxVenueBatchVM vm = rv.Model as WxVenueBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxVenue>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as WxVenueListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
