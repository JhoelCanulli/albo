using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class movimentiMaghetto : MonoBehaviour
{
 
    public enum Direction { Left, Right}
    public Direction currentDirection;

    [SerializeField] private float vel = 4f;
    public float jumpForce = 10f;
    private float movimento;
    float score;

    private Rigidbody2D maghettoRb;
    private SpriteRenderer spriteRenderer;
    private Animator anim;


    [SerializeField] GameObject dynamicLight;
    [SerializeField] GameObject nuvoletta;

    void Awake()
    {
        maghettoRb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerControls();

        if (maghettoRb.velocity.y > 0 && transform.position.y > score)
        {
            score = transform.position.y;
            
            GameController.instance.scoreText.text = Mathf.Round(score).ToString();
        }

    }

    private void FixedUpdate()
    {

        Vector2 v = maghettoRb.velocity;
        v.x = movimento;
        maghettoRb.velocity = v;
        Flip(maghettoRb.velocity.x);

    }

    void PlayerControls()
    {
        if (Input.GetMouseButton(0) && GameController.instance.isGameStarted)
        {
            if (Input.mousePosition.x < Screen.width / 2)
            {
                //tapping sinistra
                movimento = -1 * vel;
                currentDirection = Direction.Left;

            }
            else
            {
                //tapping destra
                movimento = 1 * vel;
                currentDirection = Direction.Right;
            }
        }
        else
        {
            movimento = 0;
        }

        //usiamo questa linea di codice per input da tastiera
        //movimento = Input.GetAxis("Horizontal") * vel;

    }


    public void JumpAnimation()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            anim.SetTrigger("Jump");

        }
        else if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime <= 0.07f)
        {
            anim.SetTrigger("Jump");
        }
    }

    void Flip(float _velocity)
    {
        if (currentDirection == Direction.Left)
        {
            spriteRenderer.flipX = false;
            dynamicLight.transform.localPosition = new Vector3(-0.3f, 0.496f, -0.08f);
            
        }
        else if (currentDirection == Direction.Right)
        {
            spriteRenderer.flipX = true;
            dynamicLight.transform.localPosition = new Vector3(0.3f, 0.496f, -0.08f);
        }
    }
    void OnBecameInvisible()
    {
        GameController.instance.SetScore(Mathf.Round(score));
        GameController.instance.GameOver();
        Destroy(gameObject);

    }

    public void NascondiNuvoletta()
    {
        nuvoletta.gameObject.SetActive(false);
    }





}
