using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateMapSystem
{
    public interface ICanvas
    {
        public GameObject Plane { get; set; }
        public List<string> itemList { get; set; }
        public IAutoLoad autoLoader { get; set; }
        public GameObject AllBtn { get; set; }
    }

}