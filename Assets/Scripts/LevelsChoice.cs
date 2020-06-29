using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityStandardAssets.CrossPlatformInput;


public class LevelsChoice : MonoBehaviour
{
    [SerializeField] float playerSpeed = 2f;
    public LevelsChoice player;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<LevelsChoice>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        Debug.Log(otherObject.name);
        //TODO: zrobić level loader z wyborem poziomów
        //TODO: funkcja ze znajdowaniem nazwy obiektu
        //TODO: funkcja która ładuje poziom w zależności od tego, na jakim obiekcie jest gracz
    }
}
