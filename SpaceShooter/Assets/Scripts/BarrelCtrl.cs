using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelCtrl : MonoBehaviour
{
    public GameObject expEffect;

    private Transform tr;
    private Rigidbody rb;

    private int hitCount = 0;

    void Start()
    {
        tr = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision coll) {
        if (coll.collider.CompareTag("BULLET")) {
            if (++hitCount == 3) {
                ExpBarrel();
            }
        }
    }

    void ExpBarrel() {
        GameObject exp = Instantiate(expEffect, tr.position, Quaternion.identity);
        Destroy(exp, 0.5f);

        rb.mass = 1.0f;
        rb.AddForce(Vector3.up * 1500.0f);

        Destroy(gameObject, 3.0f);
    }
}
