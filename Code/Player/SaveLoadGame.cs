using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class SerializableVector3
{
    public float x;
    public float y;
    public float z;

    public SerializableVector3(Vector3 vector)
    {
        x = vector.x;
        y = vector.y;
        z = vector.z;
    }

    public Vector3 ToVector3()
    {
        return new Vector3(x, y, z);
    }
}

public class SaveLoadGame : MonoBehaviour
{
    private string savePath;

    private void Start()
    {
        savePath = Application.persistentDataPath + "/Save";
        Debug.Log("Save Path: " + savePath);

        if (!Directory.Exists(savePath))
        {
            Directory.CreateDirectory(savePath);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            SaveGame();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            LoadGame();
        }
    }

    private void SaveGame()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            Vector3 playerPosition = player.transform.position;

            // 使用自定义的 SerializableVector3 类保存位置数据
            SerializableVector3 serializablePosition = new SerializableVector3(playerPosition);

            FileStream fileStream = new FileStream(savePath + "/SaveData.sav", FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();

            // 序列化并保存位置数据
            formatter.Serialize(fileStream, serializablePosition);
            fileStream.Close();

            Debug.Log("Game Saved!");
        }
        else
        {
            Debug.LogWarning("Player not found!");
        }
    }

    private void LoadGame()
    {
        if (File.Exists(savePath + "/SaveData.sav"))
        {
            FileStream fileStream = new FileStream(savePath + "/SaveData.sav", FileMode.Open);
            BinaryFormatter formatter = new BinaryFormatter();

            // 反序列化并获取保存的位置数据
            SerializableVector3 savedPosition = (SerializableVector3)formatter.Deserialize(fileStream);
            fileStream.Close();

            // 将保存的位置数据转换回 Vector3
            Vector3 loadedPosition = savedPosition.ToVector3();

            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = loadedPosition;
                Debug.Log("Game Loaded!");
            }
            else
            {
                Debug.LogWarning("Player not found!");
            }
        }
        else
        {
            Debug.LogWarning("Save file not found!");
        }
    }
}