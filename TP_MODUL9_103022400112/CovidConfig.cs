using System;
using System.Text.Json;

public class CovidConfig
{
	public string satuan_suhu {  get; set; }
	public int batas_hari_demam { get; set; }
	public string pesan_ditolak {  get; set; }
    public string pesan_diterima { get; set; }

	private string jsonPath = "D:/KPL/TP_MODUL9_103022400112/" +
        "TP_MODUL9_103022400112/obj/Debug/net10.0/covid_config.json";
    private class ConfigPath
    {
        public string satuan_suhu { get; set; }
        public string batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }

    public CovidConfig()
    {
        if (!File.Exists(jsonPath))
        {
            DefaultConfig();
        }

        LoadConfig();
    }

    private void DefaultConfig()
    {
        ConfigPath confPath = new ConfigPath
        {
            satuan_suhu = "config1.json",
            batas_hari_deman = "config2.json",
            pesan_ditolak = "config3.json",
            pesan_diterima = "config4.json"
        };

        File.WriteAllText(jsonPath, JsonSerializer.Serialize(confPath, new JsonSerializerOptions { WriteIndented = true }));

        File.WriteAllText("config1.json", JsonSerializer.Serialize("celcius"));
        File.WriteAllText("config2.json", JsonSerializer.Serialize(14));
        File.WriteAllText("config3.json", JsonSerializer.Serialize("Anda tidak diperbolehkan masuk ke dalam gedung ini"));
        File.WriteAllText("config4.json", JsonSerializer.Serialize("Anda dipersilahkan untuk masuk ke dalam gedung ini"));
    }

    public void LoadConfig()
    {
        ConfigPath path = JsonSerializer.Deserialize<ConfigPath>(File.ReadAllText(jsonPath));

        satuan_suhu = JsonSerializer.Deserialize<string>(File.ReadAllText(path.satuan_suhu));
        batas_hari_demam = JsonSerializer.Deserialize<int>(File.ReadAllText(path.batas_hari_deman));
        pesan_ditolak = JsonSerializer.Deserialize<string>(File.ReadAllText(path.pesan_ditolak));
        pesan_diterima = JsonSerializer.Deserialize<string>(File.ReadAllText(path.pesan_diterima));
    }

    public void UbahSatuan()
    {
        string satuanBaru;

        if (satuan_suhu == "celcius")
            satuanBaru = "fahrenheit";
        else
            satuanBaru = "celcius";

        File.WriteAllText("config1.json", JsonSerializer.Serialize(satuanBaru));

        LoadConfig();
    }
}
