using UnityEngine;

public class Player : MonoBehaviour
{
    //public Bullet bulletPrefab;

    public float thrustSpeed = 1.0f;


    private Rigidbody2D _rigidbody;
 
    private bool _goingUp;
    private bool _goingDown;
    private bool _goingLeft;
    private bool _goingRight;


    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _goingUp = Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow);
        _goingDown = Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow);
        _goingLeft = Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow);
        _goingRight = Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow);

        /*if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }*/
    }


    private void FixedUpdate()
    {
        if (_goingUp)
        {
            _rigidbody.AddForce(this.transform.up * this.thrustSpeed);
        }
        if (_goingDown)
        {
            _rigidbody.AddForce(-this.transform.up * this.thrustSpeed);
        }
        if (_goingLeft)
        {
            _rigidbody.AddForce(-this.transform.right * this.thrustSpeed);
        }
        if (_goingRight)
        {
            _rigidbody.AddForce(this.transform.right * this.thrustSpeed);
        }
    }

    /*private void Shoot()
    {
        Bullet bullet = Instantiate(this.bulletPrefab, this.transform.position, this.transform.rotation);
        bullet.Project(this.transform.up);
    }*/

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Asteroid")
        {
            _rigidbody.velocity = Vector3.zero;
            _rigidbody.angularVelocity = 0.0f;

            this.gameObject.SetActive(false);

            FindObjectOfType<GameManager>().PlayerDied();
        }
    }
}
