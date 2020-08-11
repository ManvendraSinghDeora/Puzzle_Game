using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject arrow;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            arrow.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (collision.tag == "arrow")
        {
            Destroy(collision.gameObject);
            RespawnArrow();
        }

    }

    void RespawnArrow()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
