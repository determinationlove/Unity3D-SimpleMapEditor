using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using JsonFile;

public class JsonManager : MonoBehaviour
{
    
    [SerializeField] private string path;

    public pathFile jf;
    [SerializeField] public JsonDatas json;
    public List<JsonDatas> jsonClass = new List<JsonDatas> ();

    public void JsonManager_Start()
    {
        jf = new pathFile(path); // method
        json = jf.Load(); // class

        print(json.Name);

        json.Name = "大大大寶狗";

        jf.Edit(json, 2, "巨巨巨寶狗", "牙通牙");

        jf.Save(json);

        print(json.Name);
        
    }


}
