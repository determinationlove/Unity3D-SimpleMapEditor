using System.Collections.Generic;
using System.IO;

public static class FasterAndFaster
{
    public static string LoadCSV(string path, string file, int id)
    {
        string[] CSV_FileLines;
        string Done_FileData;

        CSV_FileLines = File.ReadAllLines(path + file); // 切排
        Done_FileData = "";

        if (id <= 0 || id >= CSV_FileLines.Length)
        {
            return "id not found";
        }

        int props =  CSV_FileLines[0].Split(',').Length;

        for (int i = 0; i < props; i++)
        {
            Done_FileData +=
                CSV_FileLines[0].Split(',')[i] + "：" + CSV_FileLines[id].Split(',')[i] + "\n";
        }

        return Done_FileData;
    }

    public static void SaveCSV_CreactOrEdit(string _name, string _weapon, string _onLine, string path, string file)
    {
        Data_CSV tempPlayData = new Data_CSV();
        List<Data_CSV> Save_FileData = new List<Data_CSV>();

        tempPlayData.Name = _name;
        tempPlayData.Weapon = _weapon;
        tempPlayData.LastOnline = _onLine;
        Save_FileData.Add(tempPlayData);


        string all = "";
        string lines = "Id,Name,Weapon,LastOnline";
        all += lines + "\n";

        for (int i = 0; i < Save_FileData.Count; i++)
        {
            all  += i+1 + ","  + Save_FileData[i].Name + "," + Save_FileData[i].Weapon + "," + Save_FileData[i].LastOnline + "\n";
        }

        File.WriteAllText(path + file, all, System.Text.Encoding.UTF8);
    }
}
