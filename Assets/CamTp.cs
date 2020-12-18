using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamTp : MonoBehaviour
{

    GameObject Cam;
    Transform Pos;

    // Start is called before the first frame update
    void Start()
    {
        Cam = GameObject.Find("CamParent");
        Pos = gameObject.transform.Find("CamPos");
    }

    void OnTriggerEnter(Collider other)
    {           //	OnCollisionEnter
        Cam.transform.position = Pos.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
