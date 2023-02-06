using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CreateMapSystem
{
    public interface IAutoLoad
    {
        public Transform UGUI { get; set; }
        public List<string> props { get; set; }

        public void Init();
        public void AutoLoad();
    }
}

