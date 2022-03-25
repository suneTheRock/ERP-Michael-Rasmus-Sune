using ERPOpgave.GUI;
using TECHCOOL.UI;

CompanyMenu titlescreen = new CompanyMenu();
Screen.Display(titlescreen);

ConsoleKeyInfo info = Console.ReadKey();

Screen.Clear(titlescreen);

if (info.Key == ConsoleKey.Escape)
{
    CompanyMenu companyMenu = new CompanyMenu();
    companyMenu.CreateNewCompanyToList();
    
}

    



