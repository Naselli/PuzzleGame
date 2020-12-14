using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float speed;
    private Camera _camera;

    private void Start()
    {
        _camera = Camera.main;
    }

    void Update()
    {
        Vector3 lookDir = Vector3.zero;
        
        if (Input.GetKey(KeyCode.W))
            lookDir += ExtensionMethods.GetLookDirection(_camera.transform.forward);

        if (Input.GetKey(KeyCode.S))
            lookDir += ExtensionMethods.GetLookDirection(-_camera.transform.forward);
        
        if (Input.GetKey(KeyCode.A))
            lookDir += ExtensionMethods.GetLookDirection(-_camera.transform.right);
        
        if (Input.GetKey(KeyCode.D))
            lookDir += ExtensionMethods.GetLookDirection(_camera.transform.right);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            speed *= 2;
        if (Input.GetKeyUp(KeyCode.LeftShift))
            speed /= 2;

        
        
        //transform.position += dir.normalized * (speed * Time.deltaTime);
        transform.Translate( lookDir * (speed * Time.deltaTime), Space.Self);
    }
}
