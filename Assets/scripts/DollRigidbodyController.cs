using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DollRigidbodyController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //doll内の全rigidboyの当たり判定にアクセスする
        Rigidbody[] rigidbodies = GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rb in rigidbodies)
        {
            //Debug.Log("a");
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
