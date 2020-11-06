using Caliburn.Micro;
using MySql.Data.MySqlClient;
using SecondCaliburnApp.Helpers;
using SecondCaliburnApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondCaliburnApp.ViewModels
{
    class ShellViewModel : Conductor<object>, IHaveDisplayName
    {
        public override string DisplayName { get; set; }

        string firstName;

        public string FirstName{ 
            get => firstName;
            set
            {
                firstName = value;
                NotifyOfPropertyChange(() => FirstName);
                NotifyOfPropertyChange(() => FullName);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }

        string lastName;

        public string LastName
        {
            get => lastName;
            set
            {
                lastName = value;
                NotifyOfPropertyChange(() => LastName);
                NotifyOfPropertyChange(() => FullName);
                //NotifyOfPropertyChange(() => CanClearName); 굳이 여기까지 쓸 필요는 없음
            }
        }

        public string FullName
        {
            get => $"{LastName} {FirstName}"; //string.Format("{0} {1}", {firstName}, {lastName});
        }
        

        public ShellViewModel()
        {
            DisplayName = "Second Caliburn App";

            People = new BindableCollection<PersonModel>();
            People.Add(new PersonModel { LastName = "", FirstName = "선택" });
            InitCombobox();
            

            //People.Add(new PersonModel { LastName = "Gates", FirstName = "Bill" });
            //People.Add(new PersonModel { LastName = "Jobs", FirstName = "Steve" });
            //People.Add(new PersonModel { LastName = "Musk", FirstName = "Ellen" });
        }

        private void InitCombobox()
        {
            using (MySqlConnection conn = new MySqlConnection(Commons.STRCONSTRING))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(Commons.SELECTPEOPLEQUERY, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var temp = new PersonModel
                    {
                        FirstName = reader["firstName"].ToString(),
                        LastName = reader["lastName"].ToString()
                    };
                    
                    People.Add(temp);
                }
            }
            SelectedPerson = People.Where(v => v.FirstName.Contains("선택")).First();
        }

        // 콤보박스 사람 리스트

        public BindableCollection<PersonModel> People { get; set; }

        PersonModel selectedPerson;

        public PersonModel SelectedPerson
        {
            get => selectedPerson;
            set
            {
                selectedPerson = value;
                this.LastName = selectedPerson.LastName;
                this.FirstName = selectedPerson.FirstName;

                NotifyOfPropertyChange(() => SelectedPerson);
                NotifyOfPropertyChange(() => CanClearName);
            }
        }
        public bool CanClearName
        {
            get => !(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName));


            //if (string.IsNullOrEmpty(firstName) && string.IsNullOrEmpty(lastName))
            //    return false;
            //else
            //    return true; 와 return !(string.IsNullOrEmpty(FirstName) && string.IsNullOrEmpty(LastName)); 과 같음.
        }

        public void ClearName()
        {
            this.FirstName = this.LastName = string.Empty;
        }

        public void LoadPageOne()
        { // UserControl FirstChildView
            ActivateItem(new FirstChildViewModel());
        }

        public void LoadPageTwo()
        { // UserControl SecondChildView
            ActivateItem(new SecondChildViewModel());
        }

    }
}
