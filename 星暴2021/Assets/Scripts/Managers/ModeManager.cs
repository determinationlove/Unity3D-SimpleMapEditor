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
    private pathFile pf_obj;
    private DatasPath pathDatas;

    [SerializeField] private List<string> objData; // 菜單資料
    [SerializeField] private string objPath; // ObjData.csv
    [SerializeField] private string instansPath; // Resources

    public int y = 45;

    public void Init()
    {
        createMode.ObjPool();

        mode = editMode;
        mode.targetObject = null;

        pathDatas = new DatasPath();
        objPath = pathDatas.ObjDataCSV;

        pf_obj = new pathFile(objPath);
        objData = pf_obj.Load();
    }

    public void CheckTartget() // 確定了 mode 的模式後才執行
    {
        switch (mode)
        {
            // 創造模式菜單選中的物件 或 編輯模式指向的物件
            case CreateMode createMode:
                mode.targetObject = createMode.TGobj();
                break;
            case EditMode editMode:
                mode.targetObject = editMode.TGobj();
                break;
        }
    }

    public void keyCheck()
    {
        mode.Rotate(y);
    }
/*
    public void ObjPool() // 物件池
    {
        for (int i = 0; i < objData.Count; i++)
        {
            instansPath = objData[i].Split(',')[2] + "/" + objData[i].Split(',')[1];

            GameObject Prefab = Instantiate(
                Resources.Load<GameObject>(instansPath), PoolPosV3, Quaternion.identity
            );

            for (int j = 0; j < Prefab.transform.childCount; j++)
            {
                Prefab.transform.GetChild(j).GetComponent<Renderer>().material.color
                = checkColor;

                Prefab.transform.GetChild(j).GetComponent<Renderer>().material.shader
                = Shader.Find("Transparent/Diffuse");
            }

            ObjPoolList.Add(Prefab);
        }
    }

    public void FollowMouse(int ObjId)
    {
        instansPath = objData[ObjId].Split(',')[2] + "/" + objData[ObjId].Split(',')[1];

        if (Check)
        {
            if (checkObj != null)
            {
                checkObj.transform.position = PoolPosV3;
                checkObj.transform.rotation = Quaternion.identity;
            }

            GameObject Obj = ObjPoolList[ObjId];

            checkObj = Obj;
            Check = false;
        }

        if (checkObj == null)
            return;

        checkObj.transform.position = hitPos;

        Rotate(y);

        if (Input.GetMouseButtonDown(1))
        {
            InstansObj(ObjId, hitPos, checkObj.transform.rotation);
            return;
        }
    }
*/
}
