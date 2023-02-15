namespace PhoneBookConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var phonebook = new PhoneBook();
            begin:
            Console.WriteLine(
                "\n\n\t...................PhoneBook ConsoleApplication...................\n\n"
                    + "\t\t\tWHAT WOULD YOU LIKE TO DO?\n\n"
                    + "\t\t 1. Add contact\n"
                    + "\t\t 2. Display contact by number\n"
                    + "\t\t 3. View all contacts\n"
                    + "\t\t 4. Search for contacts for a given name\n"
                    + "\t\t 5. Press 5 to Exit\n"
            );
            Console.Write("Pick One Option:");
            string userInput = Console.ReadLine();
            if (userInput == "1")
                goto AddContacts;
            if (userInput == "2")
                goto FetchContactByNumber;
            if (userInput == "3")
                goto DispalyAllContacts;
            if (userInput == "4")
                goto DisplayMatchingContact;
            if (userInput == "5")
                System.Environment.Exit(1);
            Console.WriteLine("Invalid option!");
            goto begin;

            AddContacts:
            {
                var name = "";
                do
                {
                    Console.WriteLine("Enter Contact Name");
                    name = Console.ReadLine();
                } while (name.Any(y => !char.IsLetter(y)));

                Console.WriteLine("Enter Contact Number");
                var number = Console.ReadLine();

                var newContact = new Contacts(name, number);
                phonebook.AddContact(newContact);
                goto begin;
            }

            FetchContactByNumber:
            {
                string searchNumber;

                Console.Write("Enter the Number to search:");
                searchNumber = Console.ReadLine();

                phonebook.DisplayContact(searchNumber);
                goto begin;
            }

            DispalyAllContacts:
            {
                phonebook.DisplayAllContact();
                goto begin;
            }

            DisplayMatchingContact:
            {
                string searchPhrase = "";
                do
                {
                    Console.WriteLine("Search  Contact Name");
                    searchPhrase = Console.ReadLine();
                } while (searchPhrase.Any(y => !char.IsLetter(y)));
                phonebook.DisplayMatchingContacts(searchPhrase);

                goto begin;
            }
        }
    }
}
