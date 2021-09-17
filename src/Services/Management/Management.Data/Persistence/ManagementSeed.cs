using Management.Domain.Entities;
using MongoDB.Driver;

namespace Management.Data.Persistence
{
    public class ManagementSeed
    {
        public static void SeedDataBase(IMongoCollection<Part> productCollection)
        {
            bool existingProduct = productCollection.Find(p => true).Any();
            if (!existingProduct)
            {
                productCollection.InsertManyAsync(GetPreconfiguredProducts());
            }
        }

        private static IEnumerable<Part> GetPreconfiguredProducts()
        {
            return new List<Part>()
            {
                new Part()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "Bateria chinaTest",
                    Make = "JBL",
                    Model = "Flip/3",
                    Category = "Som", //Type
                    Note = "Garantia de 3 meses.",
                    ImageFile = "peça-1.png",
                    Price = 89.90M,
                    RepairedPrice = 50.90M
                },
                new Part()
                {
                    Id = "602d2149e773f2a3990b47f6",
                    Name = "Disply",
                    Make = "Samsung",
                    Model = "J7/PRO",
                    Category = "Celular",
                    Note = "Sem garantia, teste no ato da entrega!",
                    ImageFile = "peça-2.png",
                    Price = 189.90M,
                    RepairedPrice = 90.90M
                },
                new Part()
                {
                    Id = "602d2149e773f2a3990b47f7",
                    Name = "Alto-Falante",
                    Make = "JBL",
                    Model = "Boombox-2",
                    Category = "Som",
                    Note = "Sem garantia, teste no ato da entrega!",
                    ImageFile = "peça-3.png",
                    Price = 189.90M,
                    RepairedPrice = 90.90M
                },
                new Part()
                {
                    Id = "602d2149e773f2a3990b47f8",
                    Name = "Display/LED",
                    Make = "Samsung",
                    Model = "AJQ32",
                    Category = "Tv",
                    Note = "Display para Tv de 32, em otimo estado",
                    ImageFile = "peça-4.png",
                    Price = 159.90M,
                    RepairedPrice = 90.90M
                },
                new Part()
                {
                    Id = "602d2149e773f2a3990b47f9",
                    Name = "Bateria",
                    Make = "JBL",
                    Model = "Flip/3",
                    Category = "Som",
                    Note = "Bateria/Vendas Shoppe",
                    ImageFile = "peça-5.png",
                    Price = 159.90M,
                    RepairedPrice = 90.90M
                },
                new Part()
                {
                    Id = "602d2149e773f2a3990b47fa",
                    Name = "Memoria DDR4",
                    Make = "JBL",
                    Model = "Flip/3",
                    Category = "Notebook",
                    Note = "Bateria/Vendas Shoppe",
                    ImageFile = "peça-5.png",
                    Price = 159.90M,
                    RepairedPrice = 90.90M
                }
            };
        }
    }
}
