namespace ObjectOrientedDesignPrinciples
{
    /// <summary>
    /// Garage is only one
    /// </summary>
    public sealed class Garage
    {
        private static Garage _instance;
        private static List<Automobile> automobiles = new List<Automobile>();
        public List<Automobile> Automobiles
        {
            get { return automobiles; }
        }

        private Garage() { } //Constructor hide always

        public static Garage GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Garage();
            }
            return _instance;
        }

        public void AddToGarage(Automobile newAuto)
        {
            automobiles.Add(newAuto);
        }
    }
}
