using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinBehaviour : MonoBehaviour
{
    public GameObject fx; 
    GameObject worldObject; 
    GameObject audioObject; 
    AudioSource aud;
    // Start is called before the first frame update
    void Start()
    {
        //worldObject = GameObject.Find("World");
        audioObject = GameObject.Find("Audio");// votre GameObject contenant l’Audio 
        aud = audioObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(45, 0, 30) * Time.deltaTime);
        //worldObject.SendMessage("AddCoin"); 
        if (aud) { 
            aud.Play(); 
        }
        Instantiate(fx, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}

