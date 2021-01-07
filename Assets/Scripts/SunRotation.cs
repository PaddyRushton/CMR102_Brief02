using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunRotation : MonoBehaviour
{

    public float sunRotation = 1;
    public float newSunRotation;
    public float rotationSpeed;
    // Update is called once per frame
    void Update()
    {
                   
    newSunRotation = sunRotation + rotationSpeed;
        sunRotation = newSunRotation;
        Quaternion rot = new Quaternion();
    rot.eulerAngles = new Vector3(0, 0, newSunRotation);
    transform.rotation = rot;
    }
}
