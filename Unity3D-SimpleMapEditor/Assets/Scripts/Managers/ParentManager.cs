using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParentManager : MonoBehaviour
{
    [SerializeField]
    private Transform Parents;
    //[SerializeField]
    private List<Transform> Childs;

    // Start is called before the first frame update
    public void ParentManager_Start()
    {
        Childs = new List<Transform>();
        for (int i = 0; i < Parents.childCount; i++)
        {
            Childs.Add(Parents.GetChild(i));
        }
    }

    public void ParentManager_Update(bool _strat = true)
    {
        if (_strat == false)
            return;
        for (int i = 0; i < Parents.childCount; i++)
        {
            Childs[i].name = Random.Range(0, 100).ToString();
        }
    }
}
