using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
