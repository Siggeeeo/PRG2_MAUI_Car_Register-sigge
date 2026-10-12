namespace PRG_MAUI_Car_Register.Model
{
    class Truck : Vehicle
    {
        public Truck() : base()
        {
        }
        public override string GetDescription()
        {
            return RegistrationNumber + "\t" + "Lastbil" + "\t" + Manufacturer + "\t" + Model + "\t" + Year;
        }
    }
}