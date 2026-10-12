namespace PRG_MAUI_Car_Register.Model
{
    class Mc : Vehicle
    {
        public Mc() : base()
        {
        }
        public override string GetDescription()
        {
            return RegistrationNumber + "\t" + "Mc" + "\t" + Manufacturer + "\t" + Model + "\t" + Year;
        }
    }
}