using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonPickup : MonoBehaviour
{
   [SerializeField] private GameObject anchor;
   [SerializeField] private LayerMask layer;
   private bool isHolding;
   private GameObject itemHolding;
   

   private void Update()
   {

      if ( Input.GetKeyDown( KeyCode.Space ) ) {
         GetComponent<Rigidbody>().AddForce(Vector3.up * 3.5f , ForceMode.Impulse);
      }

      if (Input.GetKeyDown(KeyCode.E) && !isHolding )
      {
         isHolding = true;
         RaycastHit hit;
         if (Physics.Raycast(transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, layer))
         {
            itemHolding = hit.collider.gameObject;
            itemHolding.transform.SetParent(anchor.transform);
            itemHolding.transform.localPosition = Vector3.zero;
            itemHolding.GetComponent<Rigidbody>().useGravity = false;
         }
      }
      if (Input.GetKeyDown(KeyCode.Q) && isHolding)
      {
         isHolding = false;
         itemHolding.transform.parent = null;
      }
      
   }
}
