using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Esshop.Models
{
    public class ProoduitsController : Controller
    {
        EsshopContext Context = new EsshopContext();

        // ✅ هذه دالة البداية
        public ActionResult Index()
        {
            return RedirectToAction("ListeProoduit");
        }

        public ActionResult ListeProoduit()
        {
            return View("ListeProoduit", Context.Prooduits.ToList());
        }

        public ActionResult AfficherProoduit(int id)
        {
            Prooduit p = Context.Prooduits.Find(id);
            if (p != null)
            {
                return View("AfficherProoduit", p);
            }
            else return HttpNotFound();
        }

        public ActionResult AjouterProoduit()
        {
            Prooduit p = new Prooduit();
            return View("AjouterProoduit", p);
        }

        [HttpPost]
        public ActionResult AjouterProoduit(Prooduit p,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                if (Image != null)
                {
                    p.ProduitImageType = Image.ContentType;
                    p.ProduitImage = new byte[Image.ContentLength];
                    Image.InputStream.Read(p.ProduitImage, 0, Image.ContentLength);
                }
                Context.Prooduits.Add(p);
                Context.SaveChanges();
                return RedirectToAction("ListeProoduit");
            }
            else return View("AjouterProoduit", p);
        }

        public ActionResult ListeSuppression()
        {
            return View("ListeSuppression", Context.Prooduits.ToList());
        }

        public ActionResult Supprimer(int id)
        {
            Prooduit p = Context.Prooduits.Find(id);
            if (p != null)
                return View("Supprimer", p);
            else return HttpNotFound();
        }

        [HttpPost, ActionName("Supprimer")]
        [ValidateAntiForgeryToken]
        public ActionResult ConfirmerSuppression(int id)
        {
            Prooduit p = Context.Prooduits.Find(id);
            if (p != null)
            {
                Context.Prooduits.Remove(p);
                Context.SaveChanges();
                return RedirectToAction("ListeSuppression");
            }
            else return HttpNotFound();
        }

        public ActionResult ListeModification()
        {
            return View("ListeModification", Context.Prooduits.ToList());
        }

        public ActionResult Modifier(int id)
        {
            Prooduit p = Context.Prooduits.Find(id);
            if (p != null)
            {
                return View("Modifier", p);
            }
            else return HttpNotFound();
        }
        [HttpPost,ActionName("Modifier")]
        [ValidateAntiForgeryToken]
        public ActionResult Modifier(Prooduit p)
        {
            if (ModelState.IsValid)
            {
                Context.Entry(p).State = EntityState.Modified;
                Context.SaveChanges();
                return View("ListeProoduit", Context.Prooduits.ToList());
            }
            else return View("Modifier", p);
        }
        public FileContentResult GetImage(int Id)
        {
            Prooduit p = new Prooduit();
            p = Context.Prooduits.Find(Id);
            if (p != null)
            
                return File(p.ProduitImage, p.ProduitImageType);
            
            else return null;
        }


    }
}
