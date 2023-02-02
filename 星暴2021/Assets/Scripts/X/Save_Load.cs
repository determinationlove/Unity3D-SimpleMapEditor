using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System.IO;

/*
public class Data
{
    public string player;
    public string LastSaveTime;
}
*/

[System.Serializable]
public class Data_CSV {
    public int Id;
    public string Name;
    public string Weapon;
    public string LastOnline;
}
