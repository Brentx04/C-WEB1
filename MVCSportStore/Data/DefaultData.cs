namespace MVCSportStore.Data
{
    public static class DefaultData
    {
        public static IEnumerable<string> Products => GetProductList();

        private static IEnumerable<string> GetProductList()
        {
            //name;description;category;price
            List<string> products = new List<string>
            {
                "Kayak;A boat for one person;Watersports;275",
                "Lifejacket;Protective and fashionable;Watersports;48.95",
                "Soccer Ball;FIFA-approved size and weight;Soccer;19.50",
                "Corner Flags;Give your playing field a professional touch;Soccer;34.95",
                "Stadium;Flat-packed 35,000-seat stadium;Soccer;79500",
                "Thinking Cap;Improve brain efficiency by 75%;Chess;16",
                "Unsteady Chair;Secretly give your opponent a disadvantage;Chess;29.95",
                "Human Chess Board;A fun game for the family;Chess;75",
                "Bling-Bling King;Gold-plated, diamond-studded King;Chess;1200"
            };
            return products;
        }
    }
}
