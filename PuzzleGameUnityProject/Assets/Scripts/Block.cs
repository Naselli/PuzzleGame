using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public enum Type {
        Normal
      , Fixed
    }
    
    [SerializeField] private int        x , y , z;
    [SerializeField] private Type       blockType;
    private                  bool       switched = false;
    private                  int        max      = 10;
    [SerializeField] private GameObject clonedObject;
    private                  Vector3    previousPos;
    
    
    void Start()
    {
        x = Mathf.Clamp( x , 0 , 9 );
        y = Mathf.Clamp( y , 0 , 9 );
        z = Mathf.Clamp( z , 0 , 9 );
        clonedObject.transform.position = ExtensionMethods.ClonedRoomOffset + ExtensionMethods.MapArray3D [ y , ( max - 1 ) - x , z ];
        transform.position =  ExtensionMethods.MapArray3D [ x , y , z ];
    }

    // Update is called once per frame
    void Update() {
        
        if ( blockType == Type.Fixed) {
            clonedObject.transform.position =  ExtensionMethods.ClonedRoomOffset + ExtensionMethods.MapArray3D [  y , ( max - 1 ) - x , z ];
            transform.position = ExtensionMethods.MapArray3D [ x , y , z ];
            return;
        }
        if ( !switched ) 
            y--;
        else 
            x--;
        
        x = Mathf.Clamp( x , 0 , 9 );
        y = Mathf.Clamp( y , 0 , 9 );
        z = Mathf.Clamp( z , 0 , 9 );

        GameObject[] blocks     = GameObject.FindGameObjectsWithTag( "Block" );
        bool         foundBlock = false;
        foreach ( var b in blocks ) {
            if ( Vector3.Distance(ExtensionMethods.MapArray3D[x,y,z], b.transform.position)  == 0 ) {
                foundBlock = true;
            }
        }
        
        if ( !switched && previousPos != ExtensionMethods.MapArray3D [ x , y , z ]) {
            if (foundBlock) 
                y++;
        }
        else if ( previousPos != ExtensionMethods.MapArray3D [ x , y , z ] ){
            if (foundBlock) 
                x++;
        }
        
        clonedObject.transform.position =  ExtensionMethods.ClonedRoomOffset + ExtensionMethods.MapArray3D [  y , ( max - 1 ) - x , z ];
        transform.position = ExtensionMethods.MapArray3D [ x , y , z ];

        if ( Input.GetKeyDown( KeyCode.Space ) )
            switched = !switched;

        previousPos = ExtensionMethods.MapArray3D [ x , y , z ];
    }

    private void OnDrawGizmos( ) {
        
        if ( blockType == Type.Normal ) {
            Gizmos.color = new Color( 0.29f , 0.08f , 1f );
            Gizmos.DrawWireCube( transform.position , Vector3.one );
            Gizmos.color = new Color( 0f , 0.79f , 1f );
            Gizmos.DrawWireCube( clonedObject.transform.position , Vector3.one );
        }
            

        if ( blockType == Type.Fixed ) {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube( transform.position, Vector3.one );
            Gizmos.DrawWireCube(clonedObject.transform.position, Vector3.one);
        }
    }
}
