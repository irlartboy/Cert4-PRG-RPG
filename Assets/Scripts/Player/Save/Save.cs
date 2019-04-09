using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

public static class Save
{
    public static void SaveData(Player player)
    {
        // Binary formatter
        BinaryFormatter formatter = new BinaryFormatter();
        //Save path
        string path = Application.persistentDataPath + "/Bob_Cake.png";
        //file stream
        FileStream stream = new FileStream(path, FileMode.Create);
        //data
        Data data = new Data(player);
        //convert to binary and save to path
        formatter.Serialize(stream, data);
        //end
        stream.Close();
    }
    public static Data LoadData()
    {
        // have a path path
        string path = Application.persistentDataPath + "/Bob_Cake.png";

        // check to see if path exists
        if (File.Exists(path))
        {
            // formatter
            BinaryFormatter formatter = new BinaryFormatter();
            // stream open
            FileStream stream = new FileStream(path, FileMode.Open);
            // data deserialize
            Data data = formatter.Deserialize(stream) as Data;
            // end 
            stream.Close();
            // return
            return data;
        }

        // else
        else
        {
            // debug error
            // return null
            return null;
        }

    }

    
    
}

