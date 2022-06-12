using Parkings.Ui;
using Parkings.Garaget;
using Parkings.Handlers;
using Parkings.Handlers.IHandlers;

namespace Parkings
{
    internal class Manager
    {
             
        public void run()
        {
            IUi consoleManager=new InOutconsole();
            uint input=consoleManager.NumberInput();
            IHandler appHandler = new Handler(input);
            Init(appHandler , consoleManager);
        }
        public void Init(IHandler appHandler, IUi consoleManager)
        {
            appHandler.Add(new Car("ABC123","RED", "BENSIN", 4 ,4));//(register,color,fuel,seat,wheel)
            appHandler.Add(new Car("ADD134","BLACK", "BENSIN", 6 ,4)); 
            appHandler.Add(new Motorcycle("ADC133","GREEN", "GAS", 2 , 2));
            appHandler.Add(new Boat("ADC155","YELLOW", "DIESEL", 8));//(register,color,fuel,seat)
            consoleManager.ClearConsole();
            Start(appHandler , consoleManager);      
        } 


        public void Start(IHandler handler , IUi consoleManager)
        {
            char input=' ';
            do{
                try
                {
                    consoleManager.GetMenue(handler);
                    string? myinput = consoleManager.GetInput();
                    input =myinput[0];
                }
                catch (Exception)
                {
                    consoleManager.ClearConsole();
                    consoleManager.GetMenue(handler);
                }
                switch (input)
                {
                    case '1':
                        consoleManager.printAllobject(handler);
                        break;
                    case '2':
                        consoleManager.print_out("Skriv med mellanrum\n"+
                        "Car dfg123 red bensin 4 6 (fordon reg färg sittplats hjul)\n"+
                        "Det finns tre typer av fordon (Car Motorcyckel Boat)");

                        String ? str = consoleManager.GetInput();
                        consoleManager.ChechRegister(handler , str);
                        break;
                    case '3':
                        consoleManager.print_out("Under utveckling!");
                        break;
                    case '4':
                        consoleManager.print_out("Skriv registreingsnummer!");
                        string? register=consoleManager.GetInput();
                        consoleManager.printWithRegisternumber(handler,register);
                        break;
                    case '5':
                        consoleManager.print_out("Skriv en av de typer. Börja med stor bokstav");
                        str = consoleManager.GetInput();
                        consoleManager.PrintOneType(handler,str);
                        break;
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        consoleManager.GetMenue(handler);
                        break;
                }

            }while(input!='0');

        }
    }
}