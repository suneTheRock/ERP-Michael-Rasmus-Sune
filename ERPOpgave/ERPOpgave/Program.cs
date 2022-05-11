using ERPOpgave.GUI;
using TECHCOOL.UI;
using ERPOpgave.Data;
using ERPOpgave.Models;


//TitleScreen titlescreen = new TitleScreen();
//Screen.Display(titlescreen);
Database.Init();
Customer customer;
CustomerScreen titlescreen = new CustomerScreen();
List<Customer> customers = Database.GetAllCustomers();
//Database.GetCustomerByID(2);
titlescreen.listPage.Add(Database.GetAllCustomers());

Screen.Display(titlescreen);
    
    


    
    









