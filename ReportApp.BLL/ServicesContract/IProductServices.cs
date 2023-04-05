using ReportApp.BLL.Dtos.Request;
using ReportApp.BLL.Dtos.Response;
using ReportApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportApp.BLL.ServicesContract
{
    public interface IProductServices
    {
        Task<ProductResponse> CreateProduct(CreateProductRequest product);
        Task DeleteProduct(Guid Id);
        ICollection<Product> GetAllProducts();
        IEnumerable<Product> GetProduct(Guid userId);
        Task<ProductResponse> UpdateProduct(UpdateProductRequest product);
    }
}
