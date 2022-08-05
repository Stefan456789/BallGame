using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("References:")]
    public List<Player> players = new List<Player>();


    // Start is called before the first frame update
    void Start()
    {
        // Temporary solution for testing
        foreach (Player p in players)
        {
            if (p is Bot)
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
