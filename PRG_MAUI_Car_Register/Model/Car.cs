namespace PRG_MAUI_Car_Register.Model
{
    class Car : Vehicle
    {
        private int doors = 5;

        public int Doors
        {
            get { return doors; } 
            set 
            {
                if (value < 2 || value > 5)
                    throw new ArgumentException("En bil måste ha mellan 2 och 5 dörrar.");
                doors = value;
            }
        }
        public Car(): base()
        {
        }
        public override string GetDescription()
        {
            return RegistrationNumber + "\t" + "Bil" + "\t" + Manufacturer + "\t" + Model + "\t" + Year; 
        }
    }
}