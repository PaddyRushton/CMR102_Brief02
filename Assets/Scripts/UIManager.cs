using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Player One Variables
    public GameObject playerOneCanvas; // a reference to the players goal score canvas
    public Text playerOneScoreText; // a reference to the text we'll be modifying
    public Color playerOneColour; // a reference to the text colour we'll be using

    // Player Two Variables
    public GameObject playerTwoCanvas; // a reference to the players goal score canvas
    public Text playerTwoScoreText; // a reference to the text we'll be modifying
    public Color playerTwoColour; // a reference to the text colour we'll be using


    /// <summary>
    /// Hide the canvas at the start of the game until the ball has been spawned
    /// </summary>
    /// <param name="displayScores"></param>
public void DisplayScores(bool displayScores)
    {
        if(playerOneCanvas == null || playerTwoCanvas == null)
        {
            Debug.LogError("No canvas has been assigned for this player");
            return;
        }

        playerOneCanvas.SetActive(displayScores);
        playerTwoCanvas.SetActive(displayScores);
    }

    public void UpdateScores(int playerOneScore, int playerTwoScore)
    {
        if(playerOneScoreText == null || playerTwoScoreText == null)
        {
            Debug.LogError("No text has been assigned for this player");
            return;
        }

        playerOneScoreText.color = playerOneColour; // change the text colour to the player colour
        playerOneScoreText.text = playerOneScore.ToString(); // set the text to display the score

        playerTwoScoreText.color = playerTwoColour; // change the text colour to the player colour
        playerTwoScoreText.text = playerTwoScore.ToString(); // set the text to display the score

    }
}
