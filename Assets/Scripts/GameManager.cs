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

    public GameObject croissantPrefab; // a reference to the croissant prefab
    private GameObject currentCroissant; // the current croissant that's been spawned in
    public Transform arContentParent; // reference to the overall parent of the AR Content...

    public Vector3 croissantLocation;
    public string breakfastTime;

    public UIManager UIManager; // reference to our UI Manager

    //public AudioManager audioManager; // reference to our audio manager

    // Start is called before the first frame update
    void Start()
    {
        UIManager.DisplayBreakfastTime(false); // hide our canvasses to start with
    }

    // Update is called once per frame
    void Update()
    {
        GetBreakfastTime();
    }


    
    /// <summary>
    /// Spawns in a new croissant based on the position provided. If a croissant already exists in the world, just move it to that new position
    /// </summary>
    /// <param name="positionToSpawn"></param>
    public void SpawnBreakfast(Vector3 positionToSpawn)
    {
        // if the croissant isn't spawned in the world yet
        if(currentCroissant == null)
        {
            Debug.Log("Croissant is Here!!!!");
            //spawn in and store a reference to our croissant and parent it to our arContentParent (in this case our "gameWorld")
            currentCroissant = Instantiate(croissantPrefab, positionToSpawn, croissantPrefab.transform.rotation, arContentParent);
            currentCroissant.GetComponent<Rigidbody>().velocity = Vector3.zero; // sets the velocity of the croissant to 0
            currentCroissant.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // sets the angular velocity of the croissant to 0
            //AlertCharactersToSoccerBallSpawningIn(); // tell everyone the croissant has been spawned!
        }
        else
        {
            // if the croissant already exists, lets move it
            currentCroissant.transform.position = positionToSpawn; // move our existing croisant to the dedicated spawn position
            currentCroissant.GetComponent<Rigidbody>().velocity = Vector3.zero; // sets the velocity of the croissant to 0
            currentCroissant.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // sets the angular velocity of the croissant to 0
        }
    }


    public void GetBreakfastTime()
    {
        croissantLocation = currentCroissant.GetComponent<Rigidbody>().position; // sets croissant location to the current location in spac eof the croissant
        Debug.Log(croissantLocation);

       // breakfastTime = ;
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


    /// <summary>
    /// returns true or false if we're too close or not close enough to the camera
    /// </summary>
    /// <param name="character"></param>
    /// <param name="distanceThresholdOfPlayer"></param>
    /// <returns></returns>
    public bool IsCharacterTooCloseToCamera(Transform character, float distanceThresholdOfPlayer)
    {
        if (Vector3.Distance(arCamera.position, character.position) <= distanceThresholdOfPlayer)
        {
            // returns true if we're too close!
            return true;
        }
        else
        {
            // returns false if we're a safe distance away
            return false;
        }
    }

    /// <summary>
    /// Finds all characters in scene, loops through them and tells them that there's a soccer ball
    /// </summary>
    /*
     * private void AlertCharactersToSoccerBallSpawningIn()
    {
        CharacterController[] mice = FindObjectsOfType<CharacterController>(); // find all instances of our character controller class in our scene.
        for(int i=0; i<mice.Length; i++)
        {
            //tell the characters the  ball has spawned
            mice[i].SoccerBallSpawned(currentSoccerBallInstance.transform);
        }
        UIManager.DisplayScores(true); // Turn on the score canvasses!
        if(audioManager != null) // if we have a refernece to the audio manager
        {
            audioManager.PlayPlayingMusic(); // start playing playing music...
        }
    }

    /// <summary>
    /// A functio to handle what goes on when the characters are fleeing
    /// </summary>
    /// <param name="isRunningAway"></param>
    public void RunningAwayFromCamera(bool isRunningAway)
    {
        if(isRunningAway == areCharactersRunningAway) // don't do anything
        {
            return;
        }
        else
        {
            areCharactersRunningAway = isRunningAway; // set our private bools value
        }
        if(areCharactersRunningAway == true)
        {
            audioManager.PlayFleeingMusic(); // start playing hte fleeing music.
        }
        else
        {
            audioManager.PlayPreviousTrack(); // otherwise play previous track
        }
    } */
}
