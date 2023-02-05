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

    [SerializeField] private List<string> objData; // 菜單資料
    [SerializeField] private string objPath; // ObjData.csv
    //[SerializeField] private string instansPath; // Resources

    public int y = 45;

    public void Init()
    {
        instance();

        createMode.ObjPool();

        mode = editMode;
        mode.targetObject = null;

        objPath = pathDatas.ObjDataCSV;
        objData = pf_obj.Load();
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
