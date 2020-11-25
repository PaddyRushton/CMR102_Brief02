using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseHandler : MonoBehaviour
{
    public LayerMask layersToHit; // the layers we are going to be allowed to hit
    public GameManager gameManager; // a reference to our game manager



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseInput(); 
    }


    /// <summary>
    /// Gets input from the players computer mouse/tap on the screen.
    /// </summary>
    void GetMouseInput()
    {
        if(Input.GetMouseButtonDown(0)) // get computer mouse or touch input
        {
            RaycastHit hit; // data stored on what we've hit
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); // draws a ray from my camera to my computer mouse position

            //do our raycast, if we hit something that blocks the ray, store the data as 'hit'
            if(Physics.Raycast(ray, out hit, layersToHit))
            {
                gameManager.SpawnObject(hit.point); // at the point in the world where the ray has hit, spawn our soccerball, or move it if it already exists!
            }
        }
    }
}
