using UnityEngine;
using System;
using System.Collections.Generic;
using LSFile;

public class CsvManager : MonoBehaviour
{
    [SerializeField]
    private string path;
    [SerializeField]
    private string file;
    //[SerializeField]
    private string Col; // 在 inspector 填寫
    //[SerializeField]
    private List<string> newData; // 因為public所以不需要實例化

    private pathFile csv;
    public void CsvManager_Start()
    {
        newData = new List<string>();
        csv = new pathFile(path, file, Col);

        newData = csv.Load(false);
    }
    public string GetPath()
    {
        return path;
    }

    public void SetPath(string _path)
    {
        path = _path;
    }

    public void SaveGame()
    {
        //csv.Save(newData, null);
    }

    public List<string> GetData()
    {
        return newData;
    }
}