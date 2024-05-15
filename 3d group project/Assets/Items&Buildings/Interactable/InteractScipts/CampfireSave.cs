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
    [SerializeField] GameObject bow;
    [SerializeField] GameObject pauseMenu;
    PauseMenu PM;
    PlayerBowShoot plyBoSh;
    PlayerHealth plyHelth;
    EnemySaveSlotScript emySS;
    void Start()
    {
        PM = pauseMenu.GetComponent<PauseMenu>();
        saveMenu.enabled = false;
        loadMenu.enabled = false;
        saveOrLoad.enabled = false;
        emySS = emySSGO.GetComponent<EnemySaveSlotScript>();
        plyHelth = player.GetComponent<PlayerHealth>();
        plyBoSh = bow.GetComponent<PlayerBowShoot>();
    }

    void Update()
    {
        if (CampSaveActivate)
        {
            PM.CursorChange();
            CampSaveActivate = false;
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
        Debug.Log(Application.persistentDataPath);
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS1" + ".jaon";
        myDataString = EncryptDecryptData(myDataString);
        System.IO.File.WriteAllText(file, myDataString);
        saveMenu.enabled = false;
        PM.CursorChange();
        Debug.Log("Saving");
    }
    public void SaveSlot2()
    {
        emySS.sSAEmy2 = true;
        PlayerSavedData myData = new PlayerSavedData();
        myData.PlyLocationX = transform.position.x;
        myData.PlyLocationY = transform.position.y;
        myData.PlyLocationZ = transform.position.z;
        myData.plyHealthSV = plyHelth.playerHP;
        myData.plyAmmoSV = plyBoSh.bulletCount;
        myData.plyEmeraldSV = plyHelth.emeraldCount;
        myData.plyEmCollectSV = EmeraldCountNumber;
        string myDataString = JsonUtility.ToJson(myData);
        Debug.Log(Application.persistentDataPath);
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS2" + ".jaon";
        myDataString = EncryptDecryptData(myDataString);
        System.IO.File.WriteAllText(file, myDataString);
        saveMenu.enabled = false;
        PM.CursorChange();
        Debug.Log("Saving");
    }
    public void SaveSlot3()
    {
        emySS.sSAEmy3 = true;
        PlayerSavedData myData = new PlayerSavedData();
        myData.PlyLocationX = transform.position.x;
        myData.PlyLocationY = transform.position.y;
        myData.PlyLocationZ = transform.position.z;
        myData.plyHealthSV = plyHelth.playerHP;
        myData.plyAmmoSV = plyBoSh.bulletCount;
        myData.plyEmeraldSV = plyHelth.emeraldCount;
        myData.plyEmCollectSV = EmeraldCountNumber;
        string myDataString = JsonUtility.ToJson(myData);
        Debug.Log(Application.persistentDataPath);
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS3" + ".jaon";
        myDataString = EncryptDecryptData(myDataString);
        System.IO.File.WriteAllText(file, myDataString);
        saveMenu.enabled = false;
        PM.CursorChange();
        Debug.Log("Saving");
    }
    public void SaveSlot4()
    {
        emySS.sSAEmy4 = true;
        PlayerSavedData myData = new PlayerSavedData();
        myData.PlyLocationX = transform.position.x;
        myData.PlyLocationY = transform.position.y;
        myData.PlyLocationZ = transform.position.z;
        myData.plyHealthSV = plyHelth.playerHP;
        myData.plyAmmoSV = plyBoSh.bulletCount;
        myData.plyEmeraldSV = plyHelth.emeraldCount;
        myData.plyEmCollectSV = EmeraldCountNumber;
        string myDataString = JsonUtility.ToJson(myData);
        Debug.Log(Application.persistentDataPath);
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS4" + ".jaon";
        myDataString = EncryptDecryptData(myDataString);
        System.IO.File.WriteAllText(file, myDataString);
        saveMenu.enabled = false;
        PM.CursorChange();
        Debug.Log("Saving");
    }
    public void LoadSlot1()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS1" + ".jaon";
        if (File.Exists(file))
        {
            emySS.lSAEmy1 = true;
            var jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            PlayerSavedData myData = JsonUtility.FromJson<PlayerSavedData>(jsonData);
            transform.position = new Vector3(myData.PlyLocationX, myData.PlyLocationY, myData.PlyLocationZ);
            plyHelth.playerHP = myData.plyHealthSV;
            plyBoSh.bulletCount = myData.plyAmmoSV;
            plyHelth.emeraldCount = myData.plyEmeraldSV;
            EmeraldCountNumber = myData.plyEmCollectSV;
            PM.CursorChange();
            loadMenu.enabled = false;
        }
    }
    public void LoadSlot2()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS2" + ".jaon";
        if (File.Exists(file))
        {
            emySS.lSAEmy2 = true;
            var jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            PlayerSavedData myData = JsonUtility.FromJson<PlayerSavedData>(jsonData);
            transform.position = new Vector3(myData.PlyLocationX, myData.PlyLocationY, myData.PlyLocationZ);
            plyHelth.playerHP = myData.plyHealthSV;
            plyBoSh.bulletCount = myData.plyAmmoSV;
            plyHelth.emeraldCount = myData.plyEmeraldSV;
            EmeraldCountNumber = myData.plyEmCollectSV;
            PM.CursorChange();
            loadMenu.enabled = false;
        }
    }
    public void LoadSlot3()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS3" + ".jaon";
        if (File.Exists(file))
        {
            emySS.lSAEmy3 = true;
            var jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            PlayerSavedData myData = JsonUtility.FromJson<PlayerSavedData>(jsonData);
            transform.position = new Vector3(myData.PlyLocationX, myData.PlyLocationY, myData.PlyLocationZ);
            plyHelth.playerHP = myData.plyHealthSV;
            plyBoSh.bulletCount = myData.plyAmmoSV;
            plyHelth.emeraldCount = myData.plyEmeraldSV;
            EmeraldCountNumber = myData.plyEmCollectSV;
            PM.CursorChange();
            loadMenu.enabled = false;
        }
    }
    public void LoadSlot4()
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + "SS4" + ".jaon";
        if (File.Exists(file))
        {
            emySS.lSAEmy4 = true;
            var jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            PlayerSavedData myData = JsonUtility.FromJson<PlayerSavedData>(jsonData);
            transform.position = new Vector3(myData.PlyLocationX, myData.PlyLocationY, myData.PlyLocationZ);
            plyHelth.playerHP = myData.plyHealthSV;
            plyBoSh.bulletCount = myData.plyAmmoSV;
            plyHelth.emeraldCount = myData.plyEmeraldSV;
            EmeraldCountNumber = myData.plyEmCollectSV;
            PM.CursorChange();
            loadMenu.enabled = false;
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