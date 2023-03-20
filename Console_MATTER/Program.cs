
using Console_MATTER.Services;

var menu = new MenuService();

while (true)
{
    Console.Clear();
    Console.WriteLine("1. Skapa en nytt ärende");
    Console.WriteLine("2. Visa alla ärenden");
    Console.WriteLine("3. Visa ett specifik ärende");
    Console.WriteLine("4. Visa stängda ärenden");
    Console.WriteLine("5. Uppdatera ett specifikt Ärende");
    Console.WriteLine("6. Uppdatera en Status");
    Console.WriteLine("7. Ta bort ett specifikt ärende");
    Console.Write("Välj ett av följande alternativ (1-7): ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Clear();
            await menu.CreateNewMatterAsync();
            break;

        case "2":
            Console.Clear();
            await menu.ListAllMattersAsync();
            break;

        case "3":
            Console.Clear();
            await menu.ListSpecificMatterAsync();
            break;

        case "4":
            Console.Clear();
            await menu.ListClosedMatterAsync();
            break;

        case "5":
            Console.Clear();
            await menu.UpdateSpecificMatterAsync();
            break;

        case "6":
            Console.Clear();
            await menu.UpdateStatusAsync();
            break;

        case "7":
            Console.Clear();
            await menu.DeleteSpecificMatterAsync();
            break;
    }

    Console.WriteLine("\nTryck på valfri knapp för att fortsätta...");
    Console.ReadKey();
}