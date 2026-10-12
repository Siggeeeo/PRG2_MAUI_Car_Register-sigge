using PRG_MAUI_Car_Register.Model;

namespace PRG_MAUI_Car_Register.View
{
    public partial class MainPage : ContentPage
    {
        List<Vehicle> vehicleList = new List<Vehicle>();

        public MainPage()
        {
            InitializeComponent();
            pickerType.SelectedIndex = 0;
        }

        private void OnRegisterClicked(object sender, EventArgs e)
        {
            try
            {
                Vehicle vehicle;
                switch (pickerType.SelectedIndex)
                {
                    case 0:
                        vehicle = new Car();
                        break;
                    case 1:
                        vehicle = new Mc();
                        break;
                    case 2:
                        vehicle = new Truck();
                        break;
                    default:
                        throw new ArgumentException("Välj en fordonstyp.");
                }

                vehicle.RegistrationNumber = entryRegistrationNumber.Text; ;
                vehicle.Manufacturer = entryManufacturer.Text;
                vehicle.Model = entryModel.Text;
                vehicle.Year = Vehicle.ParseYear(entryYear.Text);

                vehicleList.Add(vehicle);
                listViewVehicles.ItemsSource = null;
                listViewVehicles.ItemsSource = vehicleList;

                ClearTextFields();
            }

            // här "fångas" eventuella felmeddelanden från Vehicle
            catch (ArgumentException ex)
            {
                DisplayAlert("Fel", ex.Message, "OK");
            }
        }

        private void OnRadioCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            IEnumerable<Vehicle> FilteredList;

            if (radioCar.IsChecked)
            {
                FilteredList = vehicleList.OfType<Car>();
            }
            else if (radioMC.IsChecked)
            {
                FilteredList = vehicleList.OfType<Mc>();
            }
            else if (radioTruck.IsChecked)
            {
                FilteredList = vehicleList.OfType<Truck>();
            }
            else
            {
                FilteredList= vehicleList;
            }
            listViewVehicles.ItemsSource= FilteredList;

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
                Mc => "Mc",
                Truck => "Lastbil",
                _ => "Okänt"
                };

                labelSearchResult.Text = $"Fordon hittat:\n" +
                                         $"Registreringsnummer: {foundVehicle.RegistrationNumber}\n" +
                                         $"Tillverkare: {foundVehicle.Manufacturer}\n" +
                                         $"Modell: {foundVehicle.Model}\n" +
                                        $"Typ: {type}";
            }
            else
            {
                labelSearchResult.Text = "Inget fordon hittades med det registreringsnumret.";
            }
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
