using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    private static string keyWord = "123456789";
    //press key saved data
    //press another key, load data
    
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Save();
        }
        if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            Load();
        }
    }
    public void Save()
    {
        //if want different save do : Save (string saveState)
        //save data
        SaveData myData = new SaveData();
        myData.x = transform.position.x;
        myData.y = transform.position.y;
        myData.z = transform.position.z;
        string myDataString = JsonUtility.ToJson(myData);
        //Debug.Log(Application.persistentDataPath);
        string file = Application.persistentDataPath + "/" + gameObject.name + ".jaon"; // between / & gameobject.name put saveState
        myDataString = EncryptDecryptData(myDataString);
        System.IO.File.WriteAllText(file, myDataString);
        Debug.Log("Saving");
    }
    public void Load()
    {
        //load data
        string file = Application.persistentDataPath + "/" + gameObject.name + ".jaon";
        if (File.Exists(file))
        {
            var jsonData = File.ReadAllText(file);
            jsonData = EncryptDecryptData(jsonData);
            SaveData myData = JsonUtility.FromJson<SaveData>(jsonData);
            transform.position = new Vector3(myData.x, myData.y, myData.z);
        }
    }
    public string EncryptDecryptData(string data)
    {
        string result = "";
        for(int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ keyWord[i % keyWord.Length]);
        }


        return result;
    }
}
[System.Serializable]
public class SaveData
{
    public float x;
    public float y;
    public float z;
}
