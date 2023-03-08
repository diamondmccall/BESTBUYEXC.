using System;
using System.Collections.Generic;
using System.Data.Common;

namespace BESTBUYEXC
{
	public interface IProductRepository
	{
		IEnumerable<Product> GetAllProducts();

		public void CreateProduct(string name, double price, int categoryID);

        public void UpdateProductName(int productID, string updatedName);

		public void DeleteProduct(int productID);
    }
}

