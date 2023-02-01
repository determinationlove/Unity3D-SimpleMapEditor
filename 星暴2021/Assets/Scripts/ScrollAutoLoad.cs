using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using LSFile;

public class ScrollAutoLoad : MonoBehaviour
{
    private MissionManager mm;
    private string mapPath, objPath;
    private pathFile pf_obj;
    private List<string> objData;
    private string instans;
    public Transform Content;

    DirectoryInfo dir;
    private List<string> AllFileName;

    [SerializeField] private Dropdown dp;
    private int fileCount;

    public void ScrollAutoLoad_Start()
    {
        mapPath = CreateMapManager.CMM_mapPath;
        objPath = CreateMapManager.CMM_objPath;
        Content = CreateMapManager.Content.transform;

        pf_obj = new pathFile(objPath);
        objData = pf_obj.Load();

        AutoLoad();

        // 讀檔下拉選單
        dir = new DirectoryInfo(mapPath);
        AllFileName = new List<string>();

        DataDrop_AutoLoad();
    }

    public void AutoLoad()
    {
        for (int i = 0; i < objData.Count; i++)
        {
            instans = objData[i].Split(',')[1];
            //print(instans); 

            GameObject tempText = Instantiate(Resources.Load<GameObject>("UI/Button"), Content.transform);

            tempText.transform.parent = Content.transform;
            textInit(tempText.transform);
        }

    }

    void textInit(Transform _btn)
    {
        Text btn_t = _btn.GetChild(0).GetComponent<Text>();
        btn_t.text = instans;

        _btn.name = instans;
        _btn.transform.localScale = new Vector3(1, 1, 1);
        _btn.transform.localRotation = new Quaternion(0, 0, 0, 0);
    }

    void getFileCount()
    {
        fileCount = 0;

        fileCount += dir.GetFiles("*.csv").Length;
    }

    public void DataDrop_AutoLoad()
    {
        dp.ClearOptions();
        AllFileName.Clear();

        getFileCount();

        for (int i = 0; i < fileCount; i++)
        {
            AllFileName.Add(dir.GetFiles("*.csv")[i].Name);
        }

        dp.AddOptions(AllFileName);
    }
}
