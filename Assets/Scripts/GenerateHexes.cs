using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHexes : MonoBehaviour
{
    public GameObject HexPrefab;
    public GameObject starterHex;
    public List<GameObject> ActiveHexes;
    public List<GameObject> ToBuildHexes;
    public List<GameObject> ToGatherHexes;

    public int height = 15;
    public int width = 5;
    float xOffset = 1.74f;
    float zOffset = 0.5f;
    Vector2 Map_offset =new Vector2(-4f,-3f);
    bool hiddenCost = false;

    // Start is called before the first frame update
    void Start()
    {
        GenerateBoard();
        SetInitialActiveHexes();
    }



    private void GenerateBoard()
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
        // Create lists
        ActiveHexes = new List<GameObject>();
        ToBuildHexes = new List<GameObject>();
        ToGatherHexes = new List<GameObject>();
    }

    private void SetInitialActiveHexes()
    {
        for (int z = 2; z <= 6; z++)
        {
            string starterHexName = "Hex_0_" + z;
            ActiveHexes.Add(GameObject.Find(starterHexName));
            starterHex = GameObject.Find(starterHexName);
            starterHex.GetComponentInChildren<SpriteRenderer>().color = Color.white;
            starterHex.GetComponent<honeyHex>().status = 1;
        }
    }

    public void HideCost()
    {
        
        if (hiddenCost == false)
        {
            foreach (Transform child in transform)
                GetComponentInChildren<MeshRenderer>().gameObject.SetActive(false);
            hiddenCost = true;
        }
    }
}
