using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class CampfireSave : MonoBehaviour
{
    private static string keyWord = "7555299933777";
    public bool CampSaveActivate = false;
    public int EmeraldCountNumber = 0000;
    [SerializeField] Canvas saveMenu;
    [SerializeField] Canvas loadMenu;
    [SerializeField] Canvas saveOrLoad;
    [SerializeField] GameObject emySSGO;
    [SerializeField] GameObject player;
    PlayerBowShoot plyBoSh;
    PlayerHealth plyHelth;
    EnemySaveSlotScript emySS;
    void Start()
    {
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
    public void SavingAData()
    {
        saveOrLoad.enabled = false;
        saveMenu.enabled = true;
    }
    public void LoadingAData()
    {
        saveOrLoad.enabled = false;
        loadMenu.enabled = true;
    }
    public void SaveSlot1()
    {
        SavingData("SaveSlot1");
    }
    public void SaveSlot2()
    {
        SavingData("SaveSlot2");
    }
    public void SaveSlot3()
    {
        SavingData("SaveSlot3");
    }
    public void SaveSlot4()
    {
        SavingData("SaveSlot4");
    }
    public void SavingData(string SaveSlotName)
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
        string file = Application.persistentDataPath + "/" + gameObject.name + SaveSlotName + ".jaon"; // between / & gameobject.name put saveState
        myDataString = EncryptDecryptData(myDataString);
        System.IO.File.WriteAllText(file, myDataString);
        saveMenu.enabled = false;
        Debug.Log("Saving");
    }
    public void LoadSlot1()
    {
        LoadingData("SaveSlot1");
    }
    public void LoadSlot2()
    {
        LoadingData("SaveSlot2");
    }
    public void LoadSlot3()
    {
        LoadingData("SaveSlot3");
    }
    public void LoadSlot4()
    {
        LoadingData("SaveSlot4");
    }
    public void LoadingData(string SaveSlotName)
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + SaveSlotName + ".jaon";
        if (File.Exists(file))
        {
            var jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            PlayerSavedData myData = JsonUtility.FromJson<PlayerSavedData>(jsonData);
            transform.position = new Vector3(myData.PlyLocationX, myData.PlyLocationY, myData.PlyLocationZ);
            plyHelth.playerHP = myData.plyHealthSV;
            plyBoSh.bulletCount = myData.plyAmmoSV;
            plyHelth.emeraldCount = myData.plyEmeraldSV;
            EmeraldCountNumber = myData.plyEmCollectSV;
            loadMenu.enabled = true;
        }
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