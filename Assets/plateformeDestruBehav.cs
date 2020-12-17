using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateformeDestruBehav : MonoBehaviour
{
    public GameObject plateforme;
    public int duree;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(duree <= 0){
            Destroy(plateforme);
        }
        else{
            duree--;
        }
    }
}
