using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransition : MonoBehaviour {
    [SerializeField] private GameObject screen;
    private                  bool       isWorking = false;
    private float alpha = 1f;

    private void Start( ) {
        StartCoroutine( ( DoAfterTime( 1f ) ) );
    }

    private void Update( ) {
        if ( isWorking && alpha > 0f ) {
            screen.GetComponent< Renderer >( ).material.color = new Color( 0.93f , 0.94f , 0.95f , alpha);
            //screen.GetComponent< Renderer >( ).material.SetColor("_EmissionColor", Color.blue);
            alpha -= 0.001f;
        }

    }
    IEnumerator DoAfterTime(float time) {
        yield return new WaitForSeconds(time);
        isWorking = true;
    }
}
