using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Management.Domain.Entities
{
    public class Part
    {
        [BsonId] //Configura propriedade Id para ClassModel
        [BsonRepresentation(BsonType.ObjectId)] //Permite fazer conversão de string para ObjectId
        public string Id { get; set; }

        [BsonElement("Name")] //Mapeamento de nome para BSonValue
        public string Name { get; set; } //Nome da peça: Antena, Auto-falante, (Bateria)

        public string Category { get; set; } //Accessory, Console, Laptops, Other, (Phone), 
        public string Make { get; set; } //JBL, (Samsung), Philips, 
        public string Model { get; set; } // (J7PRO)
        public string Note { get; set; }
        public string ImageFile { get; set; }
        public decimal Price { get; set; } //(R$ 120,00)
        public decimal RepairedPrice { get; set; } //(R$ 100.00) 
    }
}
