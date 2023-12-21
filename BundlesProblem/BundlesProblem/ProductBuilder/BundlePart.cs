namespace BundlesProblem.ProductBuilder
{
    public class BundlePart
    {
        public string Name { get; private set; }
        public BundlePart(string name)
        {
            Name = name;
        }
    }
}
