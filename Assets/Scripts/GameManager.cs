using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Transform soccerField; /// a reference to our soccer field
    public Vector3 moveArea; /// the size of our area where we can move
    public Transform arCamera; // reference to our AR Camera

    public GameObject soccerBallPrefab; // a reference to the soccer ball in our scene
    private GameObject currentSoccerBallInstance; // the current soccer ball that's been spawned in
    public Transform arContentParent; // reference to the overall parent of the AR Content...

    public int playerOneScore;
    public int playerTwoScore;

    public UIManager UIManager; // reference to our UI Manager

    //public AudioManager audioManager; // reference to our audio manager

    private bool areCharactersRunningAway = false; // are any characters currently running away?

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("New RandomPosition of:" + ReturnRandomPositionOnField());
        playerOneScore = 0;
        playerTwoScore = 0;
        UIManager.DisplayScores(false); // hide our canvasses to start with
        UIManager.UpdateScores(playerOneScore, playerTwoScore); // update our players scores
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// Increase the passed in players score by 1! :D
    /// </summary>
    /// <param name="playerNumber"></param>
    public void IncreasePlayerScore(int playerNumber)
    {
        if(playerNumber == 1)
        {
            playerOneScore++;
        }
        else if (playerNumber == 2)
        {
            playerTwoScore++;
        }
        ResetSoccerBall();
        UIManager.UpdateScores(playerOneScore, playerTwoScore); // updates the score in the UIManager class to show the current value
    }


    private void ResetSoccerBall()
    {
        currentSoccerBallInstance.GetComponent<Rigidbody>().velocity = Vector3.zero; // reset the velocity of the ball to 0
        currentSoccerBallInstance.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // reset the angular velocity to 0
        currentSoccerBallInstance.transform.position = ReturnRandomPositionOnField(); // reset the position of ball to somewhere random
    }



    //Summary
    //Returns a random position within our move area
   //Summary
       public Vector3 ReturnRandomPositionOnField()
    {
        float xPosition = Random.Range(-moveArea.x / 2, moveArea.x / 2); /// gives us a random number between negative moveArea x and positive moveArea x
        float yPosition = soccerField.position.y;// our soccer field's y transform position
        float zPosition = Random.Range(-moveArea.z / 2, moveArea.z / 2); /// gives us a random number between negative moveArea z and positive moveArea z

        return new Vector3(xPosition, yPosition, zPosition);
    }




    /// <summary>
    ///  This is a debug function that lets us draw objects in our scene view. It's not visible in the gamne view.
    /// </summary>
    private void OnDrawGizmosSelected()

    {
        //If the user hasn't put in a soccer field, ignore this function.
        if (soccerField == null)
        {
            return;
        }
        Gizmos.color = Color.red; // Sets my Gizmo to red.
        Gizmos.DrawCube(soccerField.position + new Vector3(0,0.1f,0), moveArea); // draws a cube at the soccer fields position at the size of our'move area'.
    }
       
    /// <summary>
    /// returns true or false if we're too close or not close enough to the camera
    /// </summary>
    /// <param name="character"></param>
    /// <param name="distanceThresholdOfPlayer"></param>
    /// <returns></returns>
    public bool IsCharacterTooCloseToCamera(Transform character, float distanceThresholdOfPlayer)
    {
        if(Vector3.Distance(arCamera.position, character.position) <= distanceThresholdOfPlayer)
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
    /// Spawns in a new soccer ball based on the position provided. If a soccer ball already exists in the world, just move it to that new position
    /// </summary>
    /// <param name="positionToSpawn"></param>
    public void SpawnObject(Vector3 positionToSpawn)
    {
        if (soccerBallPrefab == null)
        {
            Debug.LogError("something's wrong! There's no soccer ball assigned in the inspector!");
            return;
        }
        // if the soccer ball isn't spawned in the world yet
        if(currentSoccerBallInstance == null)
        {
            //spawn in and store a reference to our soccer ball and parent it to our arContentParent (in this case our "gameWorld")
            currentSoccerBallInstance = Instantiate(soccerBallPrefab, positionToSpawn, soccerBallPrefab.transform.rotation, arContentParent);
            currentSoccerBallInstance.GetComponent<Rigidbody>().velocity = Vector3.zero; // sets the velocity of the soccer ball to 0
            currentSoccerBallInstance.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // sets the angular velocity of the soccer ball to 0
            //AlertCharactersToSoccerBallSpawningIn(); // tell everyone the ball has been spawned!
        }
        else
        {
            // if the soccer ball already exists, lets move it
            currentSoccerBallInstance.transform.position = positionToSpawn; // move our existing soccer ball to the dedicated spawn position
            currentSoccerBallInstance.GetComponent<Rigidbody>().velocity = Vector3.zero; // sets the velocity of the soccer ball to 0
            currentSoccerBallInstance.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // sets the angular velocity of the soccer ball to 0
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
