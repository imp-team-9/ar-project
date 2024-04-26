using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeSliderController : MonoBehaviour
{
     public Slider slider;
     public Light sun;

     public void OnSliderEvent()
     {
          sun.transform.rotation = Quaternion.Euler(slider.value, -30, 0);
     }
}
