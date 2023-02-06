using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using LSFile;
public class Saves : MonoBehaviour
{
    public string path, file;
    // Start is called before the first frame update

    public Transform Parent;
    private PlayerDatas PD;
    private Vector3 tempV3;

    void Start()
    {
        string all = "";
        pathFile pF = new pathFile(path, file);

        for (int i = 0; i < Parent.childCount; i++)
        {
            tempV3 = Parent.GetChild(i).transform.position;
            PD = Parent.GetChild(i).GetComponent<PlayerDatas>();
            all += (i + 1) + "," + PD.GetName() + "," + PD.GetSkill() + "," + tempV3.x + "," + tempV3.y + "," + tempV3.z + "\n";
        }

        pF.Save("ID,Name,Skill,X,Y,Z", all, null);
    }

}
