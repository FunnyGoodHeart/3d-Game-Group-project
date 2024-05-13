using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class enemySaving : MonoBehaviour
{
    private static string keyWord = "3366336999";
    EnemySaveSlotScript EmySS;
    EnemyHealth emyHealth;
    void Start()
    {
        EmySS = GetComponentInParent<EnemySaveSlotScript>();
        emyHealth = GetComponent<EnemyHealth>();
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
    void Update()
    {
        if (EmySS.sSAEmy1)
        {
            EnemySaving("SaveSlot1");
        }
        else if (EmySS.sSAEmy2)
        {
            EnemySaving("SaveSlot2");
        }
        else if (EmySS.sSAEmy3)
        {
            EnemySaving("SaveSlot3");
        }
        else if (EmySS.sSAEmy4)
        {
            EnemySaving("SaveSlot4");
        }
    }
    public void EnemyLoading(string SaveSlotName)
    {
        string file = Application.persistentDataPath + "/" + gameObject.name + SaveSlotName + ".jaon";
        if (File.Exists(file))
        {
            var jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            EnemySavedData enemyData = JsonUtility.FromJson<EnemySavedData>(jsonData);
            emyHealth.enemyHP = enemyData.EnemyHealth;
        }
    }
    public void EnemySaving(string SaveSlotName)
    {
        EnemySavedData emyData = new EnemySavedData();
        emyData.EnemyHealth = emyHealth.enemyHP;
        string emyDataString = JsonUtility.ToJson(emyData);
        //Debug.Log(Application.persistentDataPath);
        string file = Application.persistentDataPath + "/" + gameObject.name + SaveSlotName + ".jaon"; // between / & gameobject.name put saveState
        emyDataString = EncryptDecryptData(emyDataString);
        System.IO.File.WriteAllText(file, emyDataString);
    }
}
public class EnemySavedData
{
    public int EnemyHealth;
}
