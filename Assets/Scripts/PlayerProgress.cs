using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[CreateAssetMenu(
    fileName = "Player Progress",
    menuName = "Game Kuis/Player Progress"
)]
public class PlayerProgress : ScriptableObject
{
    [System.Serializable]
    public struct MainData
    {
        public int koin;
        public Dictionary<string, int> progresLevel;
    }

    [SerializeField]
    private string _filename = "contoh.txt";

    public MainData progresData = new MainData();

    public void SimpanProgress()
    {
        progresData.koin = 200;
        if (progresData.progresLevel == null)
            progresData.progresLevel = new();
        progresData.progresLevel.Add("Level Pack 1", 3);
        progresData.progresLevel.Add("Level Pack 3", 5);

        var directory = Application.dataPath + "/Temporary/";
        var path = directory + _filename;

        if (!Directory.Exists(directory))
        {
            Directory.CreateDirectory(directory);
            Debug.Log("Directory has been Created: " + directory);
        }

        if (!File.Exists(path))
        {
            File.Create(path).Dispose();
            Debug.Log("FIle created: " + path);
        }



        var fileStream = File.Open(path, FileMode.Open);
        var formatter = new BinaryFormatter();

        fileStream.Flush();
        // formatter.Serialize(fileStream, progresData);
        
        var writer = new BinaryWriter(fileStream);

        writer.Write(progresData.koin);
        foreach (var i in progresData.progresLevel)
        {
            writer.Write(i.Key);
            writer.Write(i.Value);
        }

        writer.Dispose();
        fileStream.Dispose();

        Debug.Log($"{_filename} Berhasil Disimpan");
    }

    public bool MuatProgres()
    {
        
        var directory = Application.dataPath + "/Temporary/";
        var path = directory + _filename;
        var fileStream = File.Open(path, FileMode.OpenOrCreate);

        try
        {
            var reader = new BinaryReader(fileStream);

            try
            {
                progresData.koin = reader.ReadInt32();
                if (progresData.progresLevel == null)
                    progresData.progresLevel = new();
                while (reader.PeekChar() != -1)
                {
                    var namaLevelPack = reader.ReadString();
                    var levelKe = reader.ReadInt32();
                    progresData.progresLevel.Add(namaLevelPack, levelKe);
                    Debug.Log($"{namaLevelPack}:{levelKe}");
                }

            }
            catch (System.Exception e)
            {
                Debug.Log($"ERROR: Terjadi Kesalahan saat memuat progres binary.\n{e.Message}");

                reader.Dispose();
                fileStream.Dispose();
                return false;
            }
            // var formatter = new BinaryFormatter();

            // progresData = (MainData)formatter.Deserialize(fileStream);

            fileStream.Dispose();

            Debug.Log($"{progresData.koin}; {progresData.progresLevel.Count}");

            return true;
        }
        catch (System.Exception e)
        {
            fileStream.Dispose();
            Debug.Log($"Error: Terjadi kesalahan saat memuat progres\n{e.Message}");
        }

        return false;
    }
}

