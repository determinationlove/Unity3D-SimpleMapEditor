using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateMapSystem;

public class EditMode : IMode
{
    // 創造模式菜單選中的物件 或 編輯模式指向的物件
    public GameObject targetObject { get; set; } 

    public void Rotate(int y)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (Input.GetKeyDown(KeyCode.Q))
                hit.transform.Rotate(0, -y, 0);
            if (Input.GetKeyDown(KeyCode.E))
                hit.transform.Rotate(0, y, 0);
        }
    }

    // 創造模式菜單選中的物件 或 編輯模式指向的物件
    public GameObject TGobj()
    {
        return null;
    }
}
