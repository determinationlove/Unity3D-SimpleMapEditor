using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CreateMapSystem;
using LSFile;

public struct CreateAutoLoad : IAutoLoad
{
    public Transform UGUI { get; set; } // 用拉的
    public List<string> props { get; set; }
    private DatasPath pathDatas;
    private pathFile pf_obj;

    private GameObject temp;
    private Text tempT;

    public void Init()
    {
        pathDatas = new DatasPath();
        props = new List<string>();
        pf_obj = new pathFile(pathDatas.ObjDataCSV);

        props = pf_obj.Load();
    }

    public void AutoLoad() // 載入創造模式物件菜單（objData）
    {
        pathDatas = new DatasPath();

        for (int i = 0; i < props.Count; i++)
        {
            temp = GameObject.Instantiate(
                    Resources.Load<GameObject>("UI/Button"), UGUI.transform
                );

            tempT = temp.transform.GetChild(0).GetComponent<Text>();
            tempT.text = props[i].Split(',')[1];

            temp.transform.SetParent(UGUI.transform);
        }
    }


}
