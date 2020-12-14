using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamRotation : MonoBehaviour
{
    [SerializeField] private float speed;
    float pitch;
    float yaw;

    void Start()
    {

    }

    void Update()
    {
        pitch += speed * -Input.GetAxis("Mouse Y");
        yaw += speed * Input.GetAxis("Mouse X");

        pitch = Mathf.Clamp(pitch, -90f, 90f);

        while (yaw < 0f)
        {
            yaw += 360f;
        }

        while (yaw >= 360f)
        {
            yaw -= 360f;
        }

        transform.eulerAngles = new Vector3(pitch, yaw, 0f);
    }
}
