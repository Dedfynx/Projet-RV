using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAttach : MonoBehaviour
{
    GameObject Player;
    GameObject emptyObject;

    void Start()
    {
        Player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Player)
        {
            emptyObject = new GameObject();
            emptyObject.transform.parent = transform;
            Player.transform.parent = emptyObject.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject == Player)
        {
            Player.transform.parent = null;
            Destroy(emptyObject);
        }
    }
}
