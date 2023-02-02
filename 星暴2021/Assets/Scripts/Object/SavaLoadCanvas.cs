using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateMapSystem;

public class SaveLoadCanvas : ICanvas
{
    public GameObject Plane { get; set; }

    public Vector3 getOutV2 { get; set; }
    public Vector3 backV2 { get; set; }

    public List<string> csvData { get; set; }
    public List<string> itemList { get; set; }
    public IAutoLoad autoLoader { get; set; }
    
    public GameObject SavePlane { get; set; }
    public GameObject LoadPlane { get; set; }
}
