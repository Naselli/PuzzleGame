using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ExtensionMethods
{
    public static Vector3 GetLookDirection( Vector3 v ) => new Vector3(v.x, 0 , v.z);
}
