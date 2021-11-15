using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class BugMovement : MonoBehaviour
{
    public Transform grapplePoint;
    public Transform shootPoint;

    public Camera cam;

    public Animator animator;

    public GameObject bulletPrefab;
    public Transform gunTip;

    public LayerMask everythingButPlayer;

    public ParticleSystem grappleLandSystem;
    private bool grappleSystemPlayed = true;
    public ParticleSystem muzzleShootSystem;

    public AudioSource grappleAudio;
    public AudioSource grappleReachedAudio;
    bool grappleReachedAudioPlayed = false;

    private LineRenderer lr;

    public bool isGrappling = false;
    public float moveSpeed;
    public float grappleSpeed;

    public float maxHealth;
    public float currentHealth;

    public float currentScore;


    public Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        grapplePoint.parent = null;
        shootPoint.parent = null;
        lr = GetComponent<LineRenderer>();
        currentHealth = maxHealth;
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Grapple();
        Shoot();
        SloMo();

        Vector2 vecCursor = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        float cursorX = vecCursor.x;
        float cursorY = vecCursor.y;

        transform.up = new Vector3(cursorX, cursorY) - transform.position;

        if(currentHealth <= 0)
        {
            print("dead");
        }
        scoreText.text = System.Convert.ToString(currentScore);
    }

    private void Grapple()
    {

        if (Input.GetMouseButtonDown(0))
        {          
            grapplePoint.position = cam.ScreenToWorldPoint(Input.mousePosition);
            grappleSystemPlayed = false;
            grappleReachedAudioPlayed = false;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, grapplePoint.position);
            isGrappling = true;
            animator.SetTrigger("Squash");
            grappleAudio.Play();
        }

        if (isGrappling)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, grapplePoint.position);
            transform.position = Vector2.MoveTowards(transform.position, grapplePoint.position, grappleSpeed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, grapplePoint.transform.position) <= 0.05f && !grappleSystemPlayed && !grappleReachedAudioPlayed)
        {
            isGrappling = false;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position);
            grappleLandSystem.Play();
            grappleSystemPlayed = true;
            grappleReachedAudio.Play();
            grappleReachedAudioPlayed = true;
        }
    }

    private void Shoot()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject clone = Instantiate(bulletPrefab, gunTip.position, gunTip.rotation);
            clone.SetActive(true);

            muzzleShootSystem.Play();

            animator.SetTrigger("Stretch");
        }       
    }

    private void SloMo()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Time.timeScale = 0.25f;

        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Time.timeScale = 1f;
        }
    }
    public void TakeDamage(float dmg)
    {
        currentHealth -= dmg;
    }
}
