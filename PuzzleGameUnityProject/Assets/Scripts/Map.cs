using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 [ExecuteAlways] public class Map : MonoBehaviour {
    public enum Type {
        Normal
      , Cloned
    }

    private                  Vector3[ , , ] _mapArray3D = new Vector3[ 10 , 10 , 10 ];
    private                  int            x  , y , z;
    private                  int            max = 10;
    private                  Vector3        _item;
    [SerializeField] private Type           typeOfRoom;


    void Start( ) {
        for ( int i = 0 ; i < 10 ; i++ )
        for ( int j = 0 ; j < 10 ; j++ )
        for ( int k = 0 ; k < 10 ; k++ )
            _mapArray3D [ i , j , k ] = new Vector3( i , j , k );

        _item = new Vector3( x , y , z );
    }

    void Update( ) {
       
        if ( Input.GetKeyDown( KeyCode.W ) )
            z++;
        if ( Input.GetKeyDown( KeyCode.S ) )
            z--;
        if ( Input.GetKeyDown( KeyCode.A ) )
            x--;
        if ( Input.GetKeyDown( KeyCode.D ) )
            x++;
        if ( Input.GetKeyDown( KeyCode.LeftShift ) )
            y++;
        if ( Input.GetKeyDown( KeyCode.LeftControl ) )
            y--;


        x = Mathf.Clamp( x , 0 , 9 );
        y = Mathf.Clamp( y , 0 , 9 );
        z = Mathf.Clamp( z , 0 , 9 );

        if ( typeOfRoom == Type.Cloned ) {
            _item = transform.position + _mapArray3D [ y , ( max - 1 ) - x , z ];
        }
        else {
            _item = transform.position + _mapArray3D [ x , y , z ];
        }
    }

    private void OnDrawGizmos( ) {
        if ( typeOfRoom == Type.Cloned ) {
            Gizmos.color = new Color( 1f , 0f , 0f );
        }
        else {
            Gizmos.color = Color.green;
        }

        Gizmos.DrawWireCube( _item , Vector3.one );

        for ( int i = 0 ; i < 10 ; i++ )
        for ( int j = 0 ; j < 10 ; j++ )
        for ( int k = 0 ; k < 10 ; k++ ) {
            Gizmos.color = new Color( 0.73f , 0.71f , 0.75f , 0.15f );
            Gizmos.DrawWireSphere( transform.position + _mapArray3D [ i , j , k ] , .05f );
        }
    }
 }