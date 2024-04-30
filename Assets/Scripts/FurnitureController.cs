using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FurnitureController : MonoBehaviour
{
    public LayerMask layerMask;
    public AudioSource audio;
    public TMPro.TMP_Dropdown dropdown;

    private GameObject? selectedPrefab = null;
    
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask))
            {
                Vector3 spawnPosition = hit.point+Vector3.up*0.03f; 
                GameObject furniture = Instantiate(selectedPrefab, spawnPosition, Quaternion.identity); 

             

                if (hit.transform != null)
                {
                    furniture.transform.SetParent(hit.transform);
                }
                
                dropdown.value = 0;
				audio.Play();
            }
        }
    }

    public void SelectPrefab(GameObject? prefab)
    {
        selectedPrefab = prefab;
    }
}
