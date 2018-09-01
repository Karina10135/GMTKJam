using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetControl : MonoBehaviour
{
    public GameObject target;
    public float radius;
    public float force;

    Rigidbody2D rb;

    public KeyCode pushButton;
    public KeyCode pullButton;

    private void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(pushButton))
        {
            ExplosivePushExample();
        }
    }

    public void Push()
    {

    }

    public void ExplosivePushExample()
    {
        Vector3 explosionPos = transform.position;
        Collider[] colliders = Physics.OverlapSphere(explosionPos, radius);
        foreach (Collider hit in colliders)
        {
            Rigidbody rb = hit.GetComponent<Rigidbody>();

            if (rb != null)
                rb.AddExplosionForce(force, explosionPos, radius, 3.0F);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, radius);
    }


}
