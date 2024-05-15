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
            EnemySavedData emyData = new EnemySavedData();
            emyData.EnemyHealth = emyHealth.enemyHP;
            string emyDataString = JsonUtility.ToJson(emyData);
            //Debug.Log(Application.persistentDataPath);
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS1" + ".jaon"; // between / & gameobject.name put saveState
            emyDataString = EncryptDecryptData(emyDataString);
            System.IO.File.WriteAllText(file, emyDataString);
        }
        else if (EmySS.sSAEmy2)
        {
            EnemySavedData emyData = new EnemySavedData();
            emyData.EnemyHealth = emyHealth.enemyHP;
            string emyDataString = JsonUtility.ToJson(emyData);
            //Debug.Log(Application.persistentDataPath);
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS2" + ".jaon"; // between / & gameobject.name put saveState
            emyDataString = EncryptDecryptData(emyDataString);
            System.IO.File.WriteAllText(file, emyDataString);
        }
        else if (EmySS.sSAEmy3)
        {
            EnemySavedData emyData = new EnemySavedData();
            emyData.EnemyHealth = emyHealth.enemyHP;
            string emyDataString = JsonUtility.ToJson(emyData);
            //Debug.Log(Application.persistentDataPath);
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS3" + ".jaon"; // between / & gameobject.name put saveState
            emyDataString = EncryptDecryptData(emyDataString);
            System.IO.File.WriteAllText(file, emyDataString);
        }
        else if (EmySS.sSAEmy4)
        {
            EnemySavedData emyData = new EnemySavedData();
            emyData.EnemyHealth = emyHealth.enemyHP;
            string emyDataString = JsonUtility.ToJson(emyData);
            //Debug.Log(Application.persistentDataPath);
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS4" + ".jaon"; // between / & gameobject.name put saveState
            emyDataString = EncryptDecryptData(emyDataString);
            System.IO.File.WriteAllText(file, emyDataString);
        }
        else if (EmySS.lSAEmy1)
        {
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS1" + ".jaon";
            if (File.Exists(file))
            {
                var jsonData = File.ReadAllText(file);
                jsonData = EncryptDecryptData(jsonData);
                EnemySavedData enemyData = JsonUtility.FromJson<EnemySavedData>(jsonData);
                emyHealth.enemyHP = enemyData.EnemyHealth;
            }
        }
        else if (EmySS.lSAEmy2)
        {
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS2" + ".jaon";
            if (File.Exists(file))
            {
                var jsonData = File.ReadAllText(file);
                jsonData = EncryptDecryptData(jsonData);
                EnemySavedData enemyData = JsonUtility.FromJson<EnemySavedData>(jsonData);
                emyHealth.enemyHP = enemyData.EnemyHealth;
            }
        }
        else if (EmySS.lSAEmy3)
        {
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS3" + ".jaon";
            if (File.Exists(file))
            {
                var jsonData = File.ReadAllText(file);
                jsonData = EncryptDecryptData(jsonData);
                EnemySavedData enemyData = JsonUtility.FromJson<EnemySavedData>(jsonData);
                emyHealth.enemyHP = enemyData.EnemyHealth;
            }
        }
        else if (EmySS.lSAEmy4)
        {
            string file = Application.persistentDataPath + "/" + gameObject.name + "SS4" + ".jaon";
            if (File.Exists(file))
            {
                var jsonData = File.ReadAllText(file);
                jsonData = EncryptDecryptData(jsonData);
                EnemySavedData enemyData = JsonUtility.FromJson<EnemySavedData>(jsonData);
                emyHealth.enemyHP = enemyData.EnemyHealth;
            }
        }
    }
}
public class EnemySavedData
{
    public int EnemyHealth;
}
