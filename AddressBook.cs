namespace AddressBookUsingLambda
{
    public class AddressBook
    {
        private class ContactDetails
        {
            public string FullName, City, State, Zip, PhoneNumber, Email;
            public ContactDetails(string fullName, string city, string state, string zip, string phoneNumber, string email)
            {
                FullName = fullName;
                City = city;
                State = state;
                Zip = zip;
                PhoneNumber = phoneNumber;
                Email = email;
            }
        }

        private List<ContactDetails> Contacts = new List<ContactDetails>();

        private void ShowContacts()
        {
            Console.WriteLine("\nContacts in AddressBook : ");

            if (Contacts.Count == 0)
            {
                Console.WriteLine("Address Book is EMPTY !!");
                return;
            }

            foreach (var contact in Contacts)
                Console.WriteLine(" [+] {0}", contact.FullName);
        }

        private bool Exists(string name)
        {
            var result = (Contacts.Exists(c => c.FullName == name)) ? true : false;
            return result;
        }

        public void AddContact()
        {
            ShowContacts();

            Console.Write("\nEnter Full Name of the Contact to be Added : "); var name = Console.ReadLine();

            if (Exists(name)) return;

            Console.Write(" City : "); var city = Console.ReadLine();
            Console.Write(" State : "); var state = Console.ReadLine();
            Console.Write(" Zip : "); var zip = Console.ReadLine();
            Console.Write(" Contact Number : "); var number = Console.ReadLine();
            Console.Write(" E-Mail : "); var email = Console.ReadLine();

            var newContact = new ContactDetails(name, city, state, zip, number, email);
            Contacts.Add(newContact);

            Console.WriteLine("\nContact Added!!");
        }

        public void ContactDetail()
        {
            ShowContacts();
            Console.Write("\nEnter Full Name of the Contact : "); var name = Console.ReadLine();
            if (!Exists(name)) return;

            var cc = Contacts.Find(e => e.FullName == name);
            Console.WriteLine(" [-] City : {0} \n [-] State : {1} \n [-] Zip : {2} \n [-] Phone Number : {3} \n [-] E-Mail : {4} \n",cc.City,cc.State,cc.Zip,cc.PhoneNumber,cc.Email);
        }

        public void EditContact()
        {
            ShowContacts();

            Console.Write("\nEnter Full Name of the Contact to be edited : "); var name = Console.ReadLine();

            if (!Exists(name)) return;

            var index = Contacts.FindIndex(c => c.FullName == name);

            Console.Write("\n Name (old): {0} (new) : (Leave blank to keep it same) ", Contacts[index].FullName); var newName = Console.ReadLine(); Contacts[index].FullName = (newName != "") ? newName : Contacts[index].FullName;
            Console.Write(" City (old): {0} (new) : (Leave blank to keep it same) ", Contacts[index].City); var city = Console.ReadLine(); Contacts[index].City = (city != "") ? city : Contacts[index].City;
            Console.Write(" State (old): {0} (new) : (Leave blank to keep it same) ", Contacts[index].State); var state = Console.ReadLine(); Contacts[index].State = (state != "") ? state : Contacts[index].State;
            Console.Write(" Zip (old): {0} (new) : (Leave blank to keep it same) ", Contacts[index].Zip); var zip = Console.ReadLine(); Contacts[index].Zip = (zip != "") ? zip : Contacts[index].Zip;
            Console.Write(" Phone (old): {0} (new) : (Leave blank to keep it same) ", Contacts[index].PhoneNumber); var phone = Console.ReadLine(); Contacts[index].PhoneNumber = (phone != "") ? phone : Contacts[index].PhoneNumber;
            Console.Write(" E-mail (old): {0} (new) : (Leave blank to keep it same) ", Contacts[index].Email); var email = Console.ReadLine(); Contacts[index].Email = (email != "") ? email : Contacts[index].Email;
        }

        public void DeleteContact()
        {
            ShowContacts();

            Console.Write("\nEnter Full Name of the Contact to be Deleted : "); var name = Console.ReadLine();

            if (!Exists(name)) return;

            var index = Contacts.FindIndex(c => c.FullName == name);

            Contacts.RemoveAt(index);
            Console.WriteLine("\nContact Removed!!");
        }

        public void SearchContactsByStateCity()
        {
            Console.Write("\nEnter City or State to search contacts : "); var cityOrstate = Console.ReadLine();

            if (!Contacts.Exists(c => c.City == cityOrstate || c.State == cityOrstate))
            {
                Console.WriteLine("\nNo city or state found with this name. Try Again");
                return;
            }

            Console.WriteLine("\n----- {0} -----", cityOrstate);
            foreach (var contact in Contacts.FindAll(c => c.City == cityOrstate || c.State == cityOrstate))
                Console.WriteLine(" [+] {0} ", contact.FullName);
        }

        public void GetCountOfContacts()
        {
            foreach (var state in Contacts.GroupBy(c => c.State))
            {
                Console.WriteLine("\n------- {0} --------", state.Key);
                foreach (var city in state.GroupBy(c => c.City))
                    Console.WriteLine("{0} : {1}", city.Key, city.Count());
            }
        }
    }
}