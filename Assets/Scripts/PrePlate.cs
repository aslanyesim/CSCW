using UnityEngine;
using System.Collections;

using LitJson;
public class PrePlate : MonoBehaviour {
    public GameObject prefab;
    public float gridX = 5f;
    public float gridY = 5f;
    public float spacing = 0.25f;
    public float high = 0.01f;
	public string plateURL = "http://www.mocky.io/v2/56a1027c4200004a3e83eb72";
	public float secondsToCheckServer = 5.0f;
	public GameObject BrickPlate;
	private Vector3 temp;
	/**/
	private JsonData data;
	/**/
	private string letter = "";
	private AddBrick addBrick;
	private bool isPrinted = false;
	//private Renderer platesRenderer;
   /* int[,] BrickTable = new int[5, 5]{{0,0,1,0,0},
                                       {0,1,0,1,0}, 
                                       {1,0,0,0,1},
                                       {1,1,1,1,1},
                                       {1,0,0,0,1}, };
*/
	// Use this for initialization
	void Start () {
      //  AddPreBrick();
		addBrick = BrickPlate.GetComponent<AddBrick> ();
	//	platesRenderer = transform.GetComponent<Renderer> ();
		StartCoroutine(loadPlateData());
	}
	
	// Update is called once per frame
	void Update () {
	
	}
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

				if (letter != temp || !isPrinted)
				{
					letter = temp;
					if(addBrick.isloaded){
						AddPreBrick(addBrick.arrayOfLetter(letter));
					}
				}
			}
			else
			{
				Debug.Log("ERROR: " + www.error);
			}
			yield return new WaitForSeconds(secondsToCheckServer);
		}
		
	}
   // public void AddPreBrick()
    public void AddPreBrick(int [,] BrickTable)
    {
        for (int x = 0; x < 5; x++)
        {
            for (int y = 0; y < 5; y++)
            {
                if (BrickTable[x, y] == 1)
                {
                    Vector3 pos = new Vector3(x*0.33f ,0.09f, y*0.3f) ;
                    temp = transform.TransformPoint(pos);
                    GameObject a = (GameObject)Instantiate(prefab, temp, Quaternion.identity);
					a.transform.up = transform.up;
					a.tag = "Tobedeletedbrick";
                    a.transform.parent = transform;
                }
            }
        }
		isPrinted = true;
    }
}
