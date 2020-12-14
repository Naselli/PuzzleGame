using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;

public class ClonedObject : MonoBehaviour
{
    [SerializeField] private bool gravityReversed = false;
    [SerializeField] private bool cloned = false;
    private Rigidbody rB;

    private void Start()
    {
        rB = GetComponent<Rigidbody>();
    }

    public void FixedUpdate() {
        if (gravityReversed && !cloned) {
            rB.AddForce(-Vector3.up * Physics.gravity.magnitude);
        } 
        else if (!cloned) {
            rB.AddForce(-Vector3.forward * Physics.gravity.magnitude);
        }
        
        if (gravityReversed && cloned) {
            rB.AddForce(-Vector3.up * Physics.gravity.magnitude);
        } 
        else if (cloned){
            rB.AddForce(Vector3.forward * Physics.gravity.magnitude);
        }
    }


    public void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            gravityReversed = !gravityReversed;
        }
    }
}
