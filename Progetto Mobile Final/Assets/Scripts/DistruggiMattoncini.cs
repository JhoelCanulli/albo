using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistruggiMattoncini : MonoBehaviour
{

    public GameObject giocatore;
    public GameObject mattoncino;
    private GameObject mioMattoncino;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        mioMattoncino = (GameObject)Instantiate(mattoncino, new Vector2(Random.Range(-2f, 2f), giocatore.transform.position.y + (7 + Random.Range(0.5f, 1f))), Quaternion.identity);

    }
}
