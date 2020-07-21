using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTurnHandler : MonoBehaviour
{

    public GameObject[] Players;
    private Player currentPlayer; // Reference to the script attached to "myEnemy" object.
    public GameObject refBoardVerbose;

    void Start()
    {

        // Force all player to to Hidle at start
        for (int i = 0; i < Players.Length; i++)
        {
            Players[0].GetComponent<Player>().state = -1;
        }

        // Init First Player
        currentPlayer = Players[0].GetComponent<Player>();
        currentPlayer.state = 1;
        ChangeDisplayBoardVerbose("Au tour de : " + currentPlayer.nameD +  " !!");

        UpdateCurrentPlayerInfos(currentPlayer);


    }

    void UpdateCurrentPlayerInfos(
        Player thePlayer
    )
    {
        
        GameObject refBoard = thePlayer.refCard;
        // Get frame and change its color
        foreach (Transform child in refBoard.transform)
        {
            if (child.name == "Frame")
            {
                GameObject frame = child.gameObject;
                Renderer pionRenderer = frame.GetComponent<Renderer>();
                pionRenderer.material.SetColor("_Color", Color.green);
            }
        }

        thePlayer.state = 1;


    }

    void ChangeDisplayBoardVerbose(
        string verboseText
    )
    {
        TextMesh refText = refBoardVerbose.GetComponent<TextMesh>();
        refText.text = verboseText;

    }
}
