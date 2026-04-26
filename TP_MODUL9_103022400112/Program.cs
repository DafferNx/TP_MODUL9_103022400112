using System;

class Program
{
    static void Main(string[] args)
    {
        CovidConfig config = new CovidConfig();

        config.UbahSatuan();

        Console.WriteLine($"Berapa suhu badan anda saat ini? Dalam nilai {config.satuan_suhu}");
        double suhu = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala deman? ");
        int hariDemam = Convert.ToInt32(Console.ReadLine());

        bool suhuSesuai = true;

        if (config.satuan_suhu == "celcius")
        {
            suhuSesuai = (suhu >= 36.5 && suhu <= 37.5);
        }
        else if (config.satuan_suhu == "fahrenheit")
        {
            suhuSesuai = (suhu >= 97.7 && suhu <= 99.5);
        }

        if (suhuSesuai && hariDemam < config.batas_hari_demam)
        {
            Console.WriteLine(config.pesan_diterima);
        }
        else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}