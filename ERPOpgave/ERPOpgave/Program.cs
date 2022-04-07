using ERPOpgave.GUI;
using TECHCOOL.UI;
using ERPOpgave.Data;
using ERPOpgave.Models;


    //TitleScreen titlescreen = new TitleScreen();
    //Screen.Display(titlescreen);
    //CustomerScreen titlescreen = new CustomerScreen();
    //Screen.Display(titlescreen);
    Database.Init();
    List<Customer> customers = Database.GetAllCustomers();
    Console.WriteLine(customers);









