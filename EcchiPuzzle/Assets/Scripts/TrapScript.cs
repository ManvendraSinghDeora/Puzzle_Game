using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapScript : MonoBehaviour
{
    public GameObject arrow;
    public Vector2 arrowpos;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            arrow.GetComponent<Rigidbody2D>().gravityScale = 1;
        }
        if (collision.tag == "arrow")
        {
            collision.transform.position = arrowpos;
            anim.Play("arrowanim");
            collision.gameObject.SetActive(false);
            StartCoroutine(RespawnArrow());
        }

    }
    IEnumerator RespawnArrow()
    {
        yield return new WaitForSeconds(1.5f);

        arrow.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
    }
}
