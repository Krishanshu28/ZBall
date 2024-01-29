using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static UIManager instance;
    public GameObject ZigZagPanel;
    public GameObject GameOverPanel;
    public GameObject tapText;

    public Text score;

    public Text highscore1;

    public Text highscore2;

    void Awake() {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        highscore1.text = "High Score: " + PlayerPrefs.GetInt("highscore").ToString();
    }

    public void GameStart()
    {
        
        tapText.SetActive(false);
        ZigZagPanel.GetComponent<Animator>().Play("PanelUp");

    }

    public void GameOver()
    {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highscore2.text = PlayerPrefs.GetInt("highscore").ToString();
        GameOverPanel.SetActive(true);
    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
