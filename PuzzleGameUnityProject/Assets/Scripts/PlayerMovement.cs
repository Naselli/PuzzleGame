using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private int   nextLevel;
    [SerializeField]
    private Rigidbody rB;
    private Camera  _camera;
    private Vector3 lookDir;
    private bool    jump;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    { 
        lookDir = Vector3.zero;

        if ( Input.GetKeyDown( KeyCode.Space ) )
            jump = true;
        
        if (Input.GetKey(KeyCode.W))
            lookDir += ExtensionMethods.GetLookDirection(_camera.transform.forward);

        if (Input.GetKey(KeyCode.S))
            lookDir += ExtensionMethods.GetLookDirection(-_camera.transform.forward);
        
        if (Input.GetKey(KeyCode.A))
            lookDir += ExtensionMethods.GetLookDirection(-_camera.transform.right);
        
        if (Input.GetKey(KeyCode.D))
            lookDir += ExtensionMethods.GetLookDirection(_camera.transform.right);

        //if (Input.GetKeyDown(KeyCode.LeftShift))
        //    speed *= 2;
        //if (Input.GetKeyUp(KeyCode.LeftShift))
        //    speed /= 2;

        
    }

    private void FixedUpdate( ) {
        if ( jump ) {
            GetComponent<Rigidbody>().AddForce(Vector3.up * 1f , ForceMode.Impulse);
            jump = false;
        }
        rB.transform.Translate( lookDir * (speed * Time.deltaTime), Space.Self);
    }

    private void OnTriggerEnter( Collider other ) {
        if ( other.gameObject.tag == "endLevel" ) {
            SceneManager.LoadScene( nextLevel );
        }
    }
}

