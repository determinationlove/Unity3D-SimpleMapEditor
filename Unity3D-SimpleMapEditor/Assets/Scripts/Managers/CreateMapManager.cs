using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMapManager : MonoBehaviour
{
    [SerializeField] private UIManager UIM;
    
    public void CreateMapManager_Start()
    {
        UIM.Init();
    }

    public void CreateMapManager_Update()
    {
        UIM.UIManager_Update();
    }

}