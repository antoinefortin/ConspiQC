using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PlayerState
{
    int isPlaying;
    int isDonePlaying;
    int isRollingDice;
    int iHidling;
}

public class Player : MonoBehaviour
{

    // Player infos
    public string nameD;
    public string medias;
    public Texture2D textureBuffer; // Not really
    public int chloroquineAmount;
    public int youtubeFollowers;
    public int cash;

    // References
    public GameObject refCard;
    public GameObject refPion;
    public Color pionColor;

    // State
    public PlayerState playerState = new PlayerState();
    public int state = 4;
    public bool isPlaying = false;
    public bool isWaitingForInput = true;

    // Turn Infos
    private int turnCounter = 0;
    private int diceResult  = 0;
    private bool hasRolledDice = false;


    // Debug
    private bool oncer = false;
    private GameObject camGO;
    private Camera theMainCam;
    

    private void InitPlayer()
    {
        // Walk each child object
        foreach (Transform c in refCard.transform)
        {
            Debug.Log(c.name);
            switch (c.name)
            {
                case "Picture":

                    print("On Picture");
                    MeshRenderer meshRenderer = c.GetComponent<MeshRenderer>();
                    meshRenderer.material.SetTexture("_MainTex", textureBuffer);
                                        
                    break;

                case "Infos":
                    foreach (Transform sc in c.transform)
                    {

                        if (sc.name == "Static")
                        {
                            foreach (Transform ssc in sc.transform)
                            {
                                Debug.Log(ssc.name);
                                if (ssc.name == "Name")
                                {
                                    TextMesh cur = ssc.GetComponent<TextMesh>();
                                    cur.text = nameD;
                                }

                                if (ssc.name == "Media")
                                {
                                    TextMesh cur = ssc.GetComponent<TextMesh>();
                                    cur.text = medias;
                                }

                                if (ssc.name == "ChloroquineAmount")
                                {
                                    TextMesh cur = ssc.GetComponent<TextMesh>();
                                    cur.text = chloroquineAmount.ToString();
                                }

                                if (ssc.name == "YoutubeAmount")
                                {
                                    TextMesh cur = ssc.GetComponent<TextMesh>();
                                    cur.text = youtubeFollowers.ToString();
                                }

                                if (ssc.name == "MoneyAmount")
                                {
                                    TextMesh cur = ssc.GetComponent<TextMesh>();
                                    cur.text = cash.ToString();
                                }


                            }    
                        }
                    }
                    break;
                default:
    
                    break;
            }
        }

    }

    private void InitPion()
    {
       Renderer pionRenderer = refPion.GetComponent<Renderer>();
       pionRenderer.material.SetColor("_Color", pionColor);

    }
    // Start is called before the first frame update
    void Start()
    {
        camGO = GameObject.Find("Main Camera");

        theMainCam = camGO.GetComponent<Camera>();

        if (refCard)
        {
            InitPlayer();
        }

        InitPion();

    }

    // Update is called once per frame
    void Update()
    {
        HandleState();
    }

    void HandleState()
    {
        switch (state)
        {
            case 4:
                // Add more state later...
                break;
            case 3:
                // Add more state later...
                break;
            case 2:

                break;
            case 1:
                // Waiting for Input as init.
                isWaitingForInput = true;
                DoPlayerTurn();
                
                break;
            case 0:
                DoPlayerIsWaitingToPlay();
                break;
            default:
                break;
        }
    }

    void DoPlayerIsWaitingToPlay()
    {
        
    }


    void DoPlayerTurn()
    {

        Debug.Log(nameD + "Is playing");
        if (isWaitingForInput)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = theMainCam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {

                    // Hit button dice
                    if (hit.collider.gameObject.name == "RollDiceButton")
                    {
                        diceResult = GetDiceNumber();
                        hasRolledDice = true;
                    }
                    
                }
            }

            if (hasRolledDice)
            {

                MovePionOnBoard(diceResult);
            }
        }
    }


    void MovePionOnBoard(
        int move
    )
    {
        refPion.transform.position = 
            new Vector3(refPion.transform.position.x,
                        refPion.transform.position.y,
                         refPion.transform.position.y + move
                        );
        Debug.Log(move);
    }

    int GetDiceNumber()
    {
        Debug.Log(diceResult);
        return Random.Range(1,7);
    }
}


