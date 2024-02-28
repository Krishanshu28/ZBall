using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platform;
    public GameObject diamonds;
    Vector3 lastpos;
    float size;
    public bool gameover;
    // Start is called before the first frame update
    void Start()
    {
        lastpos = platform.transform.position;
        size = platform.transform.localScale.x;

        for(int i=0;i<30;i++)
            SpawnPlatform();

      
    }

    public void StartSpawning()
    {
          InvokeRepeating("SpawnPlatform",0.1f,0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        //to check if player is alive or not
        if(GameManager.instance.gameover == true)
        {
            CancelInvoke("SpawnPlatform");
        }
    }

    void SpawnPlatform()
    {
        int rand = Random.Range (0,6);
        if(rand < 3)
            SpawnX();
        else
        {
            SpawnZ();
        }
    }
    //checking to spawn in x direction
    void SpawnX()
    {
        Vector3 pos = lastpos;
        pos.x+=size;
        lastpos = pos;
        Instantiate(platform,pos,Quaternion.identity);

        int rand = Random.Range(0,4);
        if(rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y+1, pos.z), diamonds.transform.rotation);
        }
    }
    //checking to spawn in z direction
    void SpawnZ()
    {
        Vector3 pos = lastpos;
        pos.z+=size;
        lastpos = pos;
        Instantiate(platform,pos,Quaternion.identity);

        int rand = Random.Range(0,4);
        if(rand < 1)
        {
            Instantiate(diamonds, new Vector3(pos.x, pos.y+1, pos.z), diamonds.transform.rotation);
        }
    }
    }

