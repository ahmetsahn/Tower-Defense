using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShadowMove : MonoBehaviour
{

    private RaycastHit hit;
  
    public void Move()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out hit, 5000))
            {
                transform.position = hit.point;
            }
    }




}
