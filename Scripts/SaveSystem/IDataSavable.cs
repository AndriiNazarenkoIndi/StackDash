using System.IO;

public interface IDataSaveble
{
    void SaveData(BinaryWriter binaryWriter);
    void LoadData(BinaryReader binaryReader);
}