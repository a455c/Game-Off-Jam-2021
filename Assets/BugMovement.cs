using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private LineRenderer lr;

    public bool isGrappling = false;
    public float moveSpeed;
    public float grappleSpeed;

    // Start is called before the first frame update
    void Start()
    {
        grapplePoint.parent = null;
        shootPoint.parent = null;
        lr = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Grapple();
        Shoot();

        Vector2 vecCursor = cam.ScreenToWorldPoint(new Vector2(Input.mousePosition.x, Input.mousePosition.y));
        float cursorX = vecCursor.x;
        float cursorY = vecCursor.y;

        transform.up = new Vector3(cursorX, cursorY) - transform.position;
    }

    private void Grapple()
    {

        if (Input.GetMouseButtonDown(0))
        {          
            grapplePoint.position = cam.ScreenToWorldPoint(Input.mousePosition);
            grappleSystemPlayed = false;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, grapplePoint.position);
            isGrappling = true;
            animator.SetTrigger("Squash");
        }

        if (isGrappling)
        {
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, grapplePoint.position);
            transform.position = Vector2.MoveTowards(transform.position, grapplePoint.position, grappleSpeed * Time.deltaTime);
        }

        if(Vector2.Distance(transform.position, grapplePoint.transform.position) <= 0.05f && !grappleSystemPlayed)
        {
            isGrappling = false;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, transform.position);
            grappleLandSystem.Play();
            grappleSystemPlayed = true;
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

            StartCoroutine(DelayRaycast());
        }       
    }

    private IEnumerator DelayRaycast()
    {
        yield return new WaitForSeconds(0.02f);
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, transform.up, 100f, everythingButPlayer);
        if (hit.collider != null)
        {
            print(hit.collider.gameObject.name);
            if (hit.collider.gameObject.tag == "Switch")
            {
                // get switch to turn on
                ButtonHitScript buttonScript = hit.collider.gameObject.GetComponent<ButtonHitScript>();
                buttonScript.SwitchOn();
            }
        }
    }
}
