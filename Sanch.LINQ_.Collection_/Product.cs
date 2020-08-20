
namespace Sanch.LINQ_.Collection_
{
    class Product
    {
        public string Name { get; set; }
        public int  Energy { get; set; }

        public override string ToString()
        {
            return $"{Name} ({Energy})";
        }
    }
}
