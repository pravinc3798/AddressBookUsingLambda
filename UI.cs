namespace AddressBookUsingLambda
{
    public class UI
    {
        public static void Action(AddressBook contactBook)
        {
            Console.Write("\n 1. Add New Contact \n 2. Show Details Of A Contact \n 3. Edit A Contact \n 4. Delete A Contact \n 5. View All Contacts For A State or City \n 6. Get Count of Contacts Grouped by State and then by Cities \n 7. Exit \n\n Enter the number corresponding to desired action : "); var input = Console.ReadLine();
            switch (input)
            {
                case "1":
                    contactBook.AddContact();
                    Action(contactBook);
                    break;

                case "2":
                    contactBook.ContactDetail();
                    Action(contactBook);
                    break;

                case "3":
                    contactBook.EditContact();
                    Action(contactBook);
                    break;

                case "4":
                    contactBook.DeleteContact();
                    Action(contactBook);
                    break;

                case "5":
                    contactBook.SearchContactsByStateCity();
                    Action(contactBook);
                    break;

                case "6":
                    contactBook.GetCountOfContacts();
                    Action(contactBook);
                    break;

                case "7":
                    break;

                default:
                    Console.WriteLine("\nInvalid Input! Try Again..");
                    Action(contactBook);
                    break;
            }
        }
    }
}