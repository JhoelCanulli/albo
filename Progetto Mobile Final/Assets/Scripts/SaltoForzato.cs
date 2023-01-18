using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaltoForzato : MonoBehaviour
{

	public float jumpForce = 10f;

	public bool activateFlame = false;
	public GameObject flame;

    private void Start()
    {
		
		activateFlame = Random.Range(0, 5) == 1;

        if (activateFlame)
        {
			flame.SetActive(true);
        }

	}

    void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.relativeVelocity.y <= 0f && GameController.instance.isGameStarted)
		{
			Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
			if (rb != null)
			{
				collision.gameObject.GetComponent <movimentiMaghetto>().JumpAnimation();
				Vector2 velocity = rb.velocity;
				velocity.y = jumpForce;
				rb.velocity = velocity;
			}
		}
	}

}
