using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class labScript : MonoBehaviour
{
    GameObject canvasObj;
    Transform child;
    Text timerText;
    GameObject player;
    GameObject spawn;
    GameObject portail;
    public Animator anim;
    public GameObject prefab;
    public GameObject endScreen;

    double ecart = 1.0;

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        endScreen.SetActive(false);

        canvasObj = GameObject.Find("Canvas");
        child = canvasObj.transform.Find("timer");
        //timer
        timerText = child.GetComponent<Text>();
        StartCoroutine(TimerTick());

        //Teleportation
        player = GameObject.FindWithTag("Player");
        spawn = GameObject.Find("SpawnPoint");

        portail = GameObject.Find("PortailFin");

        StartCoroutine(Fading());
    }

    // Update is called once per frame
    void Update()
    {
        double posX1 = player.transform.position.x - ecart;//je verifie que le position x pour l'instant
        double posX2 = player.transform.position.x + ecart;
        double posZ1 = player.transform.position.z - ecart;//je verifie que le position x pour l'instant
        double posZ2 = player.transform.position.z + ecart;
        if (posX1 <= portail.transform.position.x && posX2 >= portail.transform.position.x &&
            posZ1 <= portail.transform.position.z && posZ2 >= portail.transform.position.z)
        {
            //Debug.Log("Yes");
            Time.timeScale = 0;
            endScreen.SetActive(true);
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
    IEnumerator Fading()
    {
        anim.SetBool("Fade", true);
        yield return new WaitForSeconds(1);
        player.transform.position = spawn.transform.position;
        player.transform.rotation = spawn.transform.rotation;
        Vector3 randomPos = new Vector3(445, 0, 350);
        GameObject statue = Instantiate(prefab, randomPos, Quaternion.identity);
        anim.SetBool("Fade", false);
        //Debug.Log("Test");
    }

    public void endGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }

    public void restart()
    {
        Debug.Log("Restart");
        SceneManager.LoadScene("Scene");
    }

    void OnTriggerEnter(Collider other) 
    { 
        Time.timeScale = 0; 
        endScreen.SetActive(true);
    }
}
