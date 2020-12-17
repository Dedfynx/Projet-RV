﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPscript : MonoBehaviour
{
	GameObject player;
    GameObject spawn;
    GameObject cam;
    GameObject spawncam;



    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawn = GameObject.Find("SpawnPoint");
        cam = GameObject.Find("Main Camera");
        spawncam = GameObject.Find("SpawnCam");

    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.y < -15){
        	player.transform.position = spawn.transform.position;
        	player.transform.rotation = spawn.transform.rotation;
        	cam.transform.position = spawncam.transform.position;
        }

    }
}