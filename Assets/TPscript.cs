using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TPscript : MonoBehaviour
{
	GameObject player;
    GameObject spawn;
    public GameObject cam;
    GameObject spawncam;

    GameObject canvasObj;
    Transform child;
    Text hudText;
    int nbEssai;


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
        spawn = GameObject.Find("SpawnPoint");
        //cam = GameObject.Find("Main Camera");
        spawncam = GameObject.Find("SpawnCam");

        cam.transform.position = spawncam.transform.position;

        canvasObj = GameObject.Find("Canvas");
        child = canvasObj.transform.Find("HUD");
        hudText = child.GetComponent<Text>();
        nbEssai = 1;
        hudText.text = "Nombre Essais : " + nbEssai;
    }

    // Update is called once per frame
    void Update()
    {

        if(player.transform.position.y < -15){
        	player.transform.position = spawn.transform.position;
        	player.transform.rotation = spawn.transform.rotation;
        	cam.transform.position = spawncam.transform.position;
            nbEssai++;
            hudText.text = "Nombre Essais : " + nbEssai;
        }

    }


   	void OnTriggerStay(Collider other){
        if(other.gameObject.tag == "MovingPlatform"){
             transform.parent = other.transform;
 
        }
    }
 
 	void OnTriggerExit(Collider other){
     	if(other.gameObject.tag == "MovingPlatform"){
             transform.parent = null;    
        }
    } 
}
