using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using WpfMockupApp8.Models;
using WpfMockupApp8.Utilities;

namespace WpfMockupApp8.ViewModels
{
    public class PersonViewModel : BaseViewModel, INotifyPropertyChanged
    {
        private ObservableCollection<Person> _persons;
        public ObservableCollection<Person> Persons
        {
            get { return _persons; }
            set
            {
                if (_persons != value)
                {
                    _persons = value;
                    OnPropertyChanged(nameof(Persons));
                }
            }
        }

        private Person _selectedPerson;
        public Person SelectedPerson
        {
            get { return _selectedPerson; }
            set
            {
                if (_selectedPerson != value)
                {
                    _selectedPerson = value;
                    OnPropertyChanged(nameof(SelectedPerson));
                }
            }
        }
        
        public PersonViewModel() 
        {
            ReadPersons();
        }

        private void ReadPersons()
        {
            // Obviously this is set to the demo data. Real systems would house the data in a database.
            const string filePath = "C:\\WpfMockupApp8\\WpfMockupApp8\\Data\\MOCK_DATA.csv"; 

            _ = new PersonCsvReader();
            Persons = PersonCsvReader.ReadCsvFile(filePath).ToObservableCollection();
            SelectedPerson = Persons.First();
        }

        private class PersonCsvReader
        {
            public static List<Person> ReadCsvFile(string filePath)
            {
                var records = new List<Person>();

                using var reader = new StreamReader(filePath);
                reader.ReadLine(); // ignore first line

                string? line;
                List<string> columns = [];
                string[] fieldArray;

                while (!reader.EndOfStream)
                {
                    line = reader.ReadLine();
                    if (line == null)
                    {
                        return records;
                    }
                    fieldArray = line.Split(',');
                    records.Add(new Person
                         (id: fieldArray[0], active: fieldArray[1], firstName: fieldArray[2],
                          lastName: fieldArray[3], email: fieldArray[4], phoneNumber: fieldArray[5],
                          address: fieldArray[6], city: fieldArray[7], state: fieldArray[8] ?? "", zipCode: fieldArray[9] ?? ""));
                }

                return records;
            }
        }
    }
}
