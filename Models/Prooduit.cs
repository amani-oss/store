using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace Esshop.Models
{
	
	public class Prooduit
	{
        [Key]
        public int Id { get; set; }
		[Required(ErrorMessage="Veuillez saisir un nom")]
		public string NomProduit { get; set; }
		public int Quantite { get; set; }
		[DataType(DataType.MultilineText)]
		public string Description { get; set; }
		public int Prix { get; set; }

		public byte[] ProduitImage { get; set; }
		public string ProduitImageType { get; set; }
    }
}