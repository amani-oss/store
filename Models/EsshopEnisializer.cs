using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.IO;

namespace Esshop.Models
{
    public class EsshopEnisializer : DropCreateDatabaseIfModelChanges<EsshopContext>
    {
        protected override void Seed(EsshopContext context)
        {
            base.Seed(context);
            var prooduits = new List<Prooduit>
            {
                new Prooduit{NomProduit="Infinix",Quantite=10,Description="50 Hot pro plus",Prix=4000, ProduitImage=getFileBytes("/Images/InfinixNote50+.jpeg"),ProduitImageType="image/jpeg" },
                new Prooduit{NomProduit="PC",Quantite=20,Description="c est un PC  Dell  ",Prix=200, ProduitImage = getFileBytes("/Images/Dell.jpeg"), ProduitImageType = "image/jpeg" },
                new Prooduit{NomProduit="Imprimante ",Quantite=30,Description="c est une Imprimeante Dell",Prix=300, ProduitImage=getFileBytes("/Images/imprimante.jpeg"),ProduitImageType="image/jpeg" }
            }; 
            
            prooduits.ForEach(p => context.Prooduits.Add(p));
            context.SaveChanges();
        }
        
        private byte[] getFileBytes(string path)
        {
            FileStream fileOnDisk = new FileStream(HttpRuntime.AppDomainAppPath + path, FileMode.Open);
            byte[] fileBytes;
            using (BinaryReader br = new BinaryReader(fileOnDisk))
            {
                fileBytes = br.ReadBytes((int)fileOnDisk.Length);
            }
            return fileBytes;
        }
    }
}