using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using LSFile;
/*
public class TargetCreate : MonoBehaviour
{
    private pathFile pf_obj;
    private ButtonManager BM;
    [SerializeField] private List<string> objData;
    [SerializeField] public string objPath;

    public Transform DesignParent;

    private Vector2 mouseTrans;
    private Vector3 worldTrans;
    private string instansPath;

    private Vector3 PoolPosV3 = new Vector3(5000, 0, 0);

    [SerializeField] private List<GameObject> ObjPoolList;

    [SerializeField] private Vector3 hitPos;

    [SerializeField] public bool Check = true;
    public GameObject checkObj;

    private Ray ray;
    private RaycastHit hit;

    private Color checkColor;
    private float y = 45;

    public void TargetCreate_Init()
    {
        objPath = CreateMapManager.CMM_objPath;
        pf_obj = new pathFile(objPath);
        objData = pf_obj.Load();

        DesignParent = CreateMapManager.DesignParent;

        checkColor = new Vector4(0.9f, 0.4f, 0, 0.5f);

        ObjPool();
    }

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

    public void CheckPos()
    {
        // 用射線確認生成位置
        mouseTrans = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        ray = Camera.main.ScreenPointToRay(mouseTrans); ;
        if (Physics.Raycast(ray, out hit))
            hitPos = hit.point; // 將會在 hitPos 生成物件
        else
            hitPos = PoolPosV3;
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

        if (Input.GetKeyDown(KeyCode.Q))
            checkObj.transform.Rotate(0, -y, 0);
        if (Input.GetKeyDown(KeyCode.E))
            checkObj.transform.Rotate(0, y, 0);
        if (Input.GetMouseButtonDown(1))
        {
            InstansObj(ObjId, hitPos, checkObj.transform.rotation);
            return;
        }
    }

    public void InstansObj(int ObjId, Vector3 posV3, Quaternion rotV3)
    {
        if (Check)
            return;

        GameObject Obj =
            Instantiate(Resources.Load<GameObject>(instansPath), posV3, rotV3);
        Obj.transform.parent = DesignParent;
        Obj.transform.GetComponent<BoxCollider>().enabled = true;
        Obj.AddComponent<TargetMethod>();
    }

}
*/
