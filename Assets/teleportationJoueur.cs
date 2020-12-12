using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teleportationJoueur : MonoBehaviour
{
    // Start is called before the first frame update

    GameObject player;
    GameObject spawn;

    void Start()
    {

        player = GameObject.FindWithTag("Player");
        spawn = GameObject.FindWithTag("SpawnPoint");

        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
        Debug.Log("Test");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
