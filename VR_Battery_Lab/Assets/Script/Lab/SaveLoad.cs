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
    }
}
