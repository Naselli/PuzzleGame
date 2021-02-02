using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum Type {
        Normal
      , Cloned
    }
    
    [SerializeField] private int        x , y , z;
    //[SerializeField] private Type       blockDimension;
    private                  bool       switched = false;
    private                  int        max      = 10;
    [SerializeField] private GameObject clonedObject;
    
    
    void Start()
    {
        x = Mathf.Clamp( x , 0 , 9 );
        y = Mathf.Clamp( y , 0 , 9 );
        z = Mathf.Clamp( z , 0 , 9 );
        clonedObject.transform.position = new Vector3(10,0,0) + ExtensionMethods.MapArray3D [ y , ( max - 1 ) - x , z ];
        transform.position =  ExtensionMethods.MapArray3D [ x , y , z ];
    }

    // Update is called once per frame
    void Update() {

        if ( !switched ) 
            y--;
        else 
            x--;
        
        x = Mathf.Clamp( x , 0 , 9 );
        y = Mathf.Clamp( y , 0 , 9 );
        z = Mathf.Clamp( z , 0 , 9 );
        
        clonedObject.transform.position =  new Vector3(10,0,0) + ExtensionMethods.MapArray3D [  y , ( max - 1 ) - x , z ];
        transform.position = ExtensionMethods.MapArray3D [ x , y , z ];

        if ( Input.GetKeyDown( KeyCode.Space ) )
            switched = !switched;
    }

    private void OnDrawGizmos( ) {

            Gizmos.color = new Color( 0.29f , 0.08f , 1f );
            Gizmos.DrawWireCube( transform.position , Vector3.one );
            Gizmos.color = new Color( 0f , 0.79f , 1f );
            Gizmos.DrawWireCube( clonedObject.transform.position , Vector3.one );
    }
}
