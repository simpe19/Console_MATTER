using Console_MATTER.Models;
using Console_MATTER.Models.Entities;

namespace Console_MATTER.Services
{
    internal class MenuService
    {
        public async Task CreateNewMatterAsync()
        {
            var matter = new Matter();

            Console.Write("Förnamn: ");
            matter.FirstName = Console.ReadLine() ?? "";

            Console.Write("Efternamn: ");
            matter.LastName = Console.ReadLine() ?? "";

            Console.Write("E-postadress: ");
            matter.Email = Console.ReadLine() ?? "";

            Console.Write("Telefonnummer: ");
            matter.PhoneNumber = Console.ReadLine() ?? "";

            Console.Write("Avdelning: ");
            matter.Department = Console.ReadLine() ?? "";

            Console.Write("Typ av ärende: ");
            matter.MatterType = Console.ReadLine() ?? "";

            Console.Write("Kommentar: ");
            matter.Comment = Console.ReadLine() ?? "";


            
            await MatterService.SaveAsync(matter);

        }

        public async Task ListAllMattersAsync()
        {
            
            var matters = await MatterService.GetAllAsync();

            if (matters.Any())
            {

                foreach (Matter matter in matters)
                {
                    Console.WriteLine($"ID: {matter.Id}");
                    Console.WriteLine($"Namn: {matter.FirstName} {matter.LastName}");
                    Console.WriteLine($"E-postadress: {matter.Email}");
                    Console.WriteLine($"Telefonnummer: {matter.PhoneNumber}");
                    Console.WriteLine($"Avdelning: {matter.Department}");
                    Console.WriteLine($"Typ av ärende: {matter.MatterType}");
                    Console.WriteLine($"Kommentar: {matter.Comment}");
                    Console.WriteLine($"Skapat: {matter.CreatedAt}");
                    Console.WriteLine($"Status: {matter.Status}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga ärenden finns i databasen.");
                Console.WriteLine("");
            }

        }

        public async Task ListSpecificMatterAsync()
        {
            Console.Write("Ange e-postadress för Ärendet: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                
                var matter = await MatterService.GetAsync(email);

                if (matter != null)
                {
                    Console.WriteLine($"ID: {matter.Id}");
                    Console.WriteLine($"Namn: {matter.FirstName} {matter.LastName}");
                    Console.WriteLine($"E-postadress: {matter.Email}");
                    Console.WriteLine($"Telefonnummer: {matter.PhoneNumber}");
                    Console.WriteLine($"Avdelning: {matter.Department}");
                    Console.WriteLine($"Typ av ärende: {matter.MatterType}");
                    Console.WriteLine($"Kommentar: {matter.Comment}");
                    Console.WriteLine($"Status: {matter.Status}");
                    Console.WriteLine("");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"Inget ärende med den angivna e-postadressen {email} hittades.");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }

        public async Task ListClosedMatterAsync()
        {
            var matters = await MatterService.GetClosedAsync();

            if (matters.Any())
            {

                foreach (Matter matter in matters)
                {
                    Console.WriteLine($"ID: {matter.Id}");
                    Console.WriteLine($"Avdelning: {matter.Department}");
                    Console.WriteLine($"Typ av ärende: {matter.MatterType}");
                    Console.WriteLine($"Kommentar: {matter.Comment}");
                    Console.WriteLine($"Status: {matter.Status}");
                    Console.WriteLine("");
                }
            }
            else
            {
                Console.WriteLine("Inga ärenden finns i databasen.");
                Console.WriteLine("");
            }

        }

        public async Task UpdateSpecificMatterAsync()
        {
            Console.Write("Ange e-postadress på ärendet: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {

                var matter = await MatterService.GetAsync(email);
                if (matter != null)
                {
                    Console.WriteLine("Skriv in information på de fält som du vill uppdatera. \n");

                    Console.Write("Förnamn: ");
                    matter.FirstName = Console.ReadLine() ?? null!;

                    Console.Write("Efternamn: ");
                    matter.LastName = Console.ReadLine() ?? null!;

                    Console.Write("E-postadress: ");
                    matter.Email = Console.ReadLine() ?? null!;

                    Console.Write("Telefonnummer: ");
                    matter.PhoneNumber = Console.ReadLine() ?? null!;

                    Console.Write("Avdelning: ");
                    matter.Department  = Console.ReadLine() ?? null!;

                    Console.Write("Typ av ärende: ");
                    matter.MatterType   = Console.ReadLine() ?? null!;

                    Console.Write("Kommentar: ");
                    matter.Comment = Console.ReadLine() ?? null!;

                    
                    await MatterService.UpdateAsync(matter);
                }
                else
                {
                    Console.WriteLine($"Hittade inte något ärende på den angivna e-postadressen.");
                    Console.WriteLine("");
                }

            }
            else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }


        public async Task DeleteSpecificMatterAsync()
        {
            Console.Write("Ange e-postadress för ärendet: ");
            var email = Console.ReadLine();

            if (!string.IsNullOrEmpty(email))
            {
                await MatterService.DeleteAsync(email);
            }
            else
            {
                Console.WriteLine($"Ingen e-postadressen angiven.");
                Console.WriteLine("");
            }

        }
    }
}
