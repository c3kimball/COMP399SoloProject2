using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerSkeleton : MonoBehaviour
{
    public Animator anim;
    public Camera cam;
    public GameObject rightAxeCollider;
    public GameObject leftAxeCollider;
    public UIManager UI;

    private bool attacking = false;
    private float timer, attackTime = 1f, speed = 5f, camSens = 100f;
    private Vector3 movement;

    // Update is called once per frame
    void Update()
    {
        float moveH = Input.GetAxisRaw("Horizontal");
        float moveV = Input.GetAxisRaw("Vertical");

        movement = new Vector3(moveH, 0f, moveV);
        movement = transform.TransformDirection(movement.normalized * Time.deltaTime * speed);
        transform.position += movement;

        float camX = Input.GetAxisRaw("Mouse X") * camSens * Time.deltaTime;
        Vector3 rotate = new Vector3(0, camX, 0);
        transform.Rotate(rotate);

        if(moveH != 0f || moveV != 0f)
        {
            anim.SetBool("Walk", true);
            anim.SetBool("Idle", false);
        }
        else
        {
            anim.SetBool("Walk", false);
            anim.SetBool("Idle", true);
        }

        if(Input.GetMouseButtonDown(0) && Time.timeScale == 1)
        {
            anim.SetTrigger("Attack1");
            attacking = true;
           rightAxeCollider.SetActive(true);
            timer = 0;
        }
        if (Input.GetMouseButtonDown(1) && Time.timeScale == 1)
        {
            anim.SetTrigger("Attack2");
            attacking = true;
            leftAxeCollider.SetActive(true);
            timer = 0;
        }

        if(attacking && Time.timeScale == 1)
        {
            if(timer >= attackTime)
            {
                attacking = false;
                rightAxeCollider.SetActive (false);
            }
            else
            {
                timer += Time.deltaTime;
            }
        }

    }
}
