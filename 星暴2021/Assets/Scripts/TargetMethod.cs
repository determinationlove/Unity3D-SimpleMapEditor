using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class TargetMethod : MonoBehaviour
{
    [SerializeField]
    private float y = 45;

    public void OnMouseDown()
    {
        transform.Rotate(0, y, 0);
    }

    void Update()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform.gameObject != this.gameObject)
                return;
            if (EventSystem.current.currentSelectedGameObject != null)
                return;
                
            if (Input.GetKeyDown(KeyCode.Q))
                hit.transform.Rotate(0, -y, 0);
            if (Input.GetKeyDown(KeyCode.E))
                hit.transform.Rotate(0, y, 0);
        }
    }
}
