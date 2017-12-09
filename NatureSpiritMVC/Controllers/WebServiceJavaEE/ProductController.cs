using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NatureSpiritMVC.JavaEEServicesReference;
using NatureSpiritMVC.Models;
using NatureSpiritServices.Implements;

namespace NatureSpiritMVC.Controllers.WebServiceJavaEE
{
    public class ProductController : Controller
    {
        // <!--http://localhost:18080/nature-spirit-ejb/ServicesProduct/ServicesProductPortType!-->

        ProductServices ps = null;
        ServicesProductPortTypeClient client = null;

        public ProductController()
        {
            ps = new ProductServices();
            client = new ServicesProductPortTypeClient();
        }
        // GET: Product
        public ActionResult Index()
        {
           /* admin a = new admin();
            a.id_Admin = 1;
            */
            return View(client.getAllProductsForDotNet());
        }

        //Recherche
        [HttpPost]
        public ActionResult Index(string searchString)
        {
            var list_prod = ps.getAllProducts();
            List<ProductModels> ls = new List<ProductModels>();

            foreach (var item in list_prod)
            {
                ls.Add
                (
                   new ProductModels
                   {
                       id_Product = item.id_Product,
                       Availability = item.Availability,
                       Price = item.Price,
                       Type_Product = item.Type_Product
                   }
                 );
            }            

            if (!String.IsNullOrEmpty(searchString))
            {
                ls = ls.Where(m => m.Type_Product.ToLower().Contains(searchString)).ToList();
            }


            /* var les_news_members = mns.getAllNewsMember();
             List<MemberNewsModels> ls = new List<MemberNewsModels>();
             foreach (var item in les_news_members)
             {
                 ls.Add
                 (
                    new MemberNewsModels
                    {
                        Id_News = item.Id_News,
                        Id_Member = id_M,
                        Comment = item.Comment,
                        date_Of_Comment = item.date_Of_Comment
                    }
                  );
             }

             if (!String.IsNullOrEmpty(searchString))
             {
                 ls = ls.Where(m => m.news.title.ToLower().Contains(searchString)).ToList();
             }
             */
            return View(ls);
        }


        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
