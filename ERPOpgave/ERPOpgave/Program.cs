using ERPOpgave.GUI;
using TECHCOOL.UI;
//While true to properly create an inescapeable loop
while (true)
{
    //TitleScreen titlescreen = new TitleScreen();
    //CustomerScreen titlescreen = new CustomerScreen();
    //CompanyMenu titlescreen = new CompanyMenu();
    SalesOrderMenu titlescreen = new SalesOrderMenu();
    Screen.Display(titlescreen);   
}