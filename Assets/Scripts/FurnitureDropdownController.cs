using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureDropdownController : MonoBehaviour
{
   public GameObject xrorigin;
    public GameObject[] furnitures;
  

    public void OnDropdownEvent(int index)
    {
        if (index == 0)
        {
            xrorigin.GetComponent<FurnitureController>().SelectPrefab(null);
        }
        else
        {
            xrorigin.GetComponent<FurnitureController>().SelectPrefab(furnitures[index - 1]);
        }
    }
}
