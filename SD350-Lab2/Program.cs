using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SD350Lab2
{
    internal class Program
    {
        //Had difficulty getting the StreamReader to work properly so I went with a simpler method. 
        static void Main(string[] args)
        {
            DecCost DecemberTicket = new DecCost(); 
            JuneJulyCost JuneJulyCost = new JuneJulyCost();
            Other OtherCost = new Other();

            Console.WriteLine("Welcome to the train station. Can you please enter the month number?");
            int monthNumber = int.Parse(Console.ReadLine());

            if(monthNumber == 6 || monthNumber == 7)
            {
                double price = JuneJulyCost.Calculate(50);
                Console.WriteLine($"You have qualified for the June / July Discount! Your cost is {price}. Thanks for travelling with us!");
            }
            else if(monthNumber == 12)
            {
                double price = DecemberTicket.Calculate(50);
                Console.WriteLine($"Your cost is {price}. Thanks for Travelling with us!");
            }
            else
            {
                double price = OtherCost.Calculate(50);
                Console.WriteLine($"Your cost is {price}. Thanks for Travelling with us!");
            }

            Console.ReadLine();
        }
    }

    public class TrainStation
    {
        public double TicketCost { get; set; }
        public double TicketDiscount { get; set; }

        public CalculationBehavior CalcBehave { get; set; }
        public TrainStation(CalculationBehavior cb)
        {
            CalcBehave = cb;
        }
        public double Calculate()
        {
            return CalcBehave.Calculate(TicketCost);
        }

    }

    public interface CalculationBehavior
    {
        double Calculate(double cost);
    }

    public class JuneJulyCost : CalculationBehavior
    {
        public double Discount = 0.25;
        public double Calculate(double cost)
        {
            return cost - (cost * Discount);
        }
    }

    public class DecCost : CalculationBehavior
    {
        public double Calculate(double cost)
        {
            return cost * 2;
        }
    }

    public class Other : CalculationBehavior
    {
        public double Calculate(double cost)
        {
            return cost;
        }
    }

}


