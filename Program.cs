using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Створіть абстрактний клас “іграшка”: ціна, назва, кількість на складі.
//Похідні: “машинка”  Для цього класу створіть функції які мають
//перевизначитись(реалізацію вигадайте на ваш розсуд).
namespace Examples
{
   
    
    abstract class Toy 
    {
        public  int Price { get; set; }
        public  string Name { get; set; }
        public  int Amount { get; set; }

       

        public abstract void GetInfo();
       

    }

    
    class Car : Toy
    {
        private Dictionary<string, int> CarAmount()
        {
            Dictionary<string, int> car_amount = new Dictionary<string, int>()
            {
                {"Audi",250 },
                {"BMW", 25 },
                {"KIA", 10}

        };
            return car_amount;
        }
        private Dictionary<string, int> CarPrice()
        {
            Dictionary<string, int> car_price = new Dictionary<string, int>()
            {
                {"Audi",25000 },
                {"BMW", 2500 },
                {"KIA", 10000}

        };
            return car_price;
        }



        public override void GetInfo()
        {
            var carNames = CarAmount();
            var carPrice = CarPrice();
            foreach (var car in carNames)
            {
                Console.WriteLine($"Cars: {car.Key}");
            }
            Console.WriteLine("Choose car which price u wanna see");
            string a = Console.ReadLine();
           try
            {
                var result = from p in carPrice
                             where(p.Key==a)
                             select p;

                if(result.Any())
                {
                    foreach (var q in result)
                    {
                        Console.WriteLine($"Price of {q.Key} == {q.Value} $");
                    }
                    Console.WriteLine($"Try again? 1 - yes , any another - no");
                    int w = Convert.ToInt32(Console.ReadLine());
                    if(w==1)
                    {
                        Console.Clear();
                        GetInfo();
                    }
                    else
                    {
                        Environment.Exit(0);   
                    }
                }
                else
                {
                    throw new Exception();
                }
              
            }
            catch (Exception ex)
            {
                Console.WriteLine ($"Error: {ex.Message} \n Try again? 1 - yes , 2 - no");
                int c = Convert.ToInt32(Console.ReadLine());
                if (c == 1)
                {
                    Console.Clear ();
                    GetInfo();
                }
                
                  
            }
            
            
        }
    }

  

    internal class Program
    {
      
        static void Main(string[] args)
        {
            Toy bob = new Car();
            bob.GetInfo();
            Console.ReadKey();
            
        }
    }
}
