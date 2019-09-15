using System;

namespace dotNet_ass1
{
    class Program
    {
        //Container for the entire program
        static void Main(string[] args)
        {
            //Prompt user with the login screen, if it fails, refresh and let user re enter the detail
            Login login = new Login();
            while (!login.LoginSuccess)
            {
                login.LoginScreen();
            }
            //Proppt user with the menu screen
            //do while loop is used here so that user could keep comeback to the main menu
            Menu menu = new Menu();
            do
            {
                int choice = menu.MenuScreen();
                //based on user input, display different screens or exit the program;
                switch (choice)
                {
                    case 1:
                        CreateAccount newAcc = new CreateAccount();
                        newAcc.NewAccScreen();
                        break;
                    case 2:
                        SearchAccount searchAcc = new SearchAccount();
                        searchAcc.SearchAccountScreen();
                        break;
                    case 3:
                        Deposit deposit = new Deposit();
                        deposit.DepositScreen();
                        break;
                    case 4:
                        Withdraw withdraw = new Withdraw();
                        withdraw.WithdrawScreen();
                        break;
                    case 5:
                        Statement statement = new Statement();
                        statement.StatementScreen();
                        break;
                    case 6:
                        DeleteAcc deleteAcc = new DeleteAcc();
                        deleteAcc.DeleteScreen();
                        break;
                    case 7:
                        //Exit the system
                        System.Environment.Exit(0);
                        break;
                    default:
                        break;
                }
            } while (true);
        }
    }
}
