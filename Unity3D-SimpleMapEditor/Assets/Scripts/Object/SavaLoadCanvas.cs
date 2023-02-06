using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CreateMapSystem;

public class SaveLoadCanvas : ICanvas
{
    public GameObject Plane { get; set; }
    public List<string> itemList { get; set; } // 存檔列表
    public IAutoLoad autoLoader { get; set; }
    
    public GameObject SavePlane { get; set; }
    public GameObject LoadPlane { get; set; }
    public GameObject AllBtn  { get; set; }
    public InputField Input;
}
