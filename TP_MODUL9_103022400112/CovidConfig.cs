using System.IO;
using System.Text.Json;

public class CovidConfig
{
    public string satuan_suhu;
    public int batas_hari_deman;
    public string pesan_ditolak;
    public string pesan_diterima;

    private string fileConfig = "covid_config.json";

    private class ConfigPath
    {
        public string satuan_suhu { get; set; }
        public string batas_hari_deman { get; set; }
        public string pesan_ditolak { get; set; }
        public string pesan_diterima { get; set; }
    }

    public CovidConfig()
    {
        LoadConfig();
    }

    public void LoadConfig()
    {
        var path = JsonSerializer.Deserialize<ConfigPath>(File.ReadAllText(fileConfig));

        satuan_suhu = JsonSerializer.Deserialize<string>(File.ReadAllText(path.satuan_suhu));

        batas_hari_deman = JsonSerializer.Deserialize<int>(File.ReadAllText(path.batas_hari_deman));

        pesan_ditolak = JsonSerializer.Deserialize<string>(File.ReadAllText(path.pesan_ditolak));

        pesan_diterima = JsonSerializer.Deserialize<string>(File.ReadAllText(path.pesan_diterima));
    }

    public void UbahSatuan()
    {
        string path = "config1.json";

        string current = JsonSerializer.Deserialize<string>(
            File.ReadAllText(path)
        );

        string baru = (current == "celcius") ? "fahrenheit" : "celcius";

        File.WriteAllText(path, JsonSerializer.Serialize(baru));

        LoadConfig();
    }
}