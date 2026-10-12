namespace PRG_MAUI_Car_Register.Model
{
    class Car : Vehicle
    {
        public Car(): base()
        {
        }
        public override string GetDescription()
        {
            return RegistrationNumber + "\t" + "Bil" + "\t" + Manufacturer + "\t" + Model + "\t" + Year; 
        }
    }
}