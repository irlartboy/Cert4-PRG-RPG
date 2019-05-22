using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class CustomSave
{
    public static void CustomSaveData()
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.custom";
        FileStream stream = new FileStream(path, FileMode.Create);

        //CustomData data = new CustomData();

        //formatter.Serialize(stream, data);
        stream.Close();
    }
   /* public static CustomData Load()
    {
        string path = Application.persistentDataPath + "/player.custom";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            CustomData data = formatter.Deserilize(stream) as CustomData;
        }
        else
        {
           Debug.LogError("Save file not found in" + path)
           return null;
        }
    } */
}
