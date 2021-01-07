using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform watchFace; /// a reference to our soccer field
    public Vector3 moveArea; /// the size of our area where we can move
    public Transform arCamera; // reference to our AR Camera
    public UIManager UIManager; // reference to our UI Manager
    public GameObject sun;


    //public AudioManager audioManager; // reference to our audio manager
    public AudioSource audioSource;



    // Update is called once per frame
    void Update()
    {

    }



    /// <summary>
    ///  This is a debug function that lets us draw objects in our scene view. It's not visible in the gamne view.
    /// </summary>
    private void OnDrawGizmosSelected()

    {
        //If the user hasn't put in a watchface, ignore this function.
        if (watchFace == null)
        {
            return;
        }
        Gizmos.color = Color.red; // Sets my Gizmo to red.
        Gizmos.DrawCube(watchFace.position + new Vector3(0, 0.1f, 0), moveArea); // draws a cube at the watchface position at the size of our'move area'.
    }

}
