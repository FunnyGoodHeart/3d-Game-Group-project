using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InPlayerRange : MonoBehaviour
{
    public bool playerIsInRange = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsInRange = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            playerIsInRange = false;
        }
    }
}
