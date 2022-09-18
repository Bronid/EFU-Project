using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private CapsuleCollider col;
    private Vector3 dir;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private float gravity;
    [SerializeField] private GameObject LosePanel;
    [SerializeField] private GameObject MusicPanel;



    private int lineToMove = 1;
    public float lineDistance = 4;
    private float maxSpeed = 45;

    private void Jump()
    {
        dir.y = jumpForce;
    }

    void Start()
    {
        controller = GetComponent<CharacterController>();
        col = GetComponent<CapsuleCollider>();
        Time.timeScale = 1;
        //StartCoroutine(SpeedIncrease());
    }

    // Update is called once per frame
    void Update()
    {
        if (SwipeController.swipeRight)
        {
            if (lineToMove < 2) lineToMove++;
        }

        if (SwipeController.swipeLeft)
        {
            if (lineToMove > 0) lineToMove--;
        }

        if (SwipeController.swipeUp)
        {
            if (controller.isGrounded) dir.y = jumpForce;
        }

        if (SwipeController.swipeDown)
        {
            StartCoroutine(Slide());
        }


        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;
        if (lineToMove == 0) targetPosition += Vector3.left * lineDistance;
        else if (lineToMove == 2) targetPosition += Vector3.right * lineDistance;

        if (transform.position == targetPosition)
            return;
        Vector3 diff = targetPosition - transform.position;
        Vector3 moveDir = diff.normalized * 25 * Time.deltaTime;
        if (moveDir.sqrMagnitude < diff.sqrMagnitude)
            controller.Move(moveDir);
        else
            controller.Move(diff);
    }

    void FixedUpdate()
    {
        dir.z = speed;
        dir.y += gravity * Time.fixedDeltaTime;
        controller.Move(dir * Time.fixedDeltaTime);
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.tag == "death")
        {
            LosePanel.SetActive(true);
            MusicPanel.SetActive(false);
            Time.timeScale = 0;
        }
    }
    /*
    private IEnumerator SpeedIncrease()
    {
        yield return new WaitForSeconds(5);
        if(speed < maxSpeed)
        {
            speed += 1;
            StartCoroutine(SpeedIncrease());
        }
    }
    */
    private IEnumerator Slide()
        {
            col.center = new Vector3(-0.007222801f, 1.309283f, 0);
            col.height = 0.4523649f;
            dir.y -= jumpForce * 2;



            yield return new WaitForSeconds(1);

            col.center = new Vector3(-0.007222801f, 1.844699f, 0);
            col.height = 1.523198f;
        }
}
