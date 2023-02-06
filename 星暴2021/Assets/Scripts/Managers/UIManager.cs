using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using CreateMapSystem;

public class UIManager : MonoBehaviour
{
    private ICanvas canvas; // 切換當前顯示介面（創造 或 存讀檔）
    [SerializeField] private EventSystem ES;
    public ModeManager ModeM;
    public MissionManager MissionM;
    private DatasPath path;

    /// UI畫布
    public CreateCanvas createCanvas;
    public SaveLoadCanvas saveLoadCanvas;

    private Vector3 getOutV2 = new Vector3(5000, 0, 0);
    private Vector3 backV2 = new Vector3(0, 0, 0);

    /// 選項自動載入器
    private CreateAutoLoad createAutoLoad; // 載入創造模式物件菜單（objData）
    private SLAutoLoad slAutoLoad; // 讀檔時載入既有檔案 （Datas 資料夾下所有 csv）

    private Transform createBtn; // 創造模式按紐
    private Transform saveloadBtn; // 存讀檔模式按紐
    private int createBtnCount;
    private int saveloadBtnCount;
    private UnityAction[] createActions;
    private UnityAction[] saveActions;
    private UnityAction[] loadActions;


    public Transform DesignParent;
    public GameObject cPlane;
    public GameObject slPlane;
    public GameObject SavePlane;
    public GameObject LoadPlane;
    public GameObject cAllBtn;
    public GameObject slAllBtn;

    public Transform cUGUI;
    public Transform slUGUI;

    public void Init() // 初始化
    {
        instance();
        ModeM.Init();
        createAutoLoad.Init();
        MissionM.Init();
        MissionM.DesignParent = DesignParent;

        createCanvas.Plane = cPlane;
        createCanvas.autoLoader = createAutoLoad;
        createCanvas.AllBtn = cAllBtn;

        saveLoadCanvas.Plane = slPlane;
        saveLoadCanvas.autoLoader = slAutoLoad;
        saveLoadCanvas.AllBtn = slAllBtn;
        saveLoadCanvas.SavePlane = SavePlane;
        saveLoadCanvas.LoadPlane = LoadPlane;
        saveLoadCanvas.Input =
            saveLoadCanvas.SavePlane.transform.GetChild(2).GetComponent<InputField>();

        createAutoLoad.UGUI = cUGUI;
        slAutoLoad.UGUI = slUGUI;
        slAutoLoad.Init();

        canvas = saveLoadCanvas;
        Cancel();

        AutoLoads();
        ButtonAddListener();

        canvas = createCanvas;
        DisplayPlane();

        backV2 = new Vector3(-5000, 0, 0);
        last = ModeM.createMode.ObjPoolList[0];
    }

    public void instance()
    {
        path = new DatasPath();
        createCanvas = new CreateCanvas();
        saveLoadCanvas = new SaveLoadCanvas();
        createAutoLoad = new CreateAutoLoad();
        slAutoLoad = new SLAutoLoad();

        createActions = new UnityAction[] {
            LeaveCreate,
            saveBtn,
            loadBtn,
            ClearALL
        };
        saveActions = new UnityAction[] {
            DataNameExist,
            Save,
            Cancel,
        };
        loadActions = new UnityAction[] {
            Load,
            Cancel
        };
    }

    public void AutoLoads() // 載入當前 UI畫布 的所需選項
    {
        canvas.autoLoader.Init();
        canvas.autoLoader.AutoLoad();
        canvas.itemList = canvas.autoLoader.props;
    }

    public void ButtonAddListener()
    {
        createBtn = createCanvas.AllBtn.transform;
        createBtnCount = createBtn.childCount - 3;

        for (int i = 0; i < createBtnCount; i++)
        {
            createBtn.GetChild(i + 1).GetComponent<Button>()
            .onClick.AddListener(createActions[i]);
        }

        saveloadBtn = saveLoadCanvas.AllBtn.transform;

        saveloadBtnCount = saveloadBtn.GetChild(0).childCount - 2;
        for (int i = 0; i < saveloadBtnCount; i++)
        {
            if (i == 0)
                saveloadBtn.GetChild(0).GetChild(i + 2).GetComponent<InputField>()
                    .onValueChanged.AddListener(delegate { DataNameExist(); });
            else
                saveloadBtn.GetChild(0).GetChild(i + 2).GetComponent<Button>()
                .onClick.AddListener(saveActions[i]);
        }

        saveloadBtnCount = saveloadBtn.GetChild(1).childCount - 2;
        for (int i = 0; i < saveloadBtnCount; i++)
        {
            saveloadBtn.GetChild(1).GetChild(i + 2).GetComponent<Button>()
            .onClick.AddListener(loadActions[i]);
        }
    }


    public void UIManager_Update()
    {
        check_TGbtn();
        ModeM.ModeManager_Update();
    }


    private GameObject last;
    private GameObject Child;
    public void check_TGbtn()
    {
        for (int i = 0; i < createAutoLoad.UGUI.childCount; i++)
        {
            Child = createAutoLoad.UGUI.transform.GetChild(i).gameObject;

            if (EventSystem.current.currentSelectedGameObject != Child)
                continue;
            else // 如果有一個按鈕被選中
            {
                ModeM.mode = ModeM.createMode;
                ModeM.mode.targetObject = ModeM.createMode.ObjPoolList[i];
                last = ModeM.mode.targetObject;
                ModeM.createMode.ObjId = i;
            }
        }
        return;
    }

    public void DisplayPlane()
    {
        canvas.autoLoader.AutoLoad();
        canvas.Plane.transform.localPosition = backV2;
    }

    public void Cancel()
    {
        ModeM.mode = ModeM.editMode;
        canvas.Plane.transform.localPosition = getOutV2;
    }


    public void saveBtn()
    {
        if (ModeM.createMode.targetObject != null)
            ModeM.createMode.targetObject.transform.position = ModeM.createMode.PoolPosV3;

        ModeM.mode = ModeM.settingMode;
        canvas = saveLoadCanvas;
        saveLoadCanvas.Plane = saveLoadCanvas.SavePlane;
        DisplayPlane();
    }

    public void loadBtn()
    {
        if (ModeM.createMode.targetObject != null)
            ModeM.createMode.targetObject.transform.position =
                ModeM.createMode.PoolPosV3;

        ModeM.mode = ModeM.settingMode;
        canvas = saveLoadCanvas;
        saveLoadCanvas.Plane = saveLoadCanvas.LoadPlane;

        AutoLoads();
        DisplayPlane();
    }

    public void Save()
    {
        if (saveLoadCanvas.Input.text == null)
            return;
        
        if (saveLoadCanvas.Input.text == "ObjData")
            return;

        MissionM.SaveMission(path.MapsPath, saveLoadCanvas.Input.text);
        Cancel();
    }

    public void Load()
    {
        ModeM.settingMode.filename =
            path.MapsPath + slAutoLoad.dp.options[slAutoLoad.dp.value].text;

        MissionM.ClearMap();
        MissionM.LoadMission(ModeM.settingMode.filename);
        Cancel();
    }

    public void DataNameExist()
    {
        if (saveLoadCanvas.Input.text == null)
            return;

        Text warning = saveLoadCanvas.SavePlane.transform.GetChild(1).GetComponent<Text>();

        if (saveLoadCanvas.Input.text == "ObjData")
            warning.text = 
                "這是被占用的檔名！覆蓋檔案將導致程式錯誤，請換個檔名";
        else if (File.Exists(path.MapsPath + saveLoadCanvas.Input.text + ".csv"))
            warning.text =
                 "*已有相同檔名，如果存檔將覆蓋同名檔案";
        else
            warning.text = null;
    }

    public void ClearALL() // 清空地圖物件
    {
        if (ModeM.mode == ModeM.settingMode)
            return;

        ModeM.mode.targetObject = null;
        MissionM.ClearMap();
    }

    public void LeaveCreate() // 離開創造模式
    {
        if (ModeM.createMode.targetObject != null)
            ModeM.createMode.targetObject.transform.position = 
                ModeM.createMode.PoolPosV3;

        ES.SetSelectedGameObject(null);
        ModeM.mode = ModeM.editMode; // 切換為編輯模式
    }
}
