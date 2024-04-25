using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class MaterialController : MonoBehaviour
{
    public LayerMask layerMask;
    public AudioSource audio;

    private Material? selectedMatrial = null;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, layerMask) && selectedMatrial != null)
            {
                hit.transform.gameObject.GetComponent<Renderer>().material = selectedMatrial;
				audio.Play();
            }
        }
    }

    public void SelectMaterial(Material? material)
    {
        selectedMatrial = material;
    }
}