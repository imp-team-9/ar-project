using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaterialDropdownController : MonoBehaviour
{
    public GameObject xrorigin;
    public Material[] materials;
    
    public void OnDropdownEvent(int index)
    {
        if (index == 0)
        {
            xrorigin.GetComponent<MaterialController>().SelectMaterial(null);
        }
        else
        {
            xrorigin.GetComponent<MaterialController>().SelectMaterial(materials[index - 1]);
        }
    }
}
