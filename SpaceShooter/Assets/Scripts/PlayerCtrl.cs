using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    public float moveSpeed = 10f;
    public float turnSpeed = 80f;
    void Start()
    {
        tr = GetComponent<Transform>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward* v) + (Vector3.right) * h;

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
    }
}
