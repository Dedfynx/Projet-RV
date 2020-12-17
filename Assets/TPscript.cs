using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPscript : MonoBehaviour
{
	GameObject player;

    GameObject spawn;
    GameObject spawn2;

    GameObject fin1;

    int numNiveau = 1;
    double ecart = 1.0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     	player = GameObject.FindWithTag("Player");

        spawn = GameObject.Find("SpawnPoint");
        spawn2 = GameObject.Find("SpawnPoint2");

        fin1 = GameObject.Find("FinNiveau1");

        if(player.transform.position.y < -10){
        	if(numNiveau == 1){
        		player.transform.position = spawn.transform.position;
        		player.transform.rotation = spawn.transform.rotation;
        	}
        	if(numNiveau == 2){
        		player.transform.position = spawn2.transform.position;
        		player.transform.rotation = spawn2.transform.rotation;
        	}
        }

        double x1 = player.transform.position.x - ecart;
        double x2 = player.transform.position.x + ecart;
        double z1 = player.transform.position.z - ecart;
        double z2 = player.transform.position.z + ecart;

        if(x1 <= fin1.transform.position.x && x2 >= fin1.transform.position.x && z1 <= fin1.transform.position.z && z2 >= fin1.transform.position.z){
        	player.transform.position = spawn2.transform.position;
        	player.transform.rotation = spawn2.transform.rotation;
        	numNiveau++;
        }

    }
}
