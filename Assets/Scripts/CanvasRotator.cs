using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasRotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Vector3 relativePosition = transform.position - Camera.main.transform.position; // get the relative direciton of the canvas to the players camera
        relativePosition.z = 0; // zero our y axis as we don't want it to rotate on that axis.
        //relativePosition.x = 90;
        Quaternion rotation = Quaternion.LookRotation(relativePosition); // create a quaternian rotation to look at the relative position specified above (The location of the Canvas in the world)
        transform.rotation = rotation; // Set the canvas rotation to the current LookRotation specified above.
    }
}
