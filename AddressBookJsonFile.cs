using Newtonsoft.Json;

namespace AddressBookUsingLambda
{
    public class AddressBookJsonFile
    {
        public static string path = @"C:\Users\Public\Documents\AddressBook.json";

        public static void Write<T>(List<T> contacts)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                string contentJson = JsonConvert.SerializeObject(contacts);
                sw.Write(contentJson);
            }
        }

        public static List<T> Read<T>()
        {
            List<T> contacts = new List<T>();

            using (StreamReader sr = new StreamReader(path))
            {
                string contents = sr.ReadToEnd();
                contacts = JsonConvert.DeserializeObject<List<T>>(contents);
            }

            return contacts;
        }

    }
}