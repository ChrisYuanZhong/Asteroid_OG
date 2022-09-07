using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aiming : MonoBehaviour
{
    public Camera cam;
    private Vector2 lookDir;
    private float angle;
    public Bullet bulletPrefab;
    public bool buff = false;

    public int pelletNumber = 3;
    public float spread = 30;


    Vector3 mousePos;

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        lookDir = (mousePos - transform.position).normalized;
        angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90.0f;
        transform.eulerAngles = new Vector3(0, 0, angle);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        if (buff)
        {
            float startRotation = angle + spread / 2f;
            float angleIncrease = spread / ((float)pelletNumber - 1f);

            for (int i = 0; i < pelletNumber; i++)
            {
                float tempRotation = startRotation + angleIncrease * i - spread;
                Bullet bullet = Instantiate(bulletPrefab, transform.position, Quaternion.Euler(0f, 0f, tempRotation));
                bullet.Project(bullet.transform.up);

                /*switch (i)
                {
                    case 0:
                        bullet.Project(this.transform.up + new Vector3(0f, -90f, 0f));
                        break;
                    case 1:
                        bullet.Project(this.transform.up + new Vector3(0f, 0f, 0f));
                        break;
                    case 2:
                        bullet.Project(this.transform.up + new Vector3(0f, 90f, 0f));
                        break;

                }*/
            }
        }
        else
        {

            Bullet bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
            bullet.Project(this.transform.up);
        }
    }
}
