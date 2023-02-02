using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using UnityEngine.UI;
public class Loads : MonoBehaviour
{
    public string path;
    public string file;
    // Start is called before the first frame update
    private string[] allText;
    //public List<string> Col;
    [Range(1, 10)]
    public int ID;
    private string temp = "";

    public Button Btn;

    void Load()
    {
        allText = File.ReadAllLines(path + file);
    }
    void Start()
    {
        Init();
        Load();
        print(allText.Length);
        //Col = new List<string>();
        //allText[0] = ID,Name,LV,Money
        //ID 0
        //Name 1
        //LV 2
        //Money 3 

        CreatePlayerData("星爆", "雙刀", DateTime.Now.ToString());
        CreatePlayerData("C8763", "西瓜榴槤", DateTime.Now.ToString());
        Save();
    }

    public string PlayerData(int _id)
    {
        if (_id <= 0)
            return "NotData";
        if (_id >= allText.Length)
            return "NotData";
        temp =
        allText[0].Split(',')[1] + " : " + allText[_id].Split(',')[1] + "\n" +
        allText[0].Split(',')[2] + " : " + allText[_id].Split(',')[2] + "\n" +
        allText[0].Split(',')[3] + " : " + allText[_id].Split(',')[3] + "\n";
        return temp;
    }
    void InitList()
    {
        PlayData = new List<Data_CSV>();
        tempPlayData = new Data_CSV();
    }
    void Init()
    {
        InitList();//List初始化
        InitUI();//UI初始化
    }

    [SerializeField]
    public List<Data_CSV> PlayData;
    private Data_CSV tempPlayData;

    void CreatePlayerData(string _name, string _weapon, string _onLine)
    {
        tempPlayData = new Data_CSV();
        tempPlayData.Name = _name;
        tempPlayData.Weapon = _weapon;
        tempPlayData.LastOnline = _onLine;
        PlayData.Add(tempPlayData);
    }
    void Save()
    {
        string all = "";
        string col = "ID,Name,Weapon,LastOnline";
        all += col + "\n";
        for (int i = 0; i < PlayData.Count; i++)
        {
            all += i + 1 + "," + PlayData[i].Name + "," + PlayData[i].Weapon + "," + PlayData[i].LastOnline + "\n";
        }

        File.WriteAllText(Application.dataPath + "/" + "Data.zxc", all, System.Text.Encoding.UTF8);
    }
    void Update()
    {
        //print(PlayerData(ID));
    }


    void InitUI()
    {
        InitButton();
    }
    void InitButton()
    {
        Btn.onClick.AddListener(onClickSave);
    }
    void onClickSave()
    {
        print("Save");
        Save();
    }
}
