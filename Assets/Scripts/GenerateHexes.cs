using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHexes : MonoBehaviour
{
    public GameObject HexPrefab;
    public GameObject starterHex;
    public List<GameObject> ActiveHexes;

    public int height = 15;
    public int width = 5;
    float xOffset = 1.74f;
    float zOffset = 0.5f;
    Vector2 Map_offset =new Vector2(-4f,-3f);

    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                float xPos = x * xOffset;

                if (y % 2 == 1)
                {
                    xPos += xOffset / 2f;
                }

                GameObject Tile_go = (GameObject)Instantiate(HexPrefab, Map_offset + new Vector2(xPos, y * zOffset), Quaternion.identity);
                Tile_go.transform.SetParent(this.transform);
                Tile_go.name = "Hex_" + x + "_" + y;

            }
        }

        ActiveHexes = new List<GameObject>();

        for (int z = 2; z <= 6; z++)
        {
            string starterHexName = "Hex_0_" + z;
            ActiveHexes.Add(GameObject.Find(starterHexName));
            starterHex = GameObject.Find(starterHexName);
            starterHex.GetComponent<honeyHex>().status = 1;
        }

    }

    // Update is called once per frame
    void Update()
    {

    }


}
