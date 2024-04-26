using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{
      public LayerMask layerMask;
      private GameObject? selectedPrefab = null;
      public TMPro.TMP_Dropdown dropdown;
    
     void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 spawnPosition = hit.point+Vector3.up*0.01f; 
                GameObject furniture = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity); 

                GameObject floorBobject = GameObject.Find("FloorB");
                GameObject floorAobject = GameObject.Find("FloorA");

                if (floorBobject != null)
                {
                     furniture.transform.parent = floorBobject.transform;
                }
                else if (floorAobject != null)
                {
                    furniture.transform.parent = floorAobject.transform;
                }
                
                dropdown.value = 0;
            }
        }
    }

    public void SelectPrefab(GameObject? prefab)
    {
        selectedPrefab = prefab;
    }
}
