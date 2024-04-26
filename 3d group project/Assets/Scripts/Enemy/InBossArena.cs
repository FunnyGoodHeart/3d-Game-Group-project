using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InBossArena : MonoBehaviour
{
    public bool inTheBossArea = false;
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inTheBossArea = true;
        }
    }
}
