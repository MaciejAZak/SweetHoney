using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHexes : MonoBehaviour
{
    public GameObject HexPrefab;

    int height = 15;
    int width = 5;
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
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
