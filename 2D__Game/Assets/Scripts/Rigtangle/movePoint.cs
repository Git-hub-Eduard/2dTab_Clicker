using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movePoint : MonoBehaviour
{
    public GameObject Test;
    private SpawnTapCircles spawn;
    private Main main;
    private bool triger = false;
    private GameObject thisCircle;
   // private Touch touchControl;
    void Start()
    {
        spawn = Test.GetComponent<SpawnTapCircles>();
        main = GameObject.Find("Main Camera").GetComponent<Main>();
    }

    // Update is called once per frame
    void Update()
    {
       if(main.IsTouch)
       {
            if(Input.touchCount>0)
            {

                if (triger)
                {

                    spawn.CreateTapClicker();
                    StartCoroutine(main.playAnimation());
                    main.GetPoint();
                    Destroy(thisCircle);
                }
                else
                {

                    main.SetGameOver();
                }

            }
       }
       else
       {
            if (Input.GetMouseButtonDown(0))
            {
                if (triger)
                {
                    
                    spawn.CreateTapClicker();
                    StartCoroutine(main.playAnimation());
                    main.GetPoint();
                    Destroy(thisCircle);
                }
                else
                {
                    
                    main.SetGameOver();
                }
            }
       }
       

    }
        
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Debug.Log("Зашол");
       thisCircle = collision.gameObject;
        triger = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log("Вышел");
        triger= false;
    }
}
