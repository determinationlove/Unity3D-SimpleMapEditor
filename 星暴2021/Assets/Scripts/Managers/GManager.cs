using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using LSFile;

public class GManager : MonoBehaviour
{

    [SerializeField]
    private CsvManager csvM;

    [SerializeField]
    private JsonManager jsonM;

    //[SerializeField]
    //private ParentManager parentM;

    [SerializeField]
    private CreateMapManager CreateMapM;

    void Start()
    {
        //csvM.CsvManager_Start();
        //jsonM.JsonManager_Start();

        CreateMapM.CreateMapManager_Start();

    }

    void Update()
    {
        StartCoroutine(CreateMapM.update());
        
    }
}