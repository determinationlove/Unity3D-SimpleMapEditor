using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateMapSystem;
using LSFile;

public class CreateMode : IMode
{
    private DatasPath pathDatas = new DatasPath();
    private pathFile pf_obj;
    [SerializeField] private List<string> objData;
    public List<GameObject> ObjPoolList = new List<GameObject>();

    public Transform DesignParent { get; set; }
    public Vector3 mouseV3;

    // 創造模式菜單選中的物件 或 編輯模式指向的物件 或 讀檔選中的選項
    public GameObject targetObject { get; set; }

    private string instansPath;
    private Color checkColor;
    public Vector3 PoolPosV3 = new Vector3(5000, 0, 0);

    private Ray ray;
    private RaycastHit hit;
    private Vector3 hitPos;

    public int ObjId;

    public string getResPath(int n)
    {
        return objData[n].Split(',')[2] + "/" + objData[n].Split(',')[1];
    }

    public void ObjPool()
    {
        pf_obj = new pathFile(pathDatas.ObjDataCSV);
        objData = pf_obj.Load();
        checkColor = new Vector4(0.9f, 0.4f, 0, 0.5f);

        for (int i = 0; i < objData.Count; i++)
        {
            instansPath = getResPath(i);

            GameObject Prefab = GameObject.Instantiate(
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

    public void CheckPos()
    {
        // 用射線確認生成位置
        mouseV3 = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        ray = Camera.main.ScreenPointToRay(mouseV3);

        if (Physics.Raycast(ray, out hit))
            hitPos = hit.point; // 將會在 hitPos 生成物件
        else
            hitPos = PoolPosV3;
    }

    public void FollowMouse()
    {
        if (targetObject == null)
            return;

        targetObject.transform.position = hitPos;

        if (Input.GetMouseButtonDown(1)) // 如果按下右鍵
        {
            instansPath = getResPath(ObjId);

            InstansObj(
                ObjId, hitPos, targetObject.transform.rotation,
                instansPath, DesignParent
            );
            return;
        }
    }

    public void InstansObj(int ObjId, Vector3 posV3, Quaternion rotV3, string path, Transform designParent)
    {
        GameObject Obj =
            GameObject.Instantiate(Resources.Load<GameObject>(path), posV3, rotV3);
        Obj.transform.SetParent(designParent);
        Obj.transform.GetComponent<BoxCollider>().enabled = true;
    }

    public void Rotate(int y)
    {
        if (Input.GetKeyDown(KeyCode.Q))
            targetObject.transform.Rotate(0, -y, 0);
        if (Input.GetKeyDown(KeyCode.E))
            targetObject.transform.Rotate(0, y, 0);
    }
}
