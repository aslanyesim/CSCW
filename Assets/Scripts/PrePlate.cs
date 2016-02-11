using UnityEngine;
using System.Collections;
using Vuforia;
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
	private CustomEventHandler ceh;
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
		ceh = GetComponent<CustomEventHandler>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void getIP(string address){
		plateURL = "http://" + address +"/plates";
		StartCoroutine(loadPlateData());
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
				if(temp == null){
					GameObject[] BricksToBeDeleted = GameObject.FindGameObjectsWithTag("TobedeletedPrebrick");
					
					foreach (GameObject tempp in BricksToBeDeleted) {
						Destroy(tempp);

				}
				}
				else if (letter != temp || !isPrinted)
				{
					GameObject[] BricksToBeDeleted = GameObject.FindGameObjectsWithTag("TobedeletedPrebrick");
					
					foreach (GameObject tempp in BricksToBeDeleted) {
						Destroy(tempp);
					}

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
					a.transform.right = transform.right;
					a.tag = "TobedeletedPrebrick";
                    a.transform.parent = transform;
					if (!ceh.isTracked)
					{
						a.transform.GetComponent<Renderer>().enabled = false;
						Renderer[] renderers = a.transform.GetComponentsInChildren<Renderer>();
						foreach(Renderer r in renderers){
							r.enabled = false;
						}
					}
                }
            }
        }
		isPrinted = true;
    }
}
