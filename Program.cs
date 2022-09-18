using Newtonsoft.Json;

namespace AddressBookUsingLambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // using list in Addressbook as I have already used dictionary in previous assignment, so using list for some variety.

            Console.WriteLine("\nWelcome to Address Book Program");

            var contactBook = new AddressBook();
            UI.Action(contactBook);
        }
    }
}