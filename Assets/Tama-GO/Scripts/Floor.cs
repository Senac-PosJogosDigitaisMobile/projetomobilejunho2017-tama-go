using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{
	public GameObject breakEgg;
	private float randomNumb;

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "Ovo")
		{
			randomNumb = Random.Range (0.3f, 1.5f);
			Vector3 breakPosition = new Vector3 (other.transform.position.x, other.transform.position.y - randomNumb, -randomNumb);
			GameObject eggClone = Instantiate (breakEgg, breakPosition, transform.rotation);

			Destroy (eggClone, 10f);

			Destroy (other.gameObject);
		}
	}
}
