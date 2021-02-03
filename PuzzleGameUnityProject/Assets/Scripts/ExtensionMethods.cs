using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    private static Vector3[ , , ] mapArray3D       = new Vector3[ 10 , 10 , 10 ];
    private static Vector3        clonedRoomOffset = new Vector3( 11 , 0 , 0 );
    public static  Vector3        GetLookDirection( Vector3 v ) => new Vector3(v.x, 0 , v.z);
    public static  Vector3[ , , ] MapArray3D                    => mapArray3D;
    public static  Vector3        ClonedRoomOffset              => clonedRoomOffset;

    public static void CreateDimensionMap( ) {
        for ( int i = 0 ; i < 10 ; i++ )
        for ( int j = 0 ; j < 10 ; j++ )
        for ( int k = 0 ; k < 10 ; k++ )
            mapArray3D [ i , j , k ] = new Vector3( i , j , k );
    }




}
