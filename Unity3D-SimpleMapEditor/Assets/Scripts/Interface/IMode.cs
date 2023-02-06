using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateMapSystem
{
    public interface IMode
    {
        // 創造模式菜單選中的物件 或 編輯模式滑鼠指向的物件
        public GameObject targetObject { get; set; }

        public void Rotate(int y);
    }
}
