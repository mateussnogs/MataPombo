using UnityEngine;
using System.Collections;

public class BoyMovement : MonoBehaviour
{

    [SerializeField]
    float speed = 3f;
	// Use this for initialization
	void Start ()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
	}
	
	// Update is called once per frame
	void Update ()
    {
	
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Scenario")
        {
            speed *= -1;
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
        }
    }
}
