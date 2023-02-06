using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSFile;
using CreateMapSystem;

public class MissionManager : MonoBehaviour
{

    public DatasPath path;

    [SerializeField] public Transform DesignParent { get; set; }

    [Range(0, 3)]
    public int FLevel;
    private string mapPath, objPath;
    public string col;

    public pathFile pf_map;
    public pathFile pf_obj;

    public List<string> mapData;
    public List<string> objData;

    private string temp;
    private string instansPath;

    // id, objId, pos, rotate, scale
    // 1, 1, 0:0:0, 0:0:0, 1:1:1
    public void MissionManager_Start(bool _start = true)
    {
        if (!_start)
            return;
        
        path = new DatasPath();

        mapPath = path.MapsPath;
        objPath = path.ObjDataCSV;

        pf_map = new pathFile(mapPath, null, col);
        pf_obj = new pathFile(objPath);
        mapData = new List<string>();
        objData = new List<string>();
        objData = pf_obj.Load();

    }

    public void SaveMission(string filepath, string filename, bool run = true)
    {
        if (!run)
            return;

        Transform tempTrans;

        mapData = new List<string>();
        mapData.Clear();

        for (int i = 0; i < DesignParent.childCount; i++)
        {
            temp = "";
            tempTrans = DesignParent.GetChild(i);

            for (int j = 0; j < objData.Count; j++)
            {
                if (tempTrans.name.Contains(objData[j].Split(',')[1]))
                {
                    temp = (i + 1).ToString() + "," + (j + 1).ToString() + ",";
                    break;
                }
            }

            temp += PV3(tempTrans.position) + "," + PV3(tempTrans.eulerAngles) + "," + PV3(tempTrans.localScale);
            
            mapData.Add(temp);
        }

        pf_map.Save(mapData, filepath, filename);
    }

    public string PV3(Vector3 _v3)
    {
        string temp = "F" + FLevel.ToString();
        return _v3.x.ToString(temp) + ":" + _v3.y.ToString(temp) + ":" + _v3.z.ToString(temp);
    }

    public Vector3 PV3_R(string _str)
    {
        return new Vector3(
            float.Parse(_str.Split(':')[0]),
            float.Parse(_str.Split(':')[1]),
            float.Parse(_str.Split(':')[2])
        );
    }

    public Quaternion PQ3_R(string _str)
    {
        Quaternion q = Quaternion.Euler(
            float.Parse(_str.Split(':')[0]),
            float.Parse(_str.Split(':')[1]),
            float.Parse(_str.Split(':')[2])
        );
        return q;
    }

    public void LoadMission(string filename, bool run = true)
    {
        if (!run)
            return;

        pf_map = new pathFile(mapPath);
        pf_obj = new pathFile(objPath);

        mapData = pf_map.Load(filename);
        //objData = pf_obj.Load();

        int temp = objData.Count;

        if (mapData.Count < 1)
            return;
            
        for (int i = 0; i < mapData.Count; i++)
        {
            for (int j = 0; j < temp; j++)
            {
                if (mapData[i].Split(',')[1].Contains((j + 1).ToString()))
                {
                    instansPath = objData[j].Split(',')[2] + "/" + objData[j].Split(',')[1];
                    print(instansPath);
                }
            }

            GameObject tempObj = Instantiate(
                Resources.Load<GameObject>(instansPath),
                PV3_R(mapData[i].Split(',')[2]), PQ3_R(mapData[i].Split(',')[3])
            );

            tempObj.transform.localScale = PV3_R(mapData[i].Split(',')[4]);
            tempObj.transform.GetComponent<BoxCollider>().enabled = true;
            tempObj.transform.parent = DesignParent.transform;
        }
    }

    public void ClearMap()
    {
        for (int i = 0; i < DesignParent.childCount; i++)
        {
            if (i == 0)
                continue;
            Destroy(DesignParent.GetChild(i).gameObject);
        }

        for (int i = 0; i < DesignParent.childCount; i++)
        {
            Destroy(DesignParent.GetChild(i).gameObject);
        }
    }
}