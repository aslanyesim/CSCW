using UnityEngine;
using UnityEngine;
/**/
using System.Collections;
using System.Collections.Generic;
/**/
using LitJson;

public class AddBrick : MonoBehaviour
{
    /*void Start()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load("glass") as Texture;
    }*/
    /**/
    public string plateURL = "http://www.mocky.io/v2/56a1027c4200004a3e83eb72";
    /**/
    public string letterRepresentationsURL = "http://www.mocky.io/v2/56a11667420000a24283eb95";
    /**/
    public float secondsToCheckServer = .1f;

    public GameObject prefab;
    public float gridX = 5f;
    public float gridY = 5f;
    public float spacing = 2f;
    public float high = 0.1f;
    public Vector3 temp;
    public float startDelay = 100f;
    public float typelDelay = 0.01f;

    private int position = 0;
    public static bool status = true;
    public PrinterHeadAnimator head;

    /**/
    private JsonData data;
    /**/
    private string letter = "";
    /**/
    private Dictionary<string, int[,]> letterLookUp = new Dictionary<string, int[,]>();
    private bool isloaded = false;
    // public Transform ParentPrefab = null;
    //  public Transform TempPrefab;

   /* int[,] BrickTable = new int[5, 5] {{1,0,0,0,1},
                                      {1,1,1,1,1}, 
                                      {1,0,0,0,1},
                                      {0,1,0,1,0},
                                      {0,0,1,0,0}, };*/

     int[,] BrickTable = new int[5, 5]{{0,0,1,0,0},
                                       {0,1,0,1,0}, 
                                       {1,0,0,0,1},
                                       {1,1,1,1,1},
                                       {1,0,0,0,1}, };
 
    /**/
    void Start()
    {
        StartCoroutine(loadLetterRepresentations());
        /*ADD BRıCK ANiMATiON MUST BE CALLED AFTER LETTERS ARE LOADED NOT HERE*/
        StartCoroutine(addBrickAnimation());
        StartCoroutine(loadPlateData());
    }

    /**/
    IEnumerator loadLetterRepresentations()
    {
        WWW www = new WWW(letterRepresentationsURL);
        yield return www;
        if (www.error == null)
        {
            JsonData letters = JsonMapper.ToObject(www.text);

            //	Debug.Log("letter 0: " + letters[1]["array"][2].ToString());
            /*for(int i = 0; i < array.Count; i++){
                Debug.Log(array[i].ToString());
            }*/
            for (int i = 0; i < letters.Count; i++)
            {
                JsonData array = letters[i]["array"];
                int[,] tempBrickTable = fillTheArray(array);
                letterLookUp.Add(letters[i]["letter"].ToString(), tempBrickTable);
            }
            printDictionary("B");
        }
        else
        {
            Debug.Log("ERROR: " + www.error);
        }
        isloaded = true;
    }
    /**/
    int[,] fillTheArray(JsonData array)
    {
        int[,] tempArray = new int[5, 5];
        int k = 0;
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                tempArray[i, j] = (int)array[k];
                k++;
            }
        }
        return tempArray;
    }
    //Just to show how to access to the array
    /**/
    void printDictionary(string letter)
    {
        int[,] array = letterLookUp[letter];
        string log = "";
        for (int i = 0; i < 5; i++)
        {
            for (int j = 0; j < 5; j++)
            {
                log += array[i, j] + " ";
            }
            log += "\n";
        }
        Debug.Log(log);
    }
    /**/
    IEnumerator loadPlateData()
    {
        for (; ; )
        {
            WWW www = new WWW(plateURL);
            yield return www;
            if (www.error == null)
            {
                data = JsonMapper.ToObject(www.text);
                string temp = data["letter"].ToString();
                if (letter != temp)
                {
                    letter = temp;
                    //Print the new animation??
                }
            }
            else
            {
                Debug.Log("ERROR: " + www.error);
            }
            yield return new WaitForSeconds(secondsToCheckServer);
        }

    }
    /**/
    //  IEnumerator Start()
    IEnumerator addBrickAnimation()
    {
        yield return new WaitForSeconds(1);
        for (int x = 0; x < gridX; x++)
        {
            for (int y = 0; y < gridY; y++)
            {
                if (BrickTable[x, y] == 1)
                {
                    head.x = x;
                    head.z = y;
                    StartCoroutine(head.Down());// head.AnimationPrinterHead();
                    Vector3 pos = new Vector3(x, high, y) * spacing;
                    temp = pos;
                    yield return new WaitForSeconds(7);
                    GameObject a = (GameObject)Instantiate(prefab, pos, Quaternion.identity); 
                    a.transform.parent = transform.parent;
                    if (transform.GetComponent<Renderer>().enabled == false)
                    {
                        a.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = false;
                        a.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = false;
                        a.transform.GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = false;
                    }
                    yield return new WaitForSeconds(7);
                }
            }
        }
    }



   /* public void addBrickAnimation(string letter, int index) {
        while (status) {
            for (int i = position; i <= index; i++, position++)
            {
                int x = convertIndexTo2Dx(index);
                int y = convertIndexTo2Dy(index);
                if (BrickTable[x, y] == 1)
                {
                    Vector3 pos = new Vector3(x, high, y) * spacing;
                    GameObject a = (GameObject)Instantiate(prefab, pos, Quaternion.identity);
                    a.transform.parent = transform.parent;
                    if (transform.GetComponent<Renderer>().enabled == false)
                    {
                        a.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = false;
                        a.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = false;
                        a.transform.GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = false; } } } } }

    int convertIndexTo2Dx(int index) {
        int x = (index % 5);

        return x;}

    int convertIndexTo2Dy(int index) {
        int x = (index % 5);
        int y = (index - x) / 5;

        return y;}*/


    void Update()
    {

    }
}