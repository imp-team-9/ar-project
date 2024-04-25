using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrangAndMove : MonoBehaviour
{
   private Transform childObject;
    private void Start()
    {
        distance = Vector3.zero;
        childObject = transform.GetChild(0);
    }


     RaycastHit hitLayerMask;
    Vector3 distance;

    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); 
            if (touch.phase == TouchPhase.Moved)
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                Debug.DrawRay(ray.origin, ray.direction * 1000, Color.green);

                int layerMask = 1 << LayerMask.NameToLayer("Wall");
                if (Physics.Raycast(ray, out hitLayerMask, Mathf.Infinity, layerMask))
                {
                    if (childObject.gameObject.activeInHierarchy){
                    if (distance == Vector3.zero) distance = this.transform.position - hitLayerMask.point;
                        this.transform.position = hitLayerMask.point + distance;
                    }
                }
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                distance = Vector3.zero;
            }
        }
    }



}
