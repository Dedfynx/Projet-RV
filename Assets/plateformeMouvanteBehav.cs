using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plateformeMouvanteBehav : MonoBehaviour
{
    public int nbFrames;
    int y;
    bool aller;
    public Vector3 direction;
    public float vit;
    // Start is called before the first frame update
    void Start()
    {
        y =0;
        aller = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(nbFrames > y){
            y++;
            if(aller){
                transform.Translate(direction.x * vit,direction.y * vit,direction.z * vit);
            }
            else{
                transform.Translate(-direction.x * vit,-direction.y * vit,-direction.z * vit);
            }
            
        }
        else{
            y = 0;
        }
    }
}
