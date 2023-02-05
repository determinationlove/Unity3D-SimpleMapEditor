using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LSFile;

public class GManager : MonoBehaviour
{
    [SerializeField]
    private CreateMapManager CreateMapM;

    void Start()
    {
        CreateMapM.CreateMapManager_Start();
    }

    void Update()
    {
        CreateMapM.CreateMapManager_Update();
        
    }
}