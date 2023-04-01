
namespace DZ_CS_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ex1();
            Ex2();
            Ex3();
            Ex4();
        }  
        static void Ex1()
        {
            int digit;
            // с сaмого начала кода начинаем проверять переменную digit на переполнение типа 
            try
            {
                // вводим само число
                Console.Write("Enter the digit:\t");
                digit = Convert.ToInt32(Console.ReadLine());
                // типа меню
                Console.WriteLine("Choose in what notation you want convert this digit:\n" +
                "1. Binary\n2. Hex\n3. Octal");
                int chooser = Convert.ToInt32(Console.ReadLine());
                // смотрим ввод меню
                switch (chooser)
                {
                    case 1:
                        // конвертация в двоичную с/с
                        string? str = Convert.ToString(digit, 2);
                        digit = Convert.ToInt32(str);
                        str = null;
                        Console.WriteLine("Result:\t" + digit);

                        break;
                    case 2:
                        // конвертация в шестнадцатиричную с/с
                        str = Convert.ToString(digit, 16);
                        //здесь не конвертируем в число поскольку эта с/с предполагает использование букв 
                        Console.WriteLine("Result:\t" + str);
                        str = null;
                        break;
                    case 3:
                        // конвертация в восьмеричную с/с
                        str = Convert.ToString(digit, 8);
                        digit = Convert.ToInt32(str);
                        str = null;
                        Console.WriteLine("Result:\t" + digit);
                        break;
                    default:
                        Console.WriteLine("Wrong Input");
                        break;

                }
            }
            // ловим ошибку переполнения типа при каждой попытке конвертации из String в Int переменной digit;
            catch (OverflowException)
            {
                Console.WriteLine("Digit is bigger than Int32 can contain");
                return;
            }
        }

        static void Ex2() 
        {
            string? str = null;
            Console.Write("Enter digit from 0 to 9 by words:\t");
            str = Console.ReadLine();
            if (str == null)
             throw new FormatException("Nothing was inputed!"); 

            str = str.ToLower();
            switch (str) 
            {
                case "zero":
                    Console.WriteLine("0");
                    break;
                case "one":
                    Console.WriteLine("1");
                    break;
                case "two":
                    Console.WriteLine("2");
                    break;
                case "three":
                    Console.WriteLine("3");
                    break;
                case "four":
                    Console.WriteLine("4");
                    break;
                case "five":
                    Console.WriteLine("5");
                    break;
                case "six":
                    Console.WriteLine("6");
                    break;
                case "seven":
                    Console.WriteLine("7");
                    break;
                case "eight":
                    Console.WriteLine("8");
                    break;
                case "nine":
                    Console.WriteLine("9");
                    break;
                default:
                    Console.WriteLine("Wrong input!");
                    break;


            }
        }

        static void Ex3()
        {
            //Passport obj = new Passport("Anatolii", "FZ223221", new DateOnly(2013, 10, 3),
            //                 new DateOnly(2023, 10, 3));
            //Console.WriteLine(obj.ToString());
            Passport passport = new Passport();
            passport.InputData();
            Console.WriteLine(passport.ToString());
        }

        static void Ex4()
        {
            Console.Write("Enter logic expression through a space:\t");
            string? str = Console.ReadLine();
            if (str != null)
            {
                try
                {
                    Console.WriteLine(ConvertExpressionToBool(str));

                }
                catch (FormatException ex) { Console.WriteLine(ex.Message); }
                catch (ArgumentException ex) { Console.WriteLine(ex.Message); }
            }
        }

        static bool ConvertExpressionToBool(string inputString)
        {
            string[] str1 = inputString.Split(' ');

            if (str1.Length != 3)
            {
                throw new FormatException("Wrong format of expression!");
            }

            if (!int.TryParse(str1[0], out int operand1) || !int.TryParse(str1[2], out int operand2))
            {
                throw new FormatException("Wrong inputed operands!");
            }

            switch (str1[1])
            {
                case "<": return operand1 < operand2;
                case ">": return operand1 > operand2;
                case "==": return operand1 == operand2;
                case "!=": return operand1 != operand2;
                case ">=": return operand1 >= operand2;
                case "<=": return operand1 <= operand2;
                default: throw new ArgumentException("Wrong inputed operator!!!!");
            }

        }

        internal class Passport
        {
            private DateOnly dateOfIssue;
            private DateOnly dateOfExpiry;
            private string? name;
            private string? passportNumber;
            public Passport()
            {
                dateOfIssue = new DateOnly();
                dateOfExpiry = new DateOnly();
                name = "noName";
                passportNumber = "noPassport number";
            }
            public Passport(string? Name, string? PassportNumber, DateOnly DateOfIssue, DateOnly DateOfExpiry )
            {
                this.name = Name;
                this.passportNumber = PassportNumber;
                this.dateOfIssue = DateOfIssue;
                this.dateOfExpiry = DateOfExpiry;
            }
            public void InputData()
            {
                bool correct = true;
                Console.WriteLine("-------------------Enter your passport details-------------------");
                do
                {
                    
                    Console.Write("Enter the passport holder's name:\t");
                    this.name = Console.ReadLine();

                    Console.Write("Enter the passport number:\t");
                    this.passportNumber = Console.ReadLine();



                    Console.Write("Enter date of issue day:\t");
                    int dateOfIssueDay = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter date of issue month:\t");
                    int dateOfIssueMonth = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter date of issue year:\t");
                    int dateOfIssueYear = Convert.ToInt32(Console.ReadLine());



                    Console.Write("Enter date of expiry day:\t");
                    int dateOfExpiryDay = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter date of expiry month:\t");
                    int dateOfExpiryMonth = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Enter date of expiry year:\t");
                    int dateOfExpiryYear = Convert.ToInt32(Console.ReadLine());

                    
                    if (dateOfIssueDay != dateOfExpiryDay || dateOfIssueMonth != dateOfExpiryMonth || dateOfExpiryYear > dateOfIssueYear + 10)
                    {
                        Console.WriteLine("Invalid expiry date!!! Passport not issued for more than 10 years!");
                        Console.WriteLine("-------------------Enter your passport details again-------------------");
                    }
                    else
                    {
                        try
                        {
                            this.dateOfIssue = new(dateOfIssueYear, dateOfIssueMonth, dateOfIssueDay);
                            this.dateOfExpiry = new(dateOfExpiryYear, dateOfExpiryMonth, dateOfExpiryDay);
                            new ArgumentOutOfRangeException("Month, or Day parameters describe an un-representable format.");
                        }
                        catch (ArgumentOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            correct = true;
                        }
                        
                        
                    }
                } while (correct);
            }
            public override string ToString()
            {
                var str = "Name\t"+ this.name + "\nPassport number:\t" + this.passportNumber + "\nDate of issue:\t"
                          + dateOfIssue.ToString() + "\nDate of expiry:\t" + dateOfExpiry.ToString();
                return str;
            }
        }


        
    }
}