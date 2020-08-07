using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public LayerMask enemyLayer;

    Rigidbody2D rb;
    Animator anim;

    public float speed;
    public float radius;
    public int damage = 10;
    Vector2 movement;

    public Transform attackRadius;

    #region Dash
    public float timeOfDash = 0.8f;
    float max_DashTime = 1;

    public float Dash_speed;

    public enum DashStates
    {
        READY,
        DASH,
        COOLDOWN
    }

    public enum Directions
    {
        LEFT,RIGHT,UP,DOWN
    }

    public DashStates dashstate;
    public Directions direction;
    #endregion

    public GameObject popupbutton;
    public LayerMask InteractableObject;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        dashstate = DashStates.COOLDOWN;
    }

    void Update()
    {
        movement.x = Input.GetAxis("Horizontal");
        movement.y = Input.GetAxis("Vertical");

        anim.SetFloat("Horizontal", movement.x);
        anim.SetFloat("Vertical", movement.y);
        anim.SetFloat("Speed", movement.sqrMagnitude);

        if (Input.GetButtonDown("Attack"))
        {
            //isAttacking = true;
        }

        if (Input.GetButtonUp("Attack"))
        {
            //isAttacking = true;
            Attack();
        }
        #region DashFunction

            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Directions.LEFT;
            }

            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Directions.RIGHT;
            }
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                direction = Directions.UP;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                direction = Directions.DOWN;
            }

        switch (dashstate)
        {
            case DashStates.READY :
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    dashstate = DashStates.DASH;
                }

                    break;
            case DashStates.DASH:

                timeOfDash -= Time.deltaTime;

                if(timeOfDash <= 0)
                {
                    dashstate = DashStates.COOLDOWN;
                }
                else
                {
                    if (direction == Directions.UP)
                    {
                        transform.Translate(Vector2.up * Dash_speed * Time.deltaTime);
                    }
                    else if (direction == Directions.DOWN)
                    {
                        transform.Translate(Vector2.down * Dash_speed * Time.deltaTime);
                    }
                    else if (direction == Directions.LEFT)
                    {
                        transform.Translate(Vector2.left * Dash_speed * Time.deltaTime);
                    }
                    else
                    {
                        transform.Translate(Vector2.right * Dash_speed * Time.deltaTime);
                    }
                }
                break;
            case DashStates.COOLDOWN:

                timeOfDash += Time.deltaTime;

                if(timeOfDash >= 0.8f)
                {
                    timeOfDash = 0.8f;
                    dashstate = DashStates.READY;
                }

                break;
        }

        #endregion

        Interaction();

    }

    void Attack()
    {
            Collider2D[] enemies = Physics2D.OverlapCircleAll(attackRadius.position, radius, enemyLayer);

            foreach (Collider2D item in enemies)
            {
                item.GetComponent<Enemy>().TakeDamage(damage);
            }

        print("Attacking");

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(movement.x * speed, movement.y * speed);
    }

    void Interaction()
    {
        Collider2D interact = Physics2D.OverlapCircle(transform.position, radius, InteractableObject);

        if(interact == null)
        {
            popupbutton.gameObject.SetActive(false);
        }
        else
        {
            popupbutton.gameObject.SetActive(true);
            print("Interactable object : " + interact.gameObject.name);

            if (Input.GetButtonDown("Interact"))
            {
                Destroy(interact.gameObject);
            }

        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackRadius.position, radius);
    }
}
