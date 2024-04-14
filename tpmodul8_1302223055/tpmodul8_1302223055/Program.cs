// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

using System;

namespace tpmodul8_1302223055
{
    class Program
    {
        static void Main(string[] args)
        {
            CovidConfig config = new CovidConfig();
            config.LoadConfig("covid_config.json");

            Console.WriteLine("Berapa suhu badan anda saat ini? Dalam nilai " + config.SatuanSuhu + ":");
            double suhuBadan = double.Parse(Console.ReadLine());

            Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam?");
            int hariDeman = int.Parse(Console.ReadLine());

            bool suhuValid = (config.SatuanSuhu == "celcius" && suhuBadan >= 36.5 && suhuBadan <= 37.5) ||
                             (config.SatuanSuhu == "fahrenheit" && suhuBadan >= 97.7 && suhuBadan <= 99.5);
            bool hariValid = hariDeman < config.BatasHariDeman;

            if (suhuValid && hariValid)
            {
                Console.WriteLine(config.PesanDiterima);
            }
            else
            {
                Console.WriteLine(config.PesanDitolak);
            }
        }
    }
}