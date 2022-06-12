using Parkings.Handlers.IHandlers;

namespace Parkings.Ui
{
    internal interface IUi
    {
        public void print_out(string text);
        public string? GetInput();
        public uint NumberInput();
        public void GetMenue(IHandler i);
        public void printAllobject(IHandler i);
        public void printWithRegisternumber(IHandler i , string register);
        public void ClearConsole();
        public void ChechRegister(IHandler i, string str);
        public void PrintOneType(IHandler i, string str);
    }
}