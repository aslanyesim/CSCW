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
    public float startDelay = 1f;
    public float typelDelay = 0.01f;


    int[,] BrickTable = new int[5, 5] {{1,0,0,0,1},
                                      {1,1,1,1,1}, 
                                      {1,0,0,0,1},
                                      {0,1,0,1,0},
                                      {0,0,1,0,0}, };

    void Start()
    {
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                if (BrickTable[y, x] == 1)
                {
                    Vector3 pos = new Vector3(x, high, y) * spacing;
                    Instantiate(prefab, pos, Quaternion.identity);
                    //yield return new WaitForSeconds(typelDelay);
                }
            }
        }
    }

    void TypeIn()
    {
        //yield return new WaitForSeconds(startDelay);
        for (int y = 0; y < gridY; y++)
        {
            for (int x = 0; x < gridX; x++)
            {
                if (BrickTable[y, x] == 1)
                {
                    Vector3 pos = new Vector3(x, high, y) * spacing;
                    Instantiate(prefab, pos, Quaternion.identity);
                    //yield return new WaitForSeconds(typelDelay);
                }
            }
        }
    }
}