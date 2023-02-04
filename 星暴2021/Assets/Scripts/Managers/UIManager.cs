using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using CreateMapSystem;

public class UIManager : MonoBehaviour
{
    private ICanvas canvas; // 切換當前顯示介面（創造 或 存讀檔）
    private ModeManager ModeM;
    private DatasPath pathDatas;

    /// UI畫布
    public CreateCanvas createCanvas;
    public SaveLoadCanvas saveLoadCanvas;

    /// 選項自動載入器
    private CreateAutoLoad createAutoLoad; // 載入創造模式物件菜單（objData）
    private SLAutoLoad slAutoLoad; // 讀檔時載入既有檔案 （Datas 資料夾下所有 csv）

    [SerializeField] private EventSystem ES;

    private Transform createBtn;
    private int createBtnCount;
    private List<Button> createBtnList = new List<Button>();
    private UnityAction[] actions;

    private List<Button> ObjBtnList = new List<Button>();

    public void Init() // 初始化
    {
        pathDatas = new DatasPath();

        actions = new UnityAction[] {
            LeaveCreate,
            saveBtn,
            loadBtn,
            ClearALL
        };

        createCanvas.autoLoader = createAutoLoad;
        saveLoadCanvas.autoLoader = slAutoLoad;

        canvas = createCanvas;

        AutoLoads();
        ButtonAddListener();
        DisplayPlane();
    }

    public void AutoLoads() // 載入當前 UI畫布 的所需選項
    {
        canvas.autoLoader.AutoLoad();
    }

    public void ButtonAddListener()
    {
        createBtn = createCanvas.AllBtn.transform;
        createBtnCount = createBtn.childCount;

        for (int i = 0; i < createBtnCount; i++)
        {
            createBtn.GetChild(i + 1).GetComponent<Button>()
            .onClick.AddListener(actions[i]);
        }
    }

    private GameObject last;
    private Button Child;
    public void check_TGbtn()
    {
        if (ModeM.mode != ModeM.createMode)
        {
            ModeM.mode.targetObject = null;
            return;
        }


        if (last == ModeM.mode.targetObject)
            return;


        for (int i = 0; i < createAutoLoad.UGUI.childCount; i++)
        {
            Child = createAutoLoad.UGUI.transform.GetChild(i).GetComponent<Button>();

            if (EventSystem.current.currentSelectedGameObject != Child)
                continue;
            else // 如果有一個按鈕被選中
                ModeM.mode.targetObject = ModeM.createMode.ObjPoolList[i];
        }
        return;
    }

    public void DisplayPlane()
    {
        canvas.autoLoader.AutoLoad();
        canvas.Plane.transform.localPosition = canvas.backV2;
    }

    public void Cancel()
    {
        canvas.Plane.transform.localPosition = canvas.getOutV2;
    }


    public void saveBtn()
    {
        canvas = saveLoadCanvas;
        saveLoadCanvas.Plane = saveLoadCanvas.SavePlane;
        DisplayPlane();
    }

    public void loadBtn()
    {
        canvas = saveLoadCanvas;
        saveLoadCanvas.Plane = saveLoadCanvas.LoadPlane;
        DisplayPlane();
    }

    public void ClearALL() // 清空地圖物件
    {
        if (ModeM.mode != ModeM.createMode)
            return;

        ModeM.createMode.MissionM.ClearMap();
    }

    public void LeaveCreate() // 離開創造模式
    {
        ES.SetSelectedGameObject(null);
        ModeM.mode = ModeM.editMode;
    }
}
