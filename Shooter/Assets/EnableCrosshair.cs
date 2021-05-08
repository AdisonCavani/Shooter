using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableCrosshair : MonoBehaviour
{
    private void Awake()
    {
        var obj = GameObject.Find("Crosshair");
        obj.GetComponent<Crosshair>().enabled = true;
    }
}
