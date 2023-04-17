using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine;

public class SaveLoad
{
    public static void SaveData(Molecule molecule)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/" + molecule.molecule_name + ".molecule";

        FileStream stream = new FileStream(path, FileMode.Create);

        MoleculeData Data = new MoleculeData(molecule);

        formatter.Serialize(stream, Data);
        stream.Close();

        Debug.Log("in " + path);
    }

    public static MoleculeData LoadData(string item_name)
    {
        string path = Application.persistentDataPath + "/" + item_name + ".molecule";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            MoleculeData data = formatter.Deserialize(stream) as MoleculeData;

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }

    public static void SaveNames(List<string> SaveNames)
    {
        string[] Names = SaveNames.ToArray();

        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/molecule.name";

        FileStream stream = new FileStream(path, FileMode.Create);

        formatter.Serialize(stream, Names);
        stream.Close();
    }

    public static string[] LoadNames()
    {
        string path = Application.persistentDataPath + "/molecule.name";

        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            string[] data = formatter.Deserialize(stream) as string[];
            /*string info = "";
            for (int i = 0; i < data.Length; i++)
            {
                info += data[i] + ", ";
            }
            Debug.Log(info);*/

            stream.Close();

            return data;
        }
        else
        {
            Debug.LogError("Error: Save file not found in " + path);
            return null;
        }
    }
}
