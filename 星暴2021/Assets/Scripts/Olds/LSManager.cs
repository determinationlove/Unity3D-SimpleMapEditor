using UnityEngine;
using System;
using System.Collections.Generic;
using LSFile;

public class LSManager : MonoBehaviour
{
    public string Dataspath;
    public string Monfile, Mapfile;

    public List<string> MonDatas;



    public List<string> MapDatas;

    void Init()
    {
        MonDatas = new List<string>();
        pathFile csvFile = new pathFile(Dataspath, Monfile);
        print(csvFile.ExiFile());
        MonDatas = csvFile.Load();
        MapDatas = new List<string>();
        pathFile MapFile = new pathFile(Dataspath, Mapfile);
        print(csvFile.ExiFile());
        MapDatas = MapFile.Load();
    }

    void Start()
    {
        Init();
        InsObj("怪物/", MonDatas);
        InsObj("地圖/", MapDatas);
    }

    void InsObj(string _path, List<string> _Datas)
    {
        for (int i = 0; i < _Datas.Count; i++)
        {
            string[] temp = _Datas[i].Split(',');
            Vector3 tempV3 = new Vector3(float.Parse(temp[2]), float.Parse(temp[3]), float.Parse(temp[4]));
            Instantiate(Resources.Load<GameObject>(_path + temp[1]), tempV3, Quaternion.identity);
        }
    }
}