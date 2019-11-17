using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed = 5f;
    public float rotate_Speed = 50f;

    public bool canShoot;
    public bool canRotate;
    private bool canMove = true;

    // Use to manage game bounds of enemy objects 
    public float bound_X = -11f;

    public Transform attack_Point;
    public GameObject bulletPrefab;

    private Animator anim;
    private AudioSource explosionSound; 

    void Awake()
    {
        anim = GetComponent<Animator>();
        explosionSound = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        Move();
        RotateEnemy();
    }

    void Start()
    {
        //Randomise enemy rotations
        if(canRotate)
        {
            if(Random.Range(0,2) > 0)
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
                rotate_Speed *= -1f;
            }
            else
            {
                rotate_Speed = Random.Range(rotate_Speed, rotate_Speed + 20f);
            }
        }
        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f));

    }

    void Move()
    {
        if(canMove)
        {
            //done to move from the opposite direction of the main player (-=)
            Vector3 temp = transform.position;
            temp.x -= speed * Time.deltaTime;
            transform.position = temp; 

            //Done to deactivate game object 
            if (temp.x < bound_X)
            {
                gameObject.SetActive(false);
            }
        }
    }//move 

    void RotateEnemy()
    {
        if(canRotate)
        {
            transform.Rotate(new Vector3(0f, 0f, rotate_Speed * Time.deltaTime), Space.World);
        }
    }

    void StartShooting()
    {
        GameObject bullet = Instantiate(bulletPrefab, attack_Point.position, Quaternion.identity);
        bullet.GetComponent<BulletScript>().is_EnemyBullet = true;

        if (canShoot)
            Invoke("StartShooting", Random.Range(1f, 3f)); 
    }

}// class
