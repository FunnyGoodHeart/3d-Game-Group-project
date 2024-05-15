using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InBossArena : MonoBehaviour
{
    public bool inTheBossArea = false;
    bool justEntered = false;
    [SerializeField] GameObject doorBlock;
    MeshRenderer dBMesh;
    MeshCollider dBColli;
    private void Start()
    {
        dBMesh = doorBlock.GetComponent<MeshRenderer>();
        dBColli = doorBlock.GetComponent<MeshCollider>();
        dBMesh.enabled = false;
        dBColli.enabled = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            inTheBossArea = true;
            if (justEntered == false)
            {
                dBMesh.enabled = true;
                dBColli.enabled = true;
                justEntered = true;
            }
        }
    }
}
