namespace ASPwithDb.Data
{
    public class Product
    {
        public int Id { get; set; } //PK
        public string Name { get; set; }
        public string Discription { get; set; }
        public int TypeProductsId { get; set; } //FK
        public TypeProduct TypeProducts { get; set; } //Relation with table
        public DateTime DateModification { get; set; }

    }
}
