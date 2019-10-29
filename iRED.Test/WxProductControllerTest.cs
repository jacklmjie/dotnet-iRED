using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using iRED.Controllers;
using iRED.ViewModel.Mp.WxProductVMs;
using iRED.Model;
using iRED.DataAccess;

namespace iRED.Test
{
    [TestClass]
    public class WxProductControllerTest
    {
        private WxProductController _controller;
        private string _seed;

        public WxProductControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<WxProductController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as WxProductListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(WxProductVM));

            WxProductVM vm = rv.Model as WxProductVM;
            WxProduct v = new WxProduct();
			
            v.ID = 41;
            v.Name = "2QFM62s3";
            v.VenueId = AddVenue();
            v.Price = 33;
            v.AvailableStock = 24;
            v.Description = "XhKg7NCQK";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxProduct>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 41);
                Assert.AreEqual(data.Name, "2QFM62s3");
                Assert.AreEqual(data.Price, 33);
                Assert.AreEqual(data.AvailableStock, 24);
                Assert.AreEqual(data.Description, "XhKg7NCQK");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            WxProduct v = new WxProduct();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 41;
                v.Name = "2QFM62s3";
                v.VenueId = AddVenue();
                v.Price = 33;
                v.AvailableStock = 24;
                v.Description = "XhKg7NCQK";
                context.Set<WxProduct>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxProductVM));

            WxProductVM vm = rv.Model as WxProductVM;
            v = new WxProduct();
            v.ID = vm.Entity.ID;
       		
            v.Name = "pmOS9wR";
            v.Price = 83;
            v.AvailableStock = 94;
            v.Description = "RG1wBqk";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.VenueId", "");
            vm.FC.Add("Entity.Price", "");
            vm.FC.Add("Entity.AvailableStock", "");
            vm.FC.Add("Entity.Description", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxProduct>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "pmOS9wR");
                Assert.AreEqual(data.Price, 83);
                Assert.AreEqual(data.AvailableStock, 94);
                Assert.AreEqual(data.Description, "RG1wBqk");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            WxProduct v = new WxProduct();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 41;
                v.Name = "2QFM62s3";
                v.VenueId = AddVenue();
                v.Price = 33;
                v.AvailableStock = 24;
                v.Description = "XhKg7NCQK";
                context.Set<WxProduct>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxProductVM));

            WxProductVM vm = rv.Model as WxProductVM;
            v = new WxProduct();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxProduct>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            WxProduct v = new WxProduct();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 41;
                v.Name = "2QFM62s3";
                v.VenueId = AddVenue();
                v.Price = 33;
                v.AvailableStock = 24;
                v.Description = "XhKg7NCQK";
                context.Set<WxProduct>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            WxProduct v1 = new WxProduct();
            WxProduct v2 = new WxProduct();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 41;
                v1.Name = "2QFM62s3";
                v1.VenueId = AddVenue();
                v1.Price = 33;
                v1.AvailableStock = 24;
                v1.Description = "XhKg7NCQK";
                v2.Name = "pmOS9wR";
                v2.VenueId = v1.VenueId; 
                v2.Price = 83;
                v2.AvailableStock = 94;
                v2.Description = "RG1wBqk";
                context.Set<WxProduct>().Add(v1);
                context.Set<WxProduct>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(WxProductBatchVM));

            WxProductBatchVM vm = rv.Model as WxProductBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxProduct>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as WxProductListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }

        private Int32 AddVenue()
        {
            WxVenue v = new WxVenue();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 99;
                v.Name = "QEC";
                v.Description = "BduPTd";
                context.Set<WxVenue>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
