using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CreateMapSystem;

public class Canvas : ICanvas
{
    public GameObject Plane { get; set; }
    public List<string> itemList { get; set; }
    public IAutoLoad autoLoader { get; set; }
    public GameObject AllBtn { get; set; }
}
