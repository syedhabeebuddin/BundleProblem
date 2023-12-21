using System.Text;

namespace BundlesProblem.Algorithm
{
    public class Inventory
    {
        public string Name { get; private set; }
        public int Quantity { get; private set; }
        public bool IsAFinishedProduct { get; private set; }
        private List<Inventory> Parts { get; set; }

        public Inventory(string name, int quantity, bool isAFinishedProduct)
        {
            Name = name;
            Quantity = quantity;
            IsAFinishedProduct = isAFinishedProduct;
            Parts = new List<Inventory>();
        }

        public Inventory AddPart(Inventory inventory)
        {
            Parts.Add(inventory);
            return this;
        }

        public int GetCountOfProducts(List<Inventory> inventories)
        {
            List<Inventory> leafnodes = new List<Inventory>();
            GetLeafNodes(this, ref leafnodes);
            int countOfProducts = inventories.OrderByDescending(x => x.Quantity).First().Quantity;
            foreach (Inventory leafNode in leafnodes)
            {
                var availableStock = inventories.FirstOrDefault(x => x.Name == leafNode.Name)?.Quantity;
                var count = availableStock / leafNode.Quantity ?? 0;

                if (count < countOfProducts)
                    countOfProducts = count;
            }

            return countOfProducts;
        }       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Name} is assembled with");
            for (int i = 1; i <= this.Parts.Count; i++)
            {
                var part = this.Parts[i - 1];
                sb.Append($" {part.Quantity} {part.Name}");

                if (part.Quantity > 1)
                    sb.Append("s");

                if (i <= this.Parts.Count - 1)
                    sb.Append(",");

                if (i == this.Parts.Count - 1)
                    sb.Append(" and");
            }

            return sb.ToString();
        }

        private void GetLeafNodes(Inventory inventoryItem, ref List<Inventory> nodes)
        {
            if (inventoryItem.Parts.Count == 0)
                nodes.Add(inventoryItem);

            foreach (var item in inventoryItem.Parts)
            {
                GetLeafNodes(item, ref nodes);
            }

        }

        //Another approach for getting leaf nodes
        //private List<Inventory> leafNodes = new List<Inventory>();
        //private void GetLeafNodes(Inventory inventoryItem)
        //{
        //    if (inventoryItem.Parts.Count == 0)
        //        leafNodes.Add(inventoryItem);

        //    foreach (var item in inventoryItem.Parts)
        //    {
        //        GetLeafNodes(item);
        //    }

        //}
    }
}
