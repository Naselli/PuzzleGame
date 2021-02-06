using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] private GameObject player;

    [SerializeField] private Transform[] spawnpoints;
    
    public enum Position {
        Normal,
        Cloned
    }

    [SerializeField] private Position spawnPosition;
    void Start()
    {
        if ( spawnPosition == Position.Normal ) {
            player.transform.position = spawnpoints [ 0 ].position;
        }
        if ( spawnPosition == Position.Cloned ) {
            player.transform.position = spawnpoints [ 1 ].position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
