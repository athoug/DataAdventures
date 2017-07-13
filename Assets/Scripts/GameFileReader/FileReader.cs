using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
public class FileReader : MonoBehaviour {

	/// <summary>
	/// Gets or sets the name of the file.
	/// </summary>
	/// <value>The name of the file.</value>
	public string FileName { get; set; }

	public static GameFile TheGameFile;

	public SuspectListManager SLM;

	/// <summary>
	/// Reads a SaveGame file. SaveGame files are saved in JSON format
	/// </summary>
    public FileReader()
    {

    }
	/// <summary>
	/// Reads the save file.
	/// </summary>
    public void ReadSaveFile()
    {
		string gFile = File.ReadAllText("Assets/Albert_Einstein-0.json");
		//Debug.Log(gFile);
		//StringReader r1 = new StringReader(gF);
		//GameFile gf = JsonUtility.FromJson<GameFile>(GameFile);
		TheGameFile = JsonUtility.FromJson<GameFile>(gFile);
    }

	public void SetUpSuspects()
	{
		foreach (int ID in TheGameFile.crime.suspects)
		{
			//Debug.Log(ID);
			Person addMe = new Person();
			foreach (Person p in TheGameFile.people)
			{
				if (p.id == ID)
				{
					addMe = p;
				}
			}
			SLM.AddSuspect(addMe);
		}
	}
}
