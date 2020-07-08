using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListAH : MonoBehaviour
{

    public string list;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        AddToList();
        UpdateText();
    }

    public void AddToList()
    {
        GenerateHexes hexgenerator = FindObjectOfType<GenerateHexes>();
        //Debug.Log(hexgenerator.ActiveHexes.Count);
        if (hexgenerator.ActiveHexes.Count == 0)
        {
            list = "empty___";
        }
        else
        {
            list = "ActiveHexes: ";
            int len = hexgenerator.ActiveHexes.Count; // count = 1   [0]

            for (int i = 0; i < len; i++)
            {
                list = list + hexgenerator.ActiveHexes[i].name.ToString() + " ";
            }
        }
    }

    private void UpdateText()
    {
        this.GetComponent<TextMesh>().text = list;
    }
}