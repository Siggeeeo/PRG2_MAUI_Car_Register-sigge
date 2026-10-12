namespace PRG_MAUI_Car_Register.Model
{
    class Truck : Vehicle
    {

        private double loadCapacity = 10;
        public double LoadCapacity
        {
            get { return loadCapacity; } set {   if (value <= 0 || value > 50)
                    throw new ArgumentException("Lastkapaciteten måste vara mer än 0 och högst 50 ton.");

                loadCapacity = value;
            }
        }
        public Truck() : base()
        {
        }
        public override string GetDescription()
        {
            return RegistrationNumber + "\t" + "Lastbil" + "\t" + Manufacturer + "\t" + Model + "\t" + Year;
        }
    }
}