namespace ASPwithDb.Data
{
    public class TypeProduct
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Discription { get; set; }
        public DateTime DateModification { get; set; } 
        public ICollection<Product> Products { get; set;}

    }
}