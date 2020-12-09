using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CroissantHandler : MonoBehaviour
{
    public GameObject croissantPrefab;  // a reference to the croissant prefab
    public GameObject currentCroissant; // the current croissant that's been spawned in
    public Transform arContentParent;   // reference to the overall parent of the AR Content.
    private Vector3 croissantLocation;   // stores a vector 3 of the croissants location
    public string breakfastTime;        // Stores the value of breakfast time
    public GameObject croissantCanvas;  // a reference to the players goal score canvas
    public Text croissantText;          // a reference to the text we'll be modifying
    public Color croissantTextColour;   // a reference to the text colour we'll be using
    public static CroissantHandler Instance { get; private set; }

    void Awake()
    {
        // Save a reference to the CroissantHandler component as our singleton instance
        Instance = this;
    }


    /// <summary>
    /// Spawns in a new croissant based on the position provided. If a croissant already exists in the world, just move it to that new position
    /// </summary>
    /// <param name="positionToSpawn"></param>
    public void SpawnBreakfast(Vector3 positionToSpawn)
    {
        if (croissantPrefab == null)
        {
            Debug.LogError("something's wrong! There's no croissant assigned in the inspector!");
            return;
        }

        // if the croissant isn't spawned in the world yet
        if (currentCroissant == null)
        {
            Debug.Log("Croissant is Here!!!!");
            //spawn in and store a reference to our croissant and parent it to our arContentParent (in this case our "gameWorld")
            currentCroissant = Instantiate(croissantPrefab, positionToSpawn, croissantPrefab.transform.rotation, arContentParent);
            currentCroissant.GetComponent<Rigidbody>().velocity = Vector3.zero; // sets the velocity of the croissant to 0
            currentCroissant.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // sets the angular velocity of the croissant to 0
            croissantCanvas = GameObject.Find("Croissant Canvas");
            croissantText = GameObject.Find("Croissant Text").GetComponent<Text>();
        }
        else
        {
            // if the croissant already exists, lets move it
            currentCroissant.transform.position = positionToSpawn; // move our existing croisant to the dedicated spawn position
            currentCroissant.GetComponent<Rigidbody>().velocity = Vector3.zero; // sets the velocity of the croissant to 0
            currentCroissant.GetComponent<Rigidbody>().angularVelocity = Vector3.zero; // sets the angular velocity of the croissant to 0
        }
        croissantLocation = currentCroissant.GetComponent<Rigidbody>().position; // sets croissantLocation to the current location in space of the croissant
        UpdateBreakfastTime();
    }

    public void UpdateBreakfastTime()
    {
        croissantText.color = croissantTextColour; // change the text colour to the player colour
        Quaternion croissantAngle = Quaternion.LookRotation(croissantLocation);
        
        float value = (croissantAngle.eulerAngles.y)*2;
        int hours = (int)value / 60;
        int minutes = (int)value - 60 * hours;
        breakfastTime = string.Format("{0:00}:{1:00}", hours, minutes);
        croissantText.text = breakfastTime; // set the text to display the correct time
        Debug.Log("bananas");
    }
}
