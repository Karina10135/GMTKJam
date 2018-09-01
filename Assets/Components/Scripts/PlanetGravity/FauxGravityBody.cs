using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityBody : MonoBehaviour
{
    public FauxGravityAttractor attractor;

    Transform myTransform;
    Rigidbody rb;

    void Start()
    {
        myTransform = gameObject.transform;
        rb = GetComponent<Rigidbody>();
        //rb.constraints = RigidbodyConstraints.FreezeRotation;
        rb.useGravity = false;
    }

    void Update()
    {
        attractor.Attract(myTransform);
    }
}
