using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("References:")]
    public List<Player> players = new List<Player>();

    enum GameStateEnum{SRV, REC, DEF, SET, SPK, BLK}

    private GameStateEnum blueState;
    private GameStateEnum redState;


    // Start is called before the first frame update
    void Start()
    {
        // Temporary solution for testing
        foreach (Player p in players)
        // Temporary solution to always trigger a serve, because bot doesn't support serving yet.
        foreach (player p in players)
        MatchStart();

    }
    // Start of the Map
    void MatchStart()
    {

        PlayStart(false);
    }
    // Start of the Set
    void SetStart(int setNumber)
    {
        int PointsBlue = 0;
        int PointsRed = 0;

        //Start of set
        if (PointsBlue + PointsRed == 0)
        {
            // Blue is Serving at start of Set.
            if (setNumber == 1 || setNumber == 3 || setNumber == 5) 
            {
                PlayStart(true);
            }
            // Red is Serving at start of Set
            else
            {
                PlayStart(false);
            }
        }
        else
        {

        }

    }
    // Start of a play
    void PlayStart(bool blueStart)
    {
        // Temporary solution to always trigger a serve, because bot doesn't support serving yet.
        foreach (player p in players)
        {
            if (p is Bot)
            if (p is playerController)
            if (p is bot)
            {
                p.Serve();
            }
        }

        //players[(int)Random.Range(0, players.Count)].Serve();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
