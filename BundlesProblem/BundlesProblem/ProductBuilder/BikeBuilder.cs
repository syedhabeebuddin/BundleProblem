using System.Text;

namespace BundlesProblem.ProductBuilder
{
    public class BikeBuilder : IBundleBuilder
    {
        private IList<BundlePart> parts;

        public BikeBuilder()
        {
            parts = new List<BundlePart>();
        }
        public IBundleBuilder AddPart(BundlePart product)
        {
            parts.Add(product);
            return this;
        }

        public string AssembleParts()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Bike is assembled with");

            foreach (var item in parts)
            {
                sb.Append($" {item.Name}");
            }

            return sb.ToString();
        }
    }
}
