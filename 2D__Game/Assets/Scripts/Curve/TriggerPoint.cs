using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerPoint : MonoBehaviour
{
    public GameObject Curve;
    private SpawnCircle SpawnCurve;
    private Main main;
    private bool triger = false;
    private GameObject thisPrefabCircle;
    //private Touch touchControl;
    // Start is called before the first frame update
    void Start()
    {
        SpawnCurve = Curve.GetComponent<SpawnCircle>();
        main = GameObject.Find("Main Camera").GetComponent<Main>();
    }

    // Update is called once per frame
    private void Update()
    {
        if(main.IsTouch)
        {
            if(Input.touchCount > 0)
            {
                if (triger)
                {
                    
                    SpawnCurve.CreateTabCircle();
                    StartCoroutine(main.playAnimation());
                    main.GetPoint();
                    Destroy(thisPrefabCircle);
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
                    
                    SpawnCurve.CreateTabCircle();
                    StartCoroutine(main.playAnimation());
                    main.GetPoint();
                    Destroy(thisPrefabCircle);
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
        triger = true;
        thisPrefabCircle = collision.gameObject;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        triger = false;
    }
}
