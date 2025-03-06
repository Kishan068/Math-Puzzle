using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Win : MonoBehaviour
{
    //public GameObject winobj, homeobj, playobj;
    public Text title, score_board;
    int levelNo = 0, Score = 0;

    private void OnEnable()
    {
        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        if(levelNo > 1)
        {
            title.text = "PUZZLE " + (levelNo - 1) + " COMPLETED";
        }
        else
        {
            title.text = "PUZZLE 1 COMPLETED";
        }
        Score = PlayerPrefs.GetInt("Score", 0);
        score_board.text = "Score = " + Score;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void continueclick()
    {
        SceneManager.LoadScene("Play");
    }
    public void mainclick()
    {
        SceneManager.LoadScene("Home");
    }
}
