using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{

    public GameObject logo;
    public GameObject startButton;
    public AudioClip mainTheme;

    private AudioSource audiosource;

	// Use this for initialization
	void Start ()
	{

        audiosource = GetComponent<AudioSource>();
        logo.SetActive(false);
        startButton.SetActive(false);
        audiosource.PlayOneShot(mainTheme, 1f);

    }
	
	// Update is called once per frame
	void FixedUpdate ()
	{
        StartCoroutine(BeginMenu());
	}


    public IEnumerator BeginMenu()
    {
        yield return new WaitForSeconds(3.0f);
        logo.SetActive(true);
        yield return new WaitForSeconds(2.0f);
        startButton.SetActive(true);
    }

}
