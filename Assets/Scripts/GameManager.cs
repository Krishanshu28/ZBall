using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool gameover;

    void Awake() {
        if (instance == null)
        {
            instance=this;
        }    
    }
    // Start is called before the first frame update
    void Start()
    {
        gameover = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  StartGame(){
         
         UIManager.instance.GameStart ();
         ScoreManager.instance.StartScore ();
         GameObject.Find("PlatformSpawner").GetComponent<PlatformSpawner>().StartSpawning();
    }

    public void GameOver(){
         
         UIManager.instance.GameOver ();
         ScoreManager.instance.StopScore ();
         gameover =true;
    }
}
