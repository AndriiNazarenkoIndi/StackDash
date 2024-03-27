using System;
using System.IO;

[Serializable]
public class GameDataToSave : IDataSaveble
{
    public int maxScoreValue;

    public GameDataToSave()
    {
        maxScoreValue = 0;
    }

    public void LoadData(BinaryReader binaryReader)
    {
        maxScoreValue = binaryReader.ReadInt32();
    }

    public void SaveData(BinaryWriter binaryWriter)
    {
        binaryWriter.Write(maxScoreValue);
    }
}