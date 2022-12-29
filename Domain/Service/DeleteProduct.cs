using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Domain.Interfaces.Command;
using Domain.Interfaces.Repository;
using Domain;

namespace Domain.Service
{
	public class DeleteProduct : IDeleteProduct
	{
		
        public void Execute(long dltProduct)
        {
			 DomainBase.Provider.GetService<IProductRepository>().DeleteProduct(dltProduct);
		}
    }
}
