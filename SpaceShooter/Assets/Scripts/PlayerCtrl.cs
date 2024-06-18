using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    private Transform tr;
    private Animation anim;

    public float moveSpeed = 10f;
    public float turnSpeed = 80f;
    
    private readonly float initHP = 100.0f;
    public float currHP;
    
    IEnumerator Start()
    {
        currHP = initHP;

        tr = GetComponent<Transform>();
        anim = GetComponent<Animation>();

        anim.Play("Idle");

        turnSpeed = 0.0f;
        yield return new WaitForSeconds(0.3f);
        turnSpeed = 80.0f;
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float r = Input.GetAxis("Mouse X");

        Vector3 moveDir = (Vector3.forward* v) + (Vector3.right) * h;

        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        tr.Rotate(Vector3.up * turnSpeed * Time.deltaTime * r);
    
        PlayerAnim(h, v);
    }

    void PlayerAnim(float h, float v) {
        if (v >= 0.1f) {
            anim.CrossFade("RunF", 0.25f);
        }
        else if (v <= -0.1f) {
            anim.CrossFade("RunB", 0.25f);
        }
        else if (h >= 0.1f) {
            anim.CrossFade("RunR", 0.25f);
        }
        else if (h <= -0.1f) {
            anim.CrossFade("RunL", 0.25f);
        }
        else {
            anim.CrossFade("Idle", 0.25f);
        }
    }
    
    void OnTriggerEnter(Collider coll) {
        if (currHP >= 0.0f && coll.CompareTag("PUNCH")) {
            currHP -= 10.0f;
            Debug.Log($"Plater hp = {currHP/initHP}");

            if (currHP < 0.0f) {
                PlayerDie();
            }
        }
    }

    void PlayerDie() {
        Debug.Log("Player Die !");
    }
}
