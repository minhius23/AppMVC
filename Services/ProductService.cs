using App.Models;

namespace App.Service
{
    public class ProductService : List<ProductModel>
    {
        public ProductService()
        {
            this.AddRange(new ProductModel[]{
                new ProductModel(){ID = 1, Name ="Hieu", Price=100},
                new ProductModel(){ID = 2, Name ="Cuong", Price=90},
                new ProductModel(){ID = 3, Name ="Đức", Price=120},
                new ProductModel(){ID = 4, Name ="Đô", Price=110}
            });
            
        }
    }
}