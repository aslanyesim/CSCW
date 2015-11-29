using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;

public class TooltipDatabase : MonoBehaviour {
	private List<Plate> plateDatabase = new List<Plate>();
	private JsonData plateData;

	void Start()
	{
		plateData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Plates.json"));
		plateData = plateData["Plates"];
		ConstructPlateDatabase();
		Debug.Log(FetchPlateInfoByID(1).Title);
	}
	public Plate FetchPlateInfoByID(int id){
		for(int i=0; i < plateDatabase.Count; i++)
		{
			Debug.Log (plateDatabase[i].Title);
			if(plateDatabase[i].ID == id)
				return plateDatabase[i];
		}
		return null;
	}
	void ConstructPlateDatabase(){
		for(int i = 0; i < plateData.Count; i++)
		{
			plateDatabase.Add(new Plate((int)plateData[i]["id"], plateData[i]["title"].ToString(), (int)plateData[i]["process"]));
		}
	}
}
public class Plate
{
	public int ID { get; private set; }
	public string Title { get; private set; }
	public int Process { get; private set; }

	public Plate(int id, string title, int process)
	{
		this.ID = id;
		this.Title = title;
		this.Process = process;
	}
}