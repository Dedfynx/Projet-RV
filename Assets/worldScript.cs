using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class worldScript : MonoBehaviour
{
    GameObject canvasObj;
    Transform child;
    Text timerText;

    //
    GameObject player;
    GameObject spawn;
    GameObject portail;
    public Animator anim;
    public GameObject prefab;

    double ecart = 1.0;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        canvasObj = GameObject.Find("Canvas");
        child = canvasObj.transform.Find("timer");
        //timer
        timerText = child.GetComponent<Text>();
        StartCoroutine(TimerTick());

        //Teleportation
        player = GameObject.FindWithTag("Player");
        spawn = GameObject.Find("SpawnPoint");

        StartCoroutine(Fading());

        portail = GameObject.Find("Canvas3D");

        /*
        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
        */
    }

    // Update is called once per frame
    void Update()
    {
        /*
        Debug.Log("Player : " + player.transform.position.x);
        Debug.Log("Portail : " + portail.transform.position.x);
        *
        */
        double pos1 = player.transform.position.x - ecart;//je verifie que le position x pour l'instant
        double pos2 = player.transform.position.x + ecart;
        if (pos1 <= portail.transform.position.x && pos2 >= portail.transform.position.x)
        {
            //Debug.Log("Yes");
            SceneManager.LoadScene("SceneLab");
        }
    }

    IEnumerator TimerTick()
    {
        while (GameVariable.currentTime > 0)
        {// attendre une seconde
            yield return new WaitForSeconds(1);
            GameVariable.currentTime--;
            timerText.text = "Time :" + GameVariable.currentTime.ToString();
        }
        // game over
        //SceneManager.LoadScene("Scene");
    }

    IEnumerator Fading() {
        anim.SetBool("Fade", true); 
        yield return new WaitForSeconds(1);
        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
        Vector3 randomPos = new Vector3(445, 0, 350);
        GameObject statue = Instantiate(prefab, randomPos, Quaternion.identity);
        anim.SetBool("Fade", false);
        //Debug.Log("Test");
    }

}
