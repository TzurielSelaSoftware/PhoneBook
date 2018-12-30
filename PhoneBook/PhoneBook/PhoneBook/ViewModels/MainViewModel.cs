using Microsoft.Win32;
using PhoneBook.Commands;
using PhoneBook.Models;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
namespace PhoneBook.ViewModels
{
    class MainViewModel : BaseViewModel
    {
        private ObservableCollection<Person> personData;
        public ObservableCollection<Person> PersonData
        {
            get
            {
                return personData;
            }
            set
            {
                personData = value;
                OnPropertyChanged(nameof(PersonData));
            }
        }
        private int selectedTableRow;
        public int SelectedTableRow
        {
            get {
                return selectedTableRow;
            }
            set {
                selectedTableRow = value;
                OnPropertyChanged(nameof(SelectedTableRow));
            }
        }
        private Person personObj;
        public Person PersonObj
        {
            get
            {
                return personObj;
            }
            set
            {
                personObj = value;
                OnPropertyChanged(nameof(PersonObj));
            }
        }
        public ICommand AddCommand => new DelegateCommand(AddPerson);
        public ICommand LoadCommand => new DelegateCommand(LoadData);
        public ICommand SaveCommand => new DelegateCommand(SaveData);
        public ICommand DelCommand => new DelegateCommand(DeletePerson);
        public ICommand UpdCommand => new DelegateCommand(UpdatePerson);
        private bool textBoxEmpty;
        public bool TextBoxEmpty
        {
            get { return textBoxEmpty; }
            set
            {
                textBoxEmpty = value;
                OnPropertyChanged(nameof(TextBoxEmpty));
            }
        }
        public MainViewModel()
        {
            var path = @"c:\PhoneBookData\PhoneBook.xml";
            if (File.Exists(path))
            {
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Person>));
                using (StreamReader rd = new StreamReader(path))
                {
                    PersonData = xs.Deserialize(rd) as ObservableCollection<Person>;
                    if(PersonData.Count>0)
                        TextBoxEmpty = true;
                }
            }
            else
            {
                PersonData = new ObservableCollection<Person>();
                TextBoxEmpty = false;
            }         
            PersonObj = new Person();
        }
        private void AddPerson()
        {
            try
            {
                var temp = PersonData.Where(x => x.email == PersonObj.email);
                var temp2 = PersonData.Where(x => x.phone == PersonObj.phone);
                if (temp.Count() > 0 || temp2.Count() > 0)
                {
                    MessageBox.Show($"Person with Email: {PersonObj.email} and Phone: {PersonObj.phone} allready exsits", "Duplicate Data Error", MessageBoxButton.OK, MessageBoxImage.Warning, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
                }
                else
                {
                    PersonData.Add(PersonObj);
                }
                PersonObj = new Person();
                if (personData.Count > 0)
                    TextBoxEmpty = true;
                else
                    TextBoxEmpty = false;
            }
            catch (Exception)
            {
                var res = MessageBox.Show("Error: Adding Person failed\nDo you want to try again?", "Error Adding Person", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
                if (res == MessageBoxResult.Yes)
                {
                    AddPerson();
                }
            }
        }
        private void DeletePerson()
        {
            try
            {
                if (SelectedTableRow < PersonData.Count() && selectedTableRow != -1)
                {
                    PersonData.RemoveAt(SelectedTableRow);
                    if (personData.Count > 0)
                        TextBoxEmpty = true;
                    else
                        TextBoxEmpty = false;
                }
            }
            catch (Exception)
            {
                var res = MessageBox.Show("Error: Deleteing Person failed\nDo you want to try again?", "Error Deleteing Person", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
                if (res == MessageBoxResult.Yes)
                {
                    DeletePerson();
                }
            }
        }
        private void UpdatePerson()
        {
            try
            {
                if (selectedTableRow != -1 && selectedTableRow < PersonData.Count())
                {
                    PersonData[selectedTableRow] = PersonObj;
                    PersonObj = new Person();
                }
            }
            catch (Exception)
            {

                var res = MessageBox.Show("Error: Saving data failed\nDo you want to try again?", "Error Saving Data", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
                if (res == MessageBoxResult.Yes)
                {
                    UpdatePerson();
                }
            }
        }
        private void SaveData()
        {
            var dirpath = @"c:\PhoneBookData";
            var path = dirpath + @"\PhoneBook.xml";
            Directory.CreateDirectory(dirpath);
            XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Person>));
            using (StreamWriter wr = new StreamWriter(path))
            {
                xs.Serialize(wr, PersonData);
            }
            MessageBox.Show("Phone Book data saved successfully", "Save Data", MessageBoxButton.OK, MessageBoxImage.Information, MessageBoxResult.OK, MessageBoxOptions.DefaultDesktopOnly);
        }
        private void LoadData()
        {

            try
            {
                OpenFileDialog fd = new OpenFileDialog();
                fd.Filter = "XML files (*.xml)|*.xml";
                fd.ShowDialog();
                XmlSerializer xs = new XmlSerializer(typeof(ObservableCollection<Person>));
                using (StreamReader rd = new StreamReader(fd.FileName))
                {
                    PersonData = xs.Deserialize(rd) as ObservableCollection<Person>;
                    if (PersonData.Count > 0)
                        TextBoxEmpty = true;
                }
            }
            catch (Exception)
            {
                var res = MessageBox.Show("Error: Loading data failed\nDo you want to try again?", "Error Loading Data", MessageBoxButton.YesNo, MessageBoxImage.Error, MessageBoxResult.Yes, MessageBoxOptions.DefaultDesktopOnly);
                if(res == MessageBoxResult.Yes)
                {
                    LoadData();
                }
            }
        }
    }
}
