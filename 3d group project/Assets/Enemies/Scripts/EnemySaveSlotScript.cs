using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySaveSlotScript : MonoBehaviour
{
    public bool sSAEmy1 = false;
    public bool sSAEmy2 = false;
    public bool sSAEmy3 = false;
    public bool sSAEmy4 = false;

    bool activeTime;
    float timer;
    private void Update()
    {
        timer += Time.deltaTime;
        if(sSAEmy1 && activeTime! || sSAEmy2 && activeTime! || sSAEmy3 && activeTime! || sSAEmy4 && activeTime!)
        {
            timer = 0;
            activeTime = true;
        }
        if(activeTime && timer >= .5f)
        {
            if (sSAEmy1)
            {
                sSAEmy1 = false;
                activeTime = false;
            }
            else if (sSAEmy2)
            {
                sSAEmy2 = false;
                activeTime = false;
            }
            else if (sSAEmy3)
            {
                sSAEmy3 = false;
                activeTime = false;
            }
            else if (sSAEmy4)
            {
                sSAEmy4 = false;
                activeTime = false;
            }
        }
    }
}
