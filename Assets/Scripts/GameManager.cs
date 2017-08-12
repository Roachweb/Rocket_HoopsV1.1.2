using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    static GameManager _instance = null;

    // Use this for initialization
    void Start () {
        if (instance)
            DestroyImmediate(gameObject);
        else
        {// new gameManager can be created to carry over fresh variable and progress levels
            instance = this;

            DontDestroyOnLoad(this);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Escape))
        {
            quit();//for quiting

        }

        if (Input.GetKey(KeyCode.Return))
        {
            if (SceneManager.GetActiveScene().name == "Title")

           play();//test
        }

        if (Input.GetKey(KeyCode.P))
        {
            end();//test
        }
    }

    public void play()
    {
        SceneManager.LoadScene("Arena");
    }

    public void startOver()
    {
        SceneManager.LoadScene("Title");
    }

    public void end()
    {
        SceneManager.LoadScene("Score");
    }

    public void quit()
    {

        if (SceneManager.GetActiveScene().name == "Arena")
            SceneManager.LoadScene("Title");
        else if (SceneManager.GetActiveScene().name == "Title")
        {
            Application.Quit();
            Debug.Log("Quit Game");
        }
    }

    public static GameManager instance
    {
        get { return _instance; }
        set { _instance = value; }
    }


}
