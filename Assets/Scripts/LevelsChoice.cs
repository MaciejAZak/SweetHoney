using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
//using UnityStandardAssets.CrossPlatformInput;


public class LevelsChoice : MonoBehaviour
{
    [SerializeField] float playerSpeed = 2f;
    [SerializeField] float loadLevelDelay = 3f;
    public string levelName;
    bool canMove = true;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == true)
        {
            Move();
        }
        SelectLevel();
        Debug.Log("Level name: " + levelName);

    }

    public void SelectLevel()
    {
        if (levelName != null && Input.GetKeyDown("return")) //TODO: nie tylko enter, ale przycisk na padzie
        {
            StartCoroutine(LoadChosenLevel());
            
        }
    }

    public void Move()
    {
        var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += move * playerSpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameObject otherObject = otherCollider.gameObject;
        levelName = otherObject.name;
        Debug.Log(otherObject.name);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        levelName = null;
    }

    IEnumerator LoadChosenLevel()
    {
        canMove = false;
        yield return new WaitForSecondsRealtime(loadLevelDelay);
        if (levelName != null)
        {
            FindObjectOfType<LevelLoader>().LoadLevel(levelName);
        }
        else
        {
            Debug.Log("Invalid level name");
        }
    }
}
