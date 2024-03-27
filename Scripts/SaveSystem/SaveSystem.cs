using UnityEngine;
using System.IO;
using System;

public class SaveSystem
{
    private string _pathToFile;

    public SaveSystem(string nameFile)
    {
        _pathToFile = Application.persistentDataPath + nameFile;
    }

    public void Save(IDataSaveble dataSaveble)
    {
        try
        {
            FileStream stream = new FileStream(_pathToFile, FileMode.Create);
            dataSaveble.SaveData(new BinaryWriter(stream));
            stream.Close();
        }
        catch (Exception ex)
        {
            Debug.Log("Save failed: " + ex);
        }
    }

    public void Load(IDataSaveble dataSaveble)
    {
        try
        {
            if (File.Exists(_pathToFile))
            {
                FileStream stream = new FileStream(_pathToFile, FileMode.Open);
                dataSaveble.LoadData(new BinaryReader(stream));
                stream.Close();
            }
            else
            {
                Debug.Log("File not found. File create");
                Save(dataSaveble);
            }
        }
        catch (Exception ex)
        {
            Debug.Log("Load failed: " + ex);
        }
    }
}