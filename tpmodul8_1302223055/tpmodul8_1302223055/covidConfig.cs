using System;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;

namespace tpmodul8_1302223055
{
    public class CovidConfig
    {
        public string SatuanSuhu { get; set; }
        public int BatasHariDeman { get; set; }
        public string PesanDitolak { get; set; }
        public string PesanDiterima { get; set; }

        public CovidConfig()
        {
            SatuanSuhu = "celcius";
            BatasHariDeman = 14;
            PesanDitolak = "Anda tidak diperbolehkan masuk ke dalam gedung ini";
            PesanDiterima = "Anda dipersilahkan untuk masuk ke dalam gedung ini";
        }

        public void LoadConfig(string filePath)
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText("covid_config.json");
                CovidConfig config = JsonConvert.DeserializeObject<CovidConfig>(json);
                SatuanSuhu = config.SatuanSuhu;
                BatasHariDeman = config.BatasHariDeman;
                PesanDitolak = config.PesanDitolak;
                PesanDiterima = config.PesanDiterima;
            }
        }

        public void SaveConfig(string filePath)
        {
            string json = JsonConvert.SerializeObject(this);
            File.WriteAllText(filePath, json);
        }

        public void UbahSatuan()
        {
            SatuanSuhu = SatuanSuhu == "celcius" ? "fahrenheit" : "celcius";
        }
    }
}