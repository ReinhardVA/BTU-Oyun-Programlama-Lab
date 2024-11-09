using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;
    public float health = 50f;
    public GameObject pObject;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //Vector3.Distance(transform.position, player.transform.position);
    }

    public void TakeDamage(float amount, RaycastHit hit){
        health -= amount;
        GameObject impactGO = Instantiate(pObject, hit.transform.position, Quaternion.LookRotation(hit.normal));
        if(health <=0){
            Destroy(gameObject);
        } 
        Destroy(impactGO, 2f);
    }
}
