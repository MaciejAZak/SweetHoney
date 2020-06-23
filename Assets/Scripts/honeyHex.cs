using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class honeyHex : MonoBehaviour
{

    [SerializeField] public int status;
    SpriteRenderer MySprite;
    Animator MyAnimator;

    // Start is called before the first frame update
    void Start()
    {
        MySprite = GetComponentInChildren<SpriteRenderer>();
        MyAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        FillHexWithHoney();
    }

    void FillHexWithHoney()
    {
        {
            MyAnimator.SetInteger("status", status);
        }

    
    }
    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
         if (otherObject.GetComponent<Bee>() && status >= 1)
         {
            if (status <=5)
                status += 1;
            else if (status == 6)
            {
                status = 6;
            }
         }
        
    }
}
