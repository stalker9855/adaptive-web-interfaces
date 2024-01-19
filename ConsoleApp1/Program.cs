public class Program
{
    /*
     * Method reads file from current folder.
     * User must enter integer number and then method gets the text up 
     * to the charcater indexed  by entered number SPACE
     * then make the substring and output the cut text
     */
    public void LoremIpsum()
    {

        string text = File.ReadAllText("./lorem_ipsum.txt");
        Console.Write("Enter count words: ");
        string countWords = Console.ReadLine();

        if(!int.TryParse(countWords, out int count))
        {
            Console.WriteLine("Invalid number");
            return;
        }
        if (count <= 0)
        {
            Console.WriteLine("Invalid number");
            return;
        }
        int indexSpace = -1;
        for(int i = 0; i < count; i++)
        {
            indexSpace = text.IndexOf(' ', indexSpace + 1);
            if(indexSpace == -1)
            {
                return;
            }
        }
        string selectedText = text.Substring(0, indexSpace);
        Console.WriteLine(selectedText);
    }
    public void Calculator()
    {
        bool requestExit = false;
        double result = 0;
        while (!requestExit)
        {
            /*
             * The userInput field represents a string received 
             * from the console using Console.ReadLine().
             * The string entered by the user is stored 
             * in this field and can contain a numeric
             * value or the "exit" command.
             */
            Console.WriteLine("Enter number (or type 'exit' to exit): ");
            string input = Console.ReadLine();


            if (input.ToLower() == "exit")
            {
                requestExit = true;
                continue;
            }
            if (!double.TryParse(input, out double number))
            {
                Console.WriteLine("invalid number.\nEnter again: ");
                continue;
            }
            Console.WriteLine("Enter operation (+, -, *, /): ");
            string operation = Console.ReadLine();
            switch (operation)
            {
                case "+":
                    result += number;
                    Console.WriteLine(result);
                    break;
                case "-":
                    result -= number;
                    Console.WriteLine(result);
                    break;
                case "*":
                    result *= number;
                    Console.WriteLine(result);
                    break;
                case "/":
                    try
                    {
                        if (number == 0)
                        {
                            throw new DivideByZeroException();
                        }
                        result /= number;
                        Console.WriteLine(result);
                        break;
                    }
                    catch (DivideByZeroException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }
                    break;
                default:
                    break;
            }
        }
       

    }
    public static void Main()
    {
        Program pr = new Program();
        while (true)
        {
            Console.WriteLine("\nSelect action (0 - Exit, 1 - Lorem Ipsum 2 - Calculator): ");
            char select = Console.ReadLine()[0];
            switch (select)
            {
                case '0':
                    Console.WriteLine("Leaving");
                    Environment.Exit(0);
                    break;
                case '1':
                    pr.LoremIpsum();
                    break;
                case '2':
                    pr.Calculator();
                    break;
                default:
                    break;
            }
        }
    }
}