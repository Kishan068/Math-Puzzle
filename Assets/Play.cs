using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    //public GameObject winobj, playobj, hint_img;
    public GameObject hint_img;
    public Text ans, leveltitle, hint_txt;
    public Button del, smt;
    int levelNo = 1, maxlevelNo = 1, Score = 0;
    public Image board;
    public Sprite[] allimages;
    string[] trueans = { "10", "25", "6", "14", "112", "0", "50", "1025", "100", "3", "212", "3011", "14",
        "16", "1", "2", "44", "45", "625", "1", "13", "47", "50", "34" };
    string[] hintans = {"Sum","Mul","Mul","Total Square","6 * 12 = 72","Even","Div,Mul,Add,Sub","Sum And Square","Mul,Sum",
        "Sub","Sum And Sub","Mul And Sum","Div,Mul,Add,Sub","Mul And Square","Start","Even","Sub","45","Mul","Start",
        "Total Triangles","Mul,Add 5","Mul And Sum","34"};

    // Start is called before the first frame update
    void Start()
    {
        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        maxlevelNo = PlayerPrefs.GetInt("maxlevelNo", 1);
        leveltitle.text = "Puzzle " + levelNo;
        board.sprite = allimages[levelNo - 1];
        Score = PlayerPrefs.GetInt("Score", 0);
    }

    // Update is called once per frame
    void Update()
    {
        getNum();
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void btnum(int n)
    {
        ans.text = ans.text + n.ToString();
    }
    public void delete()
    {
        if (ans.text == "")
        {
            ans.text = "";
        }
        else
        {
            string s = ans.text;
            ans.text = s.Remove(s.Length - 1);
        }
    }
    public void submit()
    {
        if (ans.text == trueans[levelNo - 1])
        {
            PlayerPrefs.DeleteKey("skip_" + levelNo);
            PlayerPrefs.SetInt("win_" + levelNo, levelNo);
            ans.text = "";
            levelNo++;
            PlayerPrefs.SetInt("levelNo", levelNo);
            if (levelNo >= maxlevelNo)
            {
                maxlevelNo++;
                PlayerPrefs.SetInt("maxlevelNo", maxlevelNo);
                Score = PlayerPrefs.GetInt("Score", 0);
                Score += 20;
                PlayerPrefs.SetInt("Score", Score);
            }
            SceneManager.LoadScene("Win");
        }
        else
        {
            ans.text = "";
        }
    }
    public void skip()
    {
        PlayerPrefs.SetInt("skip_" + levelNo, levelNo);
        levelNo++;
        PlayerPrefs.SetInt("levelNo", levelNo);
        if (levelNo >= maxlevelNo)
        {
            maxlevelNo++;
            PlayerPrefs.SetInt("maxlevelNo", maxlevelNo);
        }
        SceneManager.LoadScene("Play");
    }
    public void hint()
    {
        if ((Score - 10) > 0)
        {
            if (!PlayerPrefs.HasKey("hint_" + levelNo))
            {
                Score = PlayerPrefs.GetInt("Score", 0);
                Score -= 10;
                PlayerPrefs.SetInt("Score", Score);
            }
            PlayerPrefs.SetInt("hint_" + levelNo, levelNo);
            hint_img.SetActive(true);
            levelNo = PlayerPrefs.GetInt("levelNo", 1);
            hint_txt.text = hintans[levelNo - 1].ToString();
        }
        else
        {
            hint_img.SetActive(true);
            hint_txt.text = "Insufficient Score";
        }
    }
    public void ok()
    {
        hint_img.SetActive(false);
    }

    public void getNum()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            ans.text = ans.text + "0";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1))
        {
            ans.text = ans.text + "1";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2))
        {
            ans.text = ans.text + "2";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3))
        {
            ans.text = ans.text + "3";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            ans.text = ans.text + "4";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5))
        {
            ans.text = ans.text + "5";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            ans.text = ans.text + "6";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            ans.text = ans.text + "7";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            ans.text = ans.text + "8";
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9))
        {
            ans.text = ans.text + "9";
        }
        else if (Input.GetKeyDown(KeyCode.Backspace))
        {
            if (ans.text == "")
            {
                ans.text = "";
            }
            else
            {
                string s = ans.text;
                ans.text = s.Remove(s.Length - 1);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            if (ans.text == trueans[levelNo - 1])
            {
                if (PlayerPrefs.HasKey("skip_" + levelNo))
                {
                    Score += 20;
                    PlayerPrefs.SetInt("Score", Score);
                }
                PlayerPrefs.DeleteKey("skip_" + levelNo);
                PlayerPrefs.SetInt("win_" + levelNo, levelNo);
                ans.text = "";
                levelNo++;
                PlayerPrefs.SetInt("levelNo", levelNo);
                if (levelNo >= maxlevelNo)
                {
                    maxlevelNo++;
                    PlayerPrefs.SetInt("maxlevelNo", maxlevelNo);
                    Score += 20;
                    PlayerPrefs.SetInt("Score", Score);
                }
                SceneManager.LoadScene("Win");
            }
            else
            {
                ans.text = "";
            }
        }
    }
}
