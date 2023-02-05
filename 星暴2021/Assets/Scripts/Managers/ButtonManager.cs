using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.IO;
using LSFile;

public class ButtonManager : MonoBehaviour
{
    /*
    [SerializeField] private MissionManager MissionM;
    [SerializeField] private TargetCreate TargetC;
    [SerializeField] private ScrollAutoLoad SAL;
    [SerializeField] private pathFile pf_map;
    [SerializeField] private RectTransform Content;
    [SerializeField] private int TargetObj;
    [SerializeField] private int TargetBtn;

    [SerializeField] private List<GameObject> elseBtn;

    private int objs;

    private int last;

    public Transform canvas;
    public Transform canvas2;

    public Vector2 backV2 = new Vector2(0, 0);
    public Vector2 getOutV2 = new Vector2(5000, 0);
    private Text warning;
    [SerializeField] private Dropdown dp;

    public void ButtonManager_Start()
    {
        Content = CreateMapManager.Content;
        TargetC = CreateMapManager.TargetC;
        objs = MissionM.objData.Count - 1;

        canvas2.GetChild(0).localPosition = getOutV2;
        canvas2.GetChild(1).localPosition = getOutV2;
        warning = canvas2.GetChild(0).GetChild(2).GetComponent<Text>();

        InputField inputfield = canvas2.GetChild(0).GetChild(1).GetComponent<InputField>();
        inputfield.onValueChanged.AddListener(delegate { DataNameExist(); });
        Button save = canvas2.GetChild(0).GetChild(3).GetComponent<Button>();
        save.onClick.AddListener(Save);
        Button cancelSave = canvas2.GetChild(0).GetChild(4).GetComponent<Button>();
        cancelSave.onClick.AddListener(Cancel);
        Button load = canvas2.GetChild(1).GetChild(2).GetComponent<Button>();
        load.onClick.AddListener(Load);
        Button cancelLoad = canvas2.GetChild(1).GetChild(3).GetComponent<Button>();
        cancelLoad.onClick.AddListener(Cancel);

        TargetC.TargetCreate_Init();
        setElseBtn();
    }

    public void Save_Btn()
    {
        canvas2.GetChild(0).localPosition = backV2;
    }

    public void Save()
    {
        if (InputDataName == null)
            return;
        
        datapath = System.IO.Path.Combine(Application.dataPath, "Datas/");

        MissionM.SaveMission(datapath, InputDataName);
        Cancel();
        SAL.DataDrop_AutoLoad();
    }

    private string InputDataName;
    private string datapath;

    public void DataNameExist()
    {
        InputDataName = canvas2.GetChild(0).GetChild(1).GetComponent<InputField>().text;

        if (InputDataName == null)
            return;

        datapath = System.IO.Path.Combine(Application.dataPath, "Datas", InputDataName + ".csv");
        //print(datapath);
        if (File.Exists(datapath))
            warning.text = "*已有相同檔名，如果存檔將覆蓋同名檔案";
        else
            warning.text = null;
    }

    public void Cancel()
    {
        canvas2.GetChild(0).localPosition = getOutV2;
        canvas2.GetChild(1).localPosition = getOutV2;
    }

    public void Load_Btn()
    {
        canvas2.GetChild(1).localPosition = backV2;
    }

    public void Load()
    {
        
        datapath = System.IO.Path.Combine(Application.dataPath, "Datas/");
        string filename =  datapath + dp.options[dp.value].text;
        Cancel();

        MissionM.ClearMap();
        MissionM.LoadMission(filename);
    }

    public void ClearLoad() // 移除地圖上的讀檔
    {
        MissionM.ClearInstans();
    }

    public void ClearALL() // 清空地圖物件
    {
        MissionM.ClearMap();
    }

    public void LeaveCreate() // 離開創造模式
    {
        GameObject ES = GameObject.Find("EventSystem");
        ES.GetComponent<UnityEngine.EventSystems.EventSystem>().SetSelectedGameObject(null);

        print(TargetC.checkObj);
        if (TargetC.checkObj == null)
            return;
    }



    public void setElseBtn()
    {
        canvas.GetChild(1).GetComponent<Button>().onClick.AddListener(LeaveCreate);
        canvas.GetChild(2).GetComponent<Button>().onClick.AddListener(Save_Btn);
        canvas.GetChild(3).GetComponent<Button>().onClick.AddListener(Load_Btn);
        canvas.GetChild(4).GetComponent<Button>().onClick.AddListener(ClearALL);
        canvas.GetChild(5).GetComponent<Button>().onClick.AddListener(ClearLoad);
    }

    public void setElseBtn_2()
    {
        //canvas2.GetChild(1).GetComponent<Button>().onClick.AddListener();
    }

    private GameObject _btn;
    public int objBtn()
    {
        for (int i = 0; i < objs; i++)
        {
            _btn = Content.transform.GetChild(i).gameObject;
            //print(EventSystem.current.currentSelectedGameObject);
            if (EventSystem.current.currentSelectedGameObject != _btn)
                continue;
            else // 如果有一個按鈕被選中
                return i;
        }
        return -87;
    }


    public void ButtonManager_Update()
    {
        objbtn();
    }

    public void objbtn()
    {
        TargetObj = objBtn();

        if (TargetObj < 0)
        {
            if (TargetC.checkObj != null)
                TargetC.checkObj.transform.rotation = Quaternion.identity;
            return;
        }


        if (last == TargetObj)
        {
            // 如果有按鈕被選中
            TargetC.CheckPos();
            TargetC.FollowMouse(TargetObj);
            return;
        }
        else
        {
            TargetC.Check = true;
        }
        if (last == -87)
            TargetC.Check = true;

        last = TargetObj;
    }
    */
}
