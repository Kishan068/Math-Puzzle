using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Play : MonoBehaviour
{
    //public GameObject winobj, playobj;
    public GameObject hint_img;
    public Text ans, leveltitle, hint_txt;
    public Button del, smt;
    int levelNo = 1, maxlevelNo = 1, Score = 0;
    public Image board;
    public Sprite[] allimages;
    string[] trueans = { "10", "25", "6", "14", "112", "0", "50", "1025", "100", "3", "212", "3011", "14",
        "16", "1", "2", "44", "45", "625", "1", "13", "47", "50", "34" };
    string[] hintans = {"Sum","Multiplication","Multiplication","Total Square","6*12=72","Even","Div,Multi,Add,Sub","Sum And Square","Multi,Sum",
        "Sub","Sum And Sub","Multi And Sum","Div,Multi,Add,Sub","Multi And Square","Start","Even","Sub","45","Multi","Start",
        "Total Triangles","Multi,Add 5","Multi And Sum","34"};

    // Start is called before the first frame update
    void Start()
    {
        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        maxlevelNo = PlayerPrefs.GetInt("maxlevelNo", 1);
        Score = PlayerPrefs.GetInt("Score", 0);
        leveltitle.text = "Puzzle " + levelNo;
        board.sprite = allimages[levelNo - 1];
    }

    // Update is called once per frame
    void Update()
    {
        
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
            hint_img.SetActive(true);
            levelNo = PlayerPrefs.GetInt("levelNo", 1);
            hint_txt.text = hintans[levelNo - 1].ToString();
            Score -= 10;
            PlayerPrefs.SetInt("Score", Score);
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
}
