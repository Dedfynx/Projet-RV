using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextLvl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    void OnTriggerEnter(Collider other)
    {           //	OnCollisionEnter
        Data.nbNiveau++;
        SceneManager.LoadScene("Level" + Data.nbNiveau);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
