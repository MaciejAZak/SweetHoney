using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class HexPlacement : MonoBehaviour
{
    [SerializeField] int X = 0;
    [SerializeField] int Y = 0;

    // Update is called once per frame
    void Update()
    {
        Vector3 snapPos;
        if (X % 2 == 0)
        {
            //snapPos.x = X * 1.74f;
            snapPos.x = X * 0.87f;
            snapPos.y = Y;
        }
        else
        {
            snapPos.x = X * 0.87f;
            snapPos.y = Y + 0.5f;
        }

        transform.position = new Vector3(snapPos.x, snapPos.y, 0f);
        this.name = "Hex_" + X + "_" + Y;
    }
}
