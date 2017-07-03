using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text scoreText;
    public int eggValue;
	public GameObject[] eggsCount;
	public GameObject closingAnim;

	private int score;
	private int point;

	private new AudioSource audio; 
	public AudioClip collectSound;


    void Start()
    {
        score = 0;
        UpdateScore();
		resetBox ();
		audio = GetComponent<AudioSource> ();
		audio.clip = collectSound; 
    }

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ovo")
        {
			audio.Play ();
			Destroy (other.gameObject);
			eggsCount[point].gameObject.SetActive (true);
			point++;
			if (point == 6)
			{
				// print (this.transform.position);
				Vector3 closePosition = new Vector3 (this.transform.position.x, this.transform.position.y, 0.0f);
				GameObject clone = Instantiate (closingAnim, closePosition, transform.rotation);
				Destroy (clone, 0.8f);

				score += eggValue;
				UpdateScore ();
				resetBox ();
				point = 0;
			}
        }
    }

	void resetBox()
	{
		for (int i = 0; i < 6; i++)
		{
			eggsCount[i].gameObject.SetActive (false);
		}
	}

    void UpdateScore()
    {
        scoreText.text = "SCORE : " + score;
    }
}
