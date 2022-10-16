using System;
using System.IO;
using System.Runtime.Serialization;
using Workshop.Common;

namespace Workshop.CSharp.Data.SampleData
{
    public static class DataProvider
    {
        private static string GetFilePath(string fileName)
        {
            return Path.Combine(Environment.CurrentDirectory, "Data/SampleData/" + fileName);
        }
        private static Product[]? _products;
        public static Product[] Products
        {
            get
            {
                return _products ??= File.ReadAllText(GetFilePath("Products.xml")).Deserialize<Product[]>();
            }
        }

        private static Category[]? _categories;
        public static Category[] Categories
        {
            get { return (_categories ??= File.ReadAllText(GetFilePath("Categories.xml")).Deserialize<Category[]>()); }
        }
    }

    [DataContract(Namespace = "")]
    public class Category
    {
        [DataMember]
        public int CategoryID { get; set; }
        [DataMember]
        public string? CategoryName { get; set; }
        [DataMember]
        public string? Description { get; set; }
    }

    [DataContract(Namespace = "")]
    public class Product
    {
        [DataMember]
        public int ProductID { get; set; }
        [DataMember]
        public string? ProductName { get; set; }
        [DataMember]
        public Nullable<int> SupplierID { get; set; }
        [DataMember]
        public int? CategoryID { get; set; }
        [DataMember]
        public string? QuantityPerUnit { get; set; }
        [DataMember]
        public Nullable<decimal> UnitPrice { get; set; }
        [DataMember]
        public Nullable<short> UnitsInStock { get; set; }
        [DataMember]
        public Nullable<short> UnitsOnOrder { get; set; }
        [DataMember]
        public Nullable<short> ReorderLevel { get; set; }
        [DataMember]
        public bool Discontinued { get; set; }
    }

}
