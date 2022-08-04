// See https://aka.ms/new-console-template for more information

using Wallet;
using static System.Net.Mime.MediaTypeNames;

List<User> users = new List<User>();
List<UserWallet> userswallet = new List<UserWallet>();

do
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Please Select Operation:");
    Console.ResetColor();
    Console.WriteLine("1.User Difinition");
    Console.WriteLine("2.User List");
    Console.WriteLine("3.Difinition Of Wallet");
    Console.WriteLine("4.Wallet List");
    Console.WriteLine("5.Money Transfer");
    Console.WriteLine("6.Account Balance");
    Console.WriteLine("7.Exit");
    try
    {
        int operation = int.Parse(Console.ReadLine());
        switch (operation)
        {
            case 1:
                {
                    Console.WriteLine("Please Enter Name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Please Enter Familly: ");
                    string familly = Console.ReadLine();
                    Console.WriteLine("Please Enter National Code: ");
                    uint nationalCode = uint.Parse(Console.ReadLine());
                    if (nationalCode <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("The National Code Is Not Valid...");
                        Console.ResetColor();
                    }
                    else
                    {
                        User user = new User()
                        {
                            Id = users.Count + 1,
                            Name = name,
                            Familly = familly,
                            NationalCode = nationalCode
                        };
                        users.Add(user);

                    }

                    break;
                }
            case 2:
                {
                    Console.WriteLine("User List: ");
                    for (int i = 0; i < users.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Id: {users[i].Id}, Name:{users[i].Name}, Familly:{users[i].Familly}, National Code:{users[i].NationalCode}");
                        Console.ResetColor();
                    }
                    break;
                }
            case 3:
                {
                    Console.WriteLine("Please Enter  National Code: ");
                    uint walletnationalCode = uint.Parse(Console.ReadLine());
                    try
                    {
                        bool founded = false;
                        for (int i = 0; i < users.Count; i++)
                        {

                            if (users[i].NationalCode == walletnationalCode)
                            {
                                Console.WriteLine("Please Enter User Account Number: ");
                                long accountNumber = long.Parse(Console.ReadLine());
                                Console.WriteLine("Please Enter User Account Balance: ");
                                long accountBalance = long.Parse(Console.ReadLine());
                                UserWallet userwallet = new UserWallet()
                                {
                                    Id = users[i].Id,
                                    Name = users[i].Name,
                                    Familly = users[i].Familly,
                                    AccountNumber = accountNumber,
                                    AccountBalance = accountBalance,
                                    NationalCode = users[i].NationalCode
                                };
                                userswallet.Add(userwallet);
                                founded = true;
                            }
                            if (founded == false)
                            {
                                Console.WriteLine("!");
                            }
                        }
                    }
                    catch(Exception)
                    {
                        Console.WriteLine("There Is No User With This National Code!!!");
                    }
                    break;
                }
            case 4:
                {
                    for (int i = 0; i < users.Count; i++)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.WriteLine($"Name: {userswallet[i].Name}, Familly:{userswallet[i].Familly}, NationalCode:{userswallet[i].NationalCode}, Account Number: {userswallet[i].AccountNumber}, Inventory: {userswallet[i].AccountBalance }");
                        Console.ResetColor();
                    }
                    break;
                }
            case 5:
                {

                    Console.WriteLine("Please Enter Origin Account Number: ");
                    long originaccountNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Destination Account Number: ");
                    long destinationaccountNumber = long.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Amount: ");
                    long amount = long.Parse(Console.ReadLine());
                    for (int i = 0; i < userswallet.Count; i++)
                    {
                        for (int j = 0; j < userswallet.Count; j++)
                        {
                            if (userswallet[i].AccountNumber == originaccountNumber && userswallet[j].AccountNumber == destinationaccountNumber)
                            {
                                if (userswallet[i].AccountBalance >= amount)
                                {
                                    userswallet[i].AccountBalance -= amount;
                                    userswallet[j].AccountBalance += amount;
                                }
                                else
                                {
                                    Console.WriteLine("Amount More Than Orogon Inventory...");
                                }
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                    break;
                }
            case 6:
                {
                    //Console.WriteLine("Please Enter National Code? ");
                    //int nationalcode = int.Parse(Console.ReadLine());
                    Console.WriteLine("Please Enter Accoun Number? ");
                    long accountnumber = long.Parse(Console.ReadLine());
                    try
                    {
                        bool founded = false;
                        for (int i = 0; i < users.Count; i++)
                        {
                            if (userswallet[i].AccountNumber == accountnumber)
                            {
                                Console.WriteLine($"Inventory: {userswallet[i].AccountBalance}");
                                founded = true;
                            }
                        }
                        if (founded==false)
                        {
                            Console.WriteLine("not found!");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("There Is No User With This National Code!!!");
                    }
                    break;
                }
            case 7:
                {
                    Environment.Exit(0);
                    break;
                }
            default:
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Select Just 1/2/3/4/5/6/7 ...");
                    Console.ResetColor();
                    break;
                }
        }
        Console.ReadKey();
    }
    catch (Exception ex)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("App Stope!");
        Console.ResetColor();
    }
    finally
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("End Of Operation,Please Enter And Reselect Meno...");
        Console.ResetColor();
    }
} while (true);


