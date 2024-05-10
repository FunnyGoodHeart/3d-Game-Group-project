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
    [SerializeField] GameObject emySSGO;
    [SerializeField] GameObject player;
    PlayerBowShoot plyBoSh;
    PlayerHealth plyHelth;
    EnemySaveSlotScript emySS;
    void Start()
    {
        saveMenu.enabled = false;
        emySS = emySSGO.GetComponent<EnemySaveSlotScript>();
        plyHelth = player.GetComponent<PlayerHealth>();
        plyBoSh = player.GetComponent<PlayerBowShoot>();
    }

    void Update()
    {
        if (CampSaveActivate)
        {
            saveMenu.enabled = true;
        }
    }
    public string EncryptDecryptData(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ keyWord[i % keyWord.Length]);
        }


        return result;
    }
    public void SaveSlot1()
    {
        emySS.sSAEmy1 = true;
        PlayerSavedData myData = new PlayerSavedData();
        myData.PlyLocationX = transform.position.x;
        myData.PlyLocationY = transform.position.y;
        myData.PlyLocationZ = transform.position.z;
        myData.plyHealthSV = plyHelth.playerHP;
        myData.plyAmmoSV = plyBoSh.bulletCount;
        myData.plyEmeraldSV = plyHelth.emeraldCount;
        myData.plyEmCollectSV = EmeraldCountNumber;
        string myDataString = JsonUtility.ToJson(myData);
        //Debug.Log(Application.persistentDataPath);
        string file = Application.persistentDataPath + "/" + gameObject.name + "SaveSlot1" +".jaon"; // between / & gameobject.name put saveState
        myDataString = EncryptDecryptData(myDataString);
        System.IO.File.WriteAllText(file, myDataString);
        Debug.Log("Saving");
    }
}

public class PlayerSavedData
{
    public int plyHealthSV; //player stats
    public int plyAmmoSV;
    public int plyEmeraldSV;
    public int plyEmCollectSV;

    public float PlyLocationX; //player location
    public float PlyLocationY;
    public float PlyLocationZ;


}