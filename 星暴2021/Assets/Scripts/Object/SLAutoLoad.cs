using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using CreateMapSystem;

public struct SLAutoLoad : IAutoLoad
{
    public Transform UGUI { get; set; } // 用拉的
    public List<string> props { get; set; }
    public Dropdown dp;
    public DirectoryInfo dir;
    private DatasPath pathDatas;

    public void Init()
    {
        pathDatas = new DatasPath();
        props = new List<string>();

        dp = UGUI.GetComponent<Dropdown>();
        dir = new DirectoryInfo(pathDatas.MapsPath);
    }

    public void AutoLoad() // 讀檔時載入既有檔案 （Datas 資料夾下所有 csv）
    {
        dp.ClearOptions();
        props.Clear();

        for (int i = 0; i < dir.GetFiles("*.csv").Length; i++)
        {
            props.Add(dir.GetFiles("*.csv")[i].Name);
        }

        dp.AddOptions(props);
    }
}
