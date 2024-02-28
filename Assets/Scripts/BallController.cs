using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    
    Rigidbody rb;

    public GameObject particle;

    bool started;

    bool gameover;
    void Awake()
    {
        rb = GetComponent<Rigidbody> ();
    }
    void Start()
    {
        started = false;
        gameover = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!started)
        {
          
            if(Input.GetMouseButtonDown (0) )
            {
                rb.velocity = new Vector3(speed, 0, 0);     //velocity of the ball
                started = true;

                GameManager.instance.StartGame();
            }

            

        }

          
        if( !Physics.Raycast(transform.position, Vector3.down, 1f))     // checks if ball is still in contact with the ground
           {
                gameover = true;
                rb.velocity = new Vector3(0, -25f, 0);
                Camera.main.GetComponent<CameraFollower>().gameover = true;

                GameManager.instance.GameOver();
           }
        
        if(Input.GetMouseButtonDown (0) && !gameover)
        {
            SwitchDirection();

        }
        
    }

    void SwitchDirection()
    {
        if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0 ,0 ,speed);
        }

        else if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed,0 ,0 );
        }

    }
    //to check for diamonds
    void OnTriggerEnter(Collider col) {

        if(col.gameObject.tag == "Diamond")
        {
            GameObject part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Sound.instance.coinsource.PlayOneShot(Sound.instance.coinSound);
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
        
    }
}
