using UnityEngine;
using System.Collections;
using LitJson;
using System.Collections.Generic;
using System.IO;
public class TooltipDatabase : MonoBehaviour
{
    public bool DataFromServer;
    private List<Plate> plateDatabase = new List<Plate>();
    private JsonData plateData;
    void Start()
    {
        if (DataFromServer)
        {
            StartCoroutine(loadData());
        }
        else
        {
            plateData = JsonMapper.ToObject(File.ReadAllText(Application.dataPath + "/StreamingAssets/Plates.json"));
            plateData = plateData["Plates"];
            ConstructPlateDatabase();
            Debug.Log(FetchPlateInfoByID(1).Title);
        }
    }
    public Plate FetchPlateInfoByID(int id)
    {
        for (int i = 0; i < plateDatabase.Count; i++)
        {
            Debug.Log(plateDatabase[i].Title);
            if (plateDatabase[i].ID == id)
                return plateDatabase[i];
        }
        return null;
    }
    void ConstructPlateDatabase()
    {
        for (int i = 0; i < plateData.Count; i++)
        {
            plateDatabase.Add(new Plate(0/*(int)plateData[i]["id"]*/, plateData[i]["title"].ToString(), 0/*
(int)plateData[i]["process"]*/));
        }
    }
    IEnumerator loadData()
    {
        Debug.Log("Loading...");
        string url = "http://paultondeur.com/files/2010/UnityExternalJSONXML/books.json";
        Debug.Log("Url set");
        WWW www = new WWW(url);
        Debug.Log("access to server");
        yield return www;
        Debug.Log("Json Loaded");
        if (www.error == null)
        {
            //Sucessfully loaded the JSON string
            Debug.Log("Loaded following JSON string" + www.text);
            plateData = JsonMapper.ToObject(www.text);
            plateData = plateData["book"];
            ConstructPlateDatabase();
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
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