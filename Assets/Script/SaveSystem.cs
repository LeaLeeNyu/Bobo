using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


public static class SaveSystem
{

    //make SavePlayer static to call it from anywhere
    public static void SavePlayer(CheckingPoint checkPoint)
    {
        //Serializes in binary format
        BinaryFormatter formatter = new BinaryFormatter();
        // set the file saving location
        string path = Application.persistentDataPath + "/Bobo.game";
        //Instantiate a FileStream support the function of  writing or reading the file
        FileStream stream = new FileStream(path, FileMode.Create);

        //write the data in the file in binary format
        PlayerData data = new PlayerData(checkPoint);
        formatter.Serialize(stream, data);

        //End writing or reading behaviour
        stream.Close();

    }

    public static PlayerData LoadData()
    {
        string path = Application.persistentDataPath + "/Bobo.game";

        // check if there is a file in the path
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            //open the file
            FileStream stream = new FileStream(path, FileMode.Open);

            //Deserialize the binary file and read as PlayerData
            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();

            //The constructor's return type is not viod, should have return value!
            return data;
        }
        else
        {
            Debug.Log("No Data Record!");
            return null;
        }
    }

}
