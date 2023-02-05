using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateMapSystem;

public class CreateCanvas : ICanvas
{
    public GameObject Plane { get; set; } // UI整體

    public List<string> itemList { get; set; } // 菜單按紐
    public IAutoLoad autoLoader { get; set; }

    public GameObject AllBtn { get; set; } // 所有按鈕的父物件
}
