using CsvHelper;
using System.Globalization;
using CsvHelper.Configuration;

namespace AddressBookUsingLambda
{
    public class AddressBookCsvFile
    {
        public class BookMap : ClassMap<AddressBook.ContactDetails> // To resolve mapping errors
        {
            public BookMap()
            {
                Map(m => m.FullName).Name("fullName");
                Map(m => m.City).Name("city");
                Map(m => m.State).Name("state");
                Map(m => m.Zip).Name("zip");
                Map(m => m.PhoneNumber).Name("phoneNumber");
                Map(m => m.Email).Name("email");
            }
        }

        public static string path = @"C:\Users\Public\Documents\AddressBook.csv";

        public static void Write<T>(List<T> contacts)
        {
            using (StreamWriter sw = new StreamWriter(path))
            {
                using (CsvWriter csvWriter = new CsvWriter(sw,CultureInfo.InvariantCulture))
                {
                    csvWriter.Context.RegisterClassMap<BookMap>();
                    csvWriter.WriteRecords(contacts);
                }
            }
        }

        public static List<T> Read<T>()
        {
            List<T> contacts = new List<T>();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (StreamReader sr = new StreamReader(path))
            {
                CsvReader csvReader = new CsvReader(sr, CultureInfo.InvariantCulture);
                contacts = csvReader.GetRecords<T>().ToList();
            }

            return contacts;
        }
    }
}