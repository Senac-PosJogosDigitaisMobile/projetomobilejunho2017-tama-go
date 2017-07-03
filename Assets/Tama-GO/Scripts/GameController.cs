using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{

    public Camera cam;
    public GameObject[] eggs;
    public Text timerText;
    public GameObject gameOverText;
    public GameObject restartButton;
    public GameObject caixaOvo;
    public float timeLeft;

    private float maxWidth;
    private bool counting;

    // Use this for initialization
    void Start ()
	{
        if (cam == null)
		{
			cam = Camera.main;
		}

        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        float eggWidth = eggs[0].GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - eggWidth;
        timerText.text = "TEMPO : " + Mathf.RoundToInt(timeLeft);
        StartCoroutine(Spawn());

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (counting)
        {
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
                timeLeft = 0;
            }
            timerText.text = "TEMPO : " + Mathf.RoundToInt(timeLeft);
        }
    }

    public void StartGame()
    {
        StartCoroutine(Spawn());
    }


    public IEnumerator Spawn()
    {
        yield return new WaitForSeconds(2.0f);
        counting = true;
        while (timeLeft > 0)
        {
            GameObject egg = eggs[Random.Range(0, eggs.Length)];
            Vector3 spawnPosition = new Vector3(
                transform.position.x + Random.Range(-maxWidth, maxWidth),
                transform.position.y,
                0.0f
            );
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(egg, spawnPosition, spawnRotation);
            yield return new WaitForSeconds(Random.Range(0, 0.2f));
        }

        yield return new WaitForSeconds(1.0f);
        gameOverText.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        restartButton.SetActive(true);
    }
}
