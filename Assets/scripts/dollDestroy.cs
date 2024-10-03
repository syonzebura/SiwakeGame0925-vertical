using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dollDestroy : MonoBehaviour
{
    

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject head=gameObject.transform.Find("Rig/B-root/B-hips").gameObject;
        if (head.transform.position.y < -10)
        {
            Destroy(this.gameObject);
        }
        
    }
    
    

}
