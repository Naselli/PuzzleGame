using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    // Start is called before the first frame update
    void Start( ) {
        ExtensionMethods.CreateDimensionMap( );
    }

    private void OnDrawGizmos( ) {
        for ( int i = 0 ; i < 10 ; i++ )
        for ( int j = 0 ; j < 10 ; j++ )
        for ( int k = 0 ; k < 10 ; k++ ) {
            Gizmos.color = new Color( 0.73f , 0.71f , 0.75f , 0.15f );
            Gizmos.DrawWireSphere( transform.position + ExtensionMethods.MapArray3D [ i , j , k ] , .05f );
        }
        
        for ( int i = 0 ; i < 10 ; i++ )
        for ( int j = 0 ; j < 10 ; j++ )
        for ( int k = 0 ; k < 10 ; k++ ) {
            Gizmos.color = new Color( 0.73f , 0.71f , 0.75f , 0.15f );
            Gizmos.DrawWireSphere( transform.position + new Vector3(10,0,0) + ExtensionMethods.MapArray3D [ + i , j , k ] , .05f );
        }
    }
}
