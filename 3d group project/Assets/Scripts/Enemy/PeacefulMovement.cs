using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeacefulMovement : MonoBehaviour
{
    [SerializeField] float minRandomTimer = 5;
    [SerializeField] float maxRandomTimer = 15;
    bool flying = false;
    bool walking = true;
    bool landing = false;
    float timer;
    void Start()
    {
        timer = Random.Range(minRandomTimer, maxRandomTimer);
    }
    void Update()
    {
        
    }
}
