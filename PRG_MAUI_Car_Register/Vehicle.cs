namespace PRG_MAUI_Car_Register
{
    class Vehicle
    {
        // Medlemsvariabler
        public enum Type { Bil, MC, Lastbil };
        private Type vehicleType;
        private string registrationNumber = string.Empty;
        private string manufacturer = string.Empty;
        private string model = string.Empty;

        // Konstruktor (en metod med samma namn som klassen, som returnerar ett objekt)
        public Vehicle(Type vehicleType) // en konstruktor kan, men måste inte, ta parametrar
        {
            this.vehicleType = vehicleType;
        }

        // Get-Set för att hålla variablerna privata, och för att validera inkommande värden från UI (user interface, användargränssnittet)
        public string RegistrationNumber
        {
            get { return registrationNumber; }

            set
            {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Ett registreringsnummer måste anges.");

                string text = value.Trim();

                if (text.Length != 6)
                    throw new ArgumentException("Inkorrekt registreringsnummer: det måste bestå av exakt 6 tecken, tre bokstäver följt av två siffror och en siffra eller bokstav.");

                for (int i = 0; i < 3; i++)
                {
                    if (!char.IsLetter(text[i]))
                        throw new ArgumentException("Inkorrekt registreringsnummer: De första tre tecknen måste vara bokstäver.");
                }

                for (int i = 3; i < 3; i++)
                {
                    if (i<5)
                    {
                        if (!char.IsDigit(text[i]))
                            throw new ArgumentException("Inkorrekt registreringsnummer: Det fjärde och femte tecknet måste vara siffror.");
                    }
                    else
                    {
                        if (!char.IsDigit(text[i]) && !char.IsLetter(text[i]))
                            throw new ArgumentException("Inkorrekt registreringsnummer: Det sjätte tecknet måste vara en siffra eller en bokstav.");
                    }
                }
                registrationNumber = value.ToUpper();
            }
        }

        // Fordonstyp tas in från dropdown-menyn, och behöver därför inte valideras
        public Type VehicleType
        {
            get { return vehicleType; }
            set { this.vehicleType = value; }
        }

        //TODO Tillverkare ska valideras, sparas i objektet och visas i UI
        public string Model
        {
            get { return model; }

            set {
                if (String.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Model måste anges.");

                this.model = value.Trim();
            }
        }

        //TODO Modell ska valideras, sparas i objektet och visas i UI
        public string Manufacturer
        {
            get { return manufacturer; }

            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Tillverkare Måste anges.");

                this.manufacturer = value.Trim();
            }
        }

        //TODO Lägg till möjligheten att spara realistisk årsmodell, validera, spara och visa i objektet och visas i UI. Tips: Regex.IsMatch()


        //TODO Modifiera overriden på ToString() så att allt visas som önskat i UIs listBox
        public override string ToString()
        {
            return this.registrationNumber + "\t" + this.vehicleType + "\t" + this.manufacturer + "\t" + this.model;
        }
    }
}
