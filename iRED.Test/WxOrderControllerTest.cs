using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using iRED.Controllers;
using iRED.ViewModel.Mp.WxOrderVMs;
using iRED.Model;
using iRED.DataAccess;

namespace iRED.Test
{
    [TestClass]
    public class WxOrderControllerTest
    {
        private WxOrderController _controller;
        private string _seed;

        public WxOrderControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<WxOrderController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as WxOrderListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(WxOrderVM));

            WxOrderVM vm = rv.Model as WxOrderVM;
            WxOrder v = new WxOrder();
			
            v.ID = 16;
            v.OrderTotal = 12;
            v.UserId = AddUser();
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxOrder>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 16);
                Assert.AreEqual(data.OrderTotal, 12);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            WxOrder v = new WxOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 16;
                v.OrderTotal = 12;
                v.UserId = AddUser();
                context.Set<WxOrder>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxOrderVM));

            WxOrderVM vm = rv.Model as WxOrderVM;
            v = new WxOrder();
            v.ID = vm.Entity.ID;
       		
            v.OrderTotal = 35;
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.OrderTotal", "");
            vm.FC.Add("Entity.UserId", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxOrder>().FirstOrDefault();
 				
                Assert.AreEqual(data.OrderTotal, 35);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            WxOrder v = new WxOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 16;
                v.OrderTotal = 12;
                v.UserId = AddUser();
                context.Set<WxOrder>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxOrderVM));

            WxOrderVM vm = rv.Model as WxOrderVM;
            v = new WxOrder();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxOrder>().Count(), 0);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            WxOrder v = new WxOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 16;
                v.OrderTotal = 12;
                v.UserId = AddUser();
                context.Set<WxOrder>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            WxOrder v1 = new WxOrder();
            WxOrder v2 = new WxOrder();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 16;
                v1.OrderTotal = 12;
                v1.UserId = AddUser();
                v2.OrderTotal = 35;
                v2.UserId = v1.UserId; 
                context.Set<WxOrder>().Add(v1);
                context.Set<WxOrder>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(WxOrderBatchVM));

            WxOrderBatchVM vm = rv.Model as WxOrderBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxOrder>().Count(), 0);
            }
        }

        private Int32 AddUser()
        {
            WxUser v = new WxUser();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {

                v.ID = 28;
                context.Set<WxUser>().Add(v);
                context.SaveChanges();
            }
            return v.ID;
        }


    }
}
