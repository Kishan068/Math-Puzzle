using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour
{
    //public GameObject homeobj, playobj, levelobj;
    public Button[] b;
    int levelNo = 0, maxlevelNo = 0;
    public Sprite tick;
    // Start is called before the first frame update
    void OnEnable()
    {
        levelNo = PlayerPrefs.GetInt("levelNo", 1);
        maxlevelNo = PlayerPrefs.GetInt("maxlevelNo", 1);
        for(int i = 0; i < maxlevelNo; i++)
        {
            b[i].interactable = true;
            b[i].GetComponentInChildren<Text>().text = (i + 1).ToString();
            if (i < (maxlevelNo - 1))
            {
                if (PlayerPrefs.HasKey("skip_" + (i + 1)))
                {
                    if (PlayerPrefs.HasKey("win_" + (i + 1)))
                    {
                        b[i].GetComponent<Image>().sprite = tick;
                    }
                    else
                    {
                        b[i].GetComponent<Image>().sprite = null;
                    }
                }
                else
                {
                    b[i].GetComponent<Image>().sprite = tick;
                }
            }
            else
            {
                b[i].GetComponent<Image>().sprite = null;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void levelnoclick(int n)
    {
        PlayerPrefs.SetInt("levelNo", n);
        SceneManager.LoadScene("Play");
    }
}
