using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    public GameObject sparkEffect;
    void OnCollisionEnter(Collision coll) {
         if (coll.collider.CompareTag("BULLET")) {

            Instantiate(sparkEffect, coll.transform.position, Quaternion.identity);

            Destroy(coll.gameObject);
         }       
    }
}
