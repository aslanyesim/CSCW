using UnityEngine;
using UnityEngine;
using System.Collections;

public class AddBrick : MonoBehaviour
{
    /*void Start()
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Plane);
        Renderer rend = go.GetComponent<Renderer>();
        rend.material.mainTexture = Resources.Load("glass") as Texture;
    }*/

    public GameObject prefab;
    public float gridX = 5f;
    public float gridY = 5f;
    public float spacing = 2f;
    public float high = 0.1f;
    public float xpos;
    public float zpos;
    public float startDelay = 100f;
    public float typelDelay = 0.01f;

   // public Transform ParentPrefab = null;
 //  public Transform TempPrefab;

    int[,] BrickTable = new int[5, 5] {{1,0,0,0,1},
                                      {1,1,1,1,1}, 
                                      {1,0,0,0,1},
                                      {0,1,0,1,0},
                                      {0,0,1,0,0}, };
    IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                if (BrickTable[y, x] == 1)
                {
                    Vector3 pos = new Vector3(x, high, y) * spacing;
                    xpos = x * spacing;
                    zpos = y * spacing;
                    GameObject a =(GameObject) Instantiate(prefab, pos, Quaternion.identity);
                    a.transform.parent = transform.parent;
                    //PrinterHead.transform.position = new Vector3(x, high, (y + spacing * 5)) * spacing;
                    if (transform.GetComponent<Renderer>().enabled == false)
                    {
                        a.transform.GetChild(0).GetChild(0).GetComponent<Renderer>().enabled = false;
                        a.transform.GetChild(0).GetChild(1).GetComponent<Renderer>().enabled = false;
                        a.transform.GetChild(0).GetChild(2).GetComponent<Renderer>().enabled = false;
                    }
                    yield return new WaitForSeconds(3);
                      
            }
        }
        }
    }

     void Update()
    {

    }

    /*public IEnumerator WriteLetter()
    {
        Debug.Log(" WRITELETERRRRRRRRRRRRRRRRRRR");
        yield return new WaitForSeconds(1);
        for (int y = 0; y < gridY; y++)
        {
            Debug.Log(" BEGINGINGGLOOOP");
            for (int x = 0; x < gridX; x++)
            {
                Debug.Log(" SECONDBEGINGINGGLOOOP");
                if (BrickTable[y, x] == 1)
                {
                    Debug.Log(" LASTTTSECONDBEGINGINGGLOOOP");
                    Vector3 pos = new Vector3(x, high, y) * spacing;
                    GameObject.Instantiate(prefab, pos, Quaternion.identity);
                    gameObject.SetActive(true);
                    yield return new WaitForSeconds(1);
                    Debug.Log(" LOOOOPPPPPP");
                }
            }
        }
        Debug.Log(" ENDLOOOPP");
    }*/
}