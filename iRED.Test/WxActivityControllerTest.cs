using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WalkingTec.Mvvm.Core;
using iRED.Controllers;
using iRED.ViewModel.Mp.WxActivityVMs;
using iRED.Model;
using iRED.DataAccess;

namespace iRED.Test
{
    [TestClass]
    public class WxActivityControllerTest
    {
        private WxActivityController _controller;
        private string _seed;

        public WxActivityControllerTest()
        {
            _seed = Guid.NewGuid().ToString();
            _controller = MockController.CreateController<WxActivityController>(_seed, "user");
        }

        [TestMethod]
        public void SearchTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            string rv2 = _controller.Search(rv.Model as WxActivityListVM);
            Assert.IsTrue(rv2.Contains("\"Code\":200"));
        }

        [TestMethod]
        public void CreateTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Create();
            Assert.IsInstanceOfType(rv.Model, typeof(WxActivityVM));

            WxActivityVM vm = rv.Model as WxActivityVM;
            WxActivity v = new WxActivity();
			
            v.ID = 71;
            v.Name = "NTmUe";
            v.Description = "iHL6";
            vm.Entity = v;
            _controller.Create(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxActivity>().FirstOrDefault();
				
                Assert.AreEqual(data.ID, 71);
                Assert.AreEqual(data.Name, "NTmUe");
                Assert.AreEqual(data.Description, "iHL6");
                Assert.AreEqual(data.CreateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.CreateTime.Value).Seconds < 10);
            }

        }

        [TestMethod]
        public void EditTest()
        {
            WxActivity v = new WxActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
       			
                v.ID = 71;
                v.Name = "NTmUe";
                v.Description = "iHL6";
                context.Set<WxActivity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Edit(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxActivityVM));

            WxActivityVM vm = rv.Model as WxActivityVM;
            v = new WxActivity();
            v.ID = vm.Entity.ID;
       		
            v.Name = "7f7";
            v.Description = "PKWlwh";
            vm.Entity = v;
            vm.FC = new Dictionary<string, object>();
			
            vm.FC.Add("Entity.ID", "");
            vm.FC.Add("Entity.Name", "");
            vm.FC.Add("Entity.Description", "");
            _controller.Edit(vm);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                var data = context.Set<WxActivity>().FirstOrDefault();
 				
                Assert.AreEqual(data.Name, "7f7");
                Assert.AreEqual(data.Description, "PKWlwh");
                Assert.AreEqual(data.UpdateBy, "user");
                Assert.IsTrue(DateTime.Now.Subtract(data.UpdateTime.Value).Seconds < 10);
            }

        }


        [TestMethod]
        public void DeleteTest()
        {
            WxActivity v = new WxActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
        		
                v.ID = 71;
                v.Name = "NTmUe";
                v.Description = "iHL6";
                context.Set<WxActivity>().Add(v);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.Delete(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(WxActivityVM));

            WxActivityVM vm = rv.Model as WxActivityVM;
            v = new WxActivity();
            v.ID = vm.Entity.ID;
            vm.Entity = v;
            _controller.Delete(v.ID.ToString(),null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxActivity>().Count(), 1);
            }

        }


        [TestMethod]
        public void DetailsTest()
        {
            WxActivity v = new WxActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v.ID = 71;
                v.Name = "NTmUe";
                v.Description = "iHL6";
                context.Set<WxActivity>().Add(v);
                context.SaveChanges();
            }
            PartialViewResult rv = (PartialViewResult)_controller.Details(v.ID.ToString());
            Assert.IsInstanceOfType(rv.Model, typeof(IBaseCRUDVM<TopBasePoco>));
            Assert.AreEqual(v.ID, (rv.Model as IBaseCRUDVM<TopBasePoco>).Entity.GetID());
        }

        [TestMethod]
        public void BatchDeleteTest()
        {
            WxActivity v1 = new WxActivity();
            WxActivity v2 = new WxActivity();
            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
				
                v1.ID = 71;
                v1.Name = "NTmUe";
                v1.Description = "iHL6";
                v2.Name = "7f7";
                v2.Description = "PKWlwh";
                context.Set<WxActivity>().Add(v1);
                context.Set<WxActivity>().Add(v2);
                context.SaveChanges();
            }

            PartialViewResult rv = (PartialViewResult)_controller.BatchDelete(new string[] { v1.ID.ToString(), v2.ID.ToString() });
            Assert.IsInstanceOfType(rv.Model, typeof(WxActivityBatchVM));

            WxActivityBatchVM vm = rv.Model as WxActivityBatchVM;
            vm.Ids = new string[] { v1.ID.ToString(), v2.ID.ToString() };
            _controller.DoBatchDelete(vm, null);

            using (var context = new DataContext(_seed, DBTypeEnum.Memory))
            {
                Assert.AreEqual(context.Set<WxActivity>().Count(), 2);
            }
        }

        [TestMethod]
        public void ExportTest()
        {
            PartialViewResult rv = (PartialViewResult)_controller.Index();
            Assert.IsInstanceOfType(rv.Model, typeof(IBasePagedListVM<TopBasePoco, BaseSearcher>));
            IActionResult rv2 = _controller.ExportExcel(rv.Model as WxActivityListVM);
            Assert.IsTrue((rv2 as FileContentResult).FileContents.Length > 0);
        }


    }
}
