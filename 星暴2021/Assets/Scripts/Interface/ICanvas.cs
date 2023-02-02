using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateMapSystem
{
    public interface ICanvas
    {
        public GameObject Plane { get; set; }

        public Vector3 getOutV2 { get; set; }
        public Vector3 backV2 { get; set; }

        public List<string> csvData { get; set; }
        public List<string> itemList { get; set; }

        public IAutoLoad autoLoader { get; set; }

        //public void OptionsAutoLoad();

    }

}