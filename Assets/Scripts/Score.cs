using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField]
    Text scoreText;
    long score = 0;

	// Use this for initialization
	void Start ()
    {
        updateScore(0);
	}

    public void updateScore(int val)
    {
        score += val;
        scoreText.text = "Score: " + score;
    }
}
