using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateMapSystem;
using LSFile;

public class ModeManager : MonoBehaviour
{
    public IMode mode;
    public CreateMode createMode;
    public EditMode editMode;
    public SettingMode settingMode;
    private pathFile pf_obj;
    private DatasPath pathDatas;
    public Transform DesignParent;
    public GameObject Floor;

    private List<string> objData; // 菜單資料
    private string objPath; // ObjData.csv

    [Range(1, 359)]
    public int y = 45;

    public void Init()
    {
        instance();

        createMode.ObjPool();
        editMode.Floor = Floor;

        mode = editMode;
        mode.targetObject = null;

        objPath = pathDatas.ObjDataCSV;
        objData = pf_obj.Load();

        createMode.DesignParent = DesignParent;
    }

    public void instance()
    {
        pathDatas = new DatasPath();
        pf_obj = new pathFile(objPath);

        createMode = new CreateMode();
        editMode = new EditMode();
        settingMode = new SettingMode();
    }

    public void ModeManager_Update()
    {
        mode.Rotate(y);

        if (mode == createMode)
        {
            createMode.CheckPos();
            createMode.FollowMouse();
        }
    }
}
