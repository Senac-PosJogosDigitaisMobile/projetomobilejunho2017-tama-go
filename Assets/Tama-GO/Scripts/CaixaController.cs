using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaixaController : MonoBehaviour {

	public bool canMove;

    private Rigidbody2D caixaRigid;
    private Vector2 mouse;

    // Use this for initialization
    void Start () {

        canMove = true;
        caixaRigid = GetComponent<Rigidbody2D>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (!canMove)
        {
            return;
        }

        if (Input.GetMouseButton(0))
        {

            mouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            // caixaRigid.MovePosition(mouse);
			caixaRigid.transform.position = mouse;
        }

    }
}
