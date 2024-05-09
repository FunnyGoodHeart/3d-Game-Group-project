using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinappleInteracr : MonoBehaviour
{
    public bool pineRecharging;
    [SerializeField] int healAmmount;
    [SerializeField] GameObject pinappleBaseGO;
    [SerializeField] GameObject pinapppleLeafsGO;

    MeshRenderer pinappleBase;
    MeshRenderer pinappleLeaf;
    void Start()
    {
        pinappleBase = pinappleBaseGO.GetComponent<MeshRenderer>();
        pinappleLeaf = pinapppleLeafsGO.GetComponent<MeshRenderer>();
    }

    void Update()
    {
        
    }
}
