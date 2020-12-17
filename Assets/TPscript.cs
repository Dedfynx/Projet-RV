using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPscript : MonoBehaviour
{
	GameObject player;

    GameObject spawn;
    GameObject spawn2;
    GameObject spawn3;

    GameObject fin1;
    GameObject fin2;

    int numNiveau = 1;
    double ecart = 3.0;

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
        spawn3 = GameObject.Find("SpawnPoint3");

        fin1 = GameObject.Find("FinNiveau1");
        fin2 = GameObject.Find("FinNiveau2");

        if(player.transform.position.y < -15){
        	if(numNiveau == 1){
        		player.transform.position = spawn.transform.position;
        		player.transform.rotation = spawn.transform.rotation;
        	}
        	if(numNiveau == 2){
        		player.transform.position = spawn2.transform.position;
        		player.transform.rotation = spawn2.transform.rotation;
        	}
        	if(numNiveau == 3){
        		player.transform.position = spawn3.transform.position;
        		player.transform.rotation = spawn3.transform.rotation;
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

        if(x1 <= fin2.transform.position.x && x2 >= fin2.transform.position.x && z1 <= fin2.transform.position.z && z2 >= fin2.transform.position.z){
        	player.transform.position = spawn3.transform.position;
        	player.transform.rotation = spawn3.transform.rotation;
        	numNiveau++;
        }

    }
}
