using MvcSiteMapProvider;
using MvcSiteMapProvider.Web.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace _20202c_Ejemplo_breadcrumb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult MisConsorcios()
        {
            return View();
        }

        [SiteMapTitle("title")]
        public ActionResult EditarConsorcio(int id)
        {
            ViewData["Title"] = "Consorcio \"Villanova\"";
            return View();
        }
        public ActionResult ListaUnidades()
        {
            SetConsorcioBreadcrumbTitle();
            return View();
        }

        public ActionResult NuevaUnidad()
        {
            SetConsorcioBreadcrumbTitle();

            return View();
        }

        private static void SetConsorcioBreadcrumbTitle()
        {
            string nombreConsorcio = "Villanova";
            var node = SiteMaps.Current.CurrentNode;
            FindParentNode(node, "ConsorcioX", $"Consorcio \"{nombreConsorcio}\"");
        }

        private static void FindParentNode(ISiteMapNode node, string oldTitle, string newTitle)
        {
            if (node.Title == oldTitle)
            {
                node.Title = newTitle;
            }
            else
            {
                if (node.ParentNode != null)
                {
                    FindParentNode(node.ParentNode, oldTitle, newTitle);
                }
            }
        }

    }
}