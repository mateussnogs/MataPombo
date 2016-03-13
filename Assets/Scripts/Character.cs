using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
    public GameObject rabisco;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if ((Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began) || Input.GetMouseButtonDown(0))
        {            
            Touch touch = Input.GetTouch(0);

            Instantiate(rabisco, Camera.main.ScreenToWorldPoint(touch.position), Quaternion.identity);            
                /*Destroy(rabisco);*/
        }


    }
}
