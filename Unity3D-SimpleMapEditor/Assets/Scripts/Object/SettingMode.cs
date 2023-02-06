using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CreateMapSystem;
using LSFile;


public class SettingMode : IMode
{
    // 創造模式菜單選中的物件 或 編輯模式指向的物件 或 讀檔選中的選項
    public GameObject targetObject { get; set; }
    public void Rotate(int y){}
    public string filename;

    
}
