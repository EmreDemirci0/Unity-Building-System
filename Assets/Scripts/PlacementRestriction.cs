using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(Collider))]
public class PlacementRestriction : MonoBehaviour
{
    private void Start()
    {

    }
    private void OnTriggerStay/*Enter*/(Collider other)
    {
        //CantPlaced
        if (other.gameObject.CompareTag("CantPlaced"))
        {
            if (BuildingSystem.Instance)
            {
                BuildingSystem.Instance.isPlacementRestriction = false;

            }
            
        }


    }
    private void OnTriggerExit(Collider other)
    {
        //CantPlaced
        if (other.gameObject.CompareTag("CantPlaced"))
        {
            if (BuildingSystem.Instance)
            {
                BuildingSystem.Instance.isPlacementRestriction = true;

            }
            

        }

    }
}
