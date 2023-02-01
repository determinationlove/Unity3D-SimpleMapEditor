using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMapManager : MonoBehaviour
{
    public static string CMM_objPath;
    public static string CMM_mapPath;
    public static Transform DesignParent;
    public static Transform InstansParent;
    public static RectTransform Content;
    public static TargetCreate TargetC;

    [SerializeField] private MissionManager MissionM;
    [SerializeField] private ScrollAutoLoad ScrollAuto;
    [SerializeField] private ButtonManager ButtonM;

    private List<GameObject> NewObj;
    public List<string> NewObj_str;

    public void CreateMapManager_Start()
    {
        CMM_mapPath = System.IO.Path.Combine(Application.dataPath, "Datas/");
        CMM_objPath = System.IO.Path.Combine(Application.dataPath, "Datas", "ObjData.csv");
        DesignParent = GameObject.Find("parent Design").transform;
        InstansParent = GameObject.Find("parent Instans").transform;
        Content = GameObject.Find("UIContent").GetComponent<RectTransform>();
        TargetC = GameObject.Find("TargetCreate").GetComponent<TargetCreate>();
        

        MissionM.MissionManager_Start(true);
        ScrollAuto.ScrollAutoLoad_Start();
        ButtonM.ButtonManager_Start();
    }

    public void CreateMapManager_Update()
    {
    }


    public IEnumerator update()
    {
        ButtonM.ButtonManager_Update();
        yield return null;
    }

}
