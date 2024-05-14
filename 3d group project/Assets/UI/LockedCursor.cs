using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedCursor : MonoBehaviour
{
    public bool isCursorLocked = false;

    void Update()
    {
        //Cursor key toggle
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = isCursorLocked ? CursorLockMode.Locked : CursorLockMode.None;
            Cursor.visible = !isCursorLocked;
        }
    }
}
