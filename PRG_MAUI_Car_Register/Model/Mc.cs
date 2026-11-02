namespace PRG_MAUI_Car_Register.Model
{
    abstract class Mc : Vehicle
    {
        private string category = "Standard";

        private static readonly string[] allowedCategories = { "Standard", "Sport", "Touring", "Custom", "Offroad" };

        public string Category { get { return category; }

            set 
            {
                if (!allowedCategories.Contains(value))
                    throw new ArgumentException("Kategorin måste vara Standard, Sport, Touring, Custom eller Offroad.");
                category = value;
            }
        }
        protected Mc() : base()
        {
        }
        public override string GetDescription()
        {
            return RegistrationNumber + "\t" + "Mc" + "\t" + Manufacturer + "\t" + Model + "\t" + Year;
        }
        public override string GetExtraInfo()
        {
            return "Kategori: " + Category;
        }
    }
}