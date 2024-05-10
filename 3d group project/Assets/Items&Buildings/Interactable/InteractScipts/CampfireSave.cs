using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CampfireSave : MonoBehaviour
{
    private static string keyWord = "123456789";
    public bool CampSaveActivate = false;
    public int EmeraldCountNumber = 0000;
    [SerializeField] Canvas saveMenu;
    void Start()
    {
        saveMenu.enabled = false;
    }

    void Update()
    {
        if (CampSaveActivate)
        {
            saveMenu.enabled = true;
        }
    }
    public void SaveSlot1()
    {

    }
}

public class SavedData
{
    public int plyHealthSV; //player stats
    public int plyAmmoSV;
    public int plyEmeraldSV;
    public int plyEmCollectSV;

    public float PlyLocationX; //player location
    public float PlyLocationY;
    public float PlyLocationZ;


}