using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("References:")]
    public List<player> players = new List<player>();


    // Start is called before the first frame update
    void Start()
    {
        // Temporary solution to always trigger a serve, because bot doesn't support serving yet.
        foreach (player p in players)
        {
            if (p is playerController)
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
