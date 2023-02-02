using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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


    public void Init() // 初始化
    {
        pathDatas = new DatasPath();

        createCanvas.autoLoader = createAutoLoad;
        saveLoadCanvas.autoLoader = slAutoLoad;

        canvas = createCanvas;
        DisplayPlane();
    }

    public void AutoLoads() // 載入當前 UI畫布 的所需選項
    {
        canvas.autoLoader.AutoLoad();
    }

    public void ButtonAddListener()
    {
        Transform createBtn = createCanvas.Plane.transform;
        List<Button> createBtnList = new List<Button>();
        int createBtnCount = createBtn.childCount;

        for (int i = 0; i < createBtnCount; i++)
        {
            createBtnList.Add(createBtn.GetChild(i).GetComponent<Button>());
        }

        //UnityEngine.Events.UnityAction[] actions = [saveBtn, loadBtn];

        //createBtnList[0].onClick.AddListener();
    }

    public void DisplayPlane()
    {
        canvas.autoLoader.AutoLoad();
        canvas.Plane.transform.localPosition = canvas.backV2;
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

    public void Cancel()
    {
        canvas.Plane.transform.localPosition = canvas.getOutV2;
    }
}
