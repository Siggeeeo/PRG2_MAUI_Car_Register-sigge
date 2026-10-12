using System.Collections.ObjectModel;
using PRG_MAUI_Car_Register.Model;


namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        ObservableCollection<Vehicle> vehicleList = new ObservableCollection<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
            listViewVehicles.ItemsSource = vehicleList;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                
                Vehicle vehicle = CreateVehicle(pickerType.SelectedIndex, entryManufacturer.Text);

                vehicle.RegistrationNumber = entryRegistrationNumber.Text;
                vehicle.Model = entryModel.Text;
                vehicle.Year = Vehicle.ParseYear(entryYear.Text);

                vehicleList.Add(vehicle);
                radioAll.IsChecked = true;

                ClearTextFields();
            }

          
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            IEnumerable<Vehicle> filteredList;

            if (radioCar.IsChecked)
            {
                filteredList = vehicleList.OfType<Car>();
            }
            else if (radioMC.IsChecked)
            {
                filteredList = vehicleList.OfType<Mc>();
            }
            else if (radioTruck.IsChecked)
            {
                filteredList = vehicleList.OfType<Truck>();
            }
            else
            {
                filteredList= vehicleList;
            }
            listViewVehicles.ItemsSource= filteredList;

        }

        private void OnSearchClicked(object sender, EventArgs e)
        {
            string searchTerm = entrySearchRegistrationNumber.Text?.ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                entrySearchRegistrationNumber.Text = "Ange ett registreringsnummer för att söka.";
                return;
            }

            var foundVehicle = vehicleList.FirstOrDefault(v => v.RegistrationNumber?.ToLower() == searchTerm);

            if (foundVehicle != null)
            {
                string type = foundVehicle switch
                {
                Car => "Bil",
                Mc => "MC",
                Truck => "Lastbil",
                _ => "Okänt"
                };

               labelSearchResult.Text = $"Fordon hittat:\n" +
                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                         $"Modell: {foundVehicle.Model}\n" +
                         $"Typ: {type}\n" +
                         $"{foundVehicle.GetExtraInfo()}";

            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }

        }
        private Vehicle CreateVehicle(int typeIndex, string manufacturer)
        {
            if (String.IsNullOrWhiteSpace(manufacturer))
                throw new ArgumentException("Tillverkare måste anges.");

            string brand = manufacturer.Trim().ToLower();

            return (typeIndex, brand) switch
            {
                (0, "volvo") => new Volvo(),
                (0, "fiat") => new Fiat(),
                (1, "yamaha") => new Yamaha(),
                (1, "honda") => new Honda(),
                (2, "scania") => new Scania(),
                (2, "iveco") => new Iveco(),
                _ => throw new ArgumentException(
                    "Okänd tillverkare för vald typ. Bil: Volvo, Fiat. MC: Yamaha, Honda. Lastbil: Scania, Iveco.")
            };
        }
        private void ClearTextFields()
        {
            entryRegistrationNumber.Text = string.Empty;
            entryManufacturer.Text = string.Empty;
            entryModel.Text = string.Empty;
            entryYear.Text = string.Empty;
        }
    }
}
