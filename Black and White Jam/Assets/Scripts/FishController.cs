using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    [SerializeField]SpriteRenderer spriteRenderer;
    [SerializeField]Animator animator;

    [SerializeField]Vector2 movement;
    [SerializeField]GameObject trash;
    [SerializeField]GameObject trashFish;
    [SerializeField]GameObject trashText;
    [SerializeField]Transform camera;
    [SerializeField]float[] xLimits;
    [SerializeField]float[] xPos;
    [SerializeField]int limit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.x < 0 )
        {
            spriteRenderer.flipX = true;
        }
        else if (movement.x> 0)
        {
            spriteRenderer.flipX = false;
        }
        if (movement.x != 0 || movement.y != 0)
        {
            animator.SetBool("isMoving", true);
        }
        else
        {
            animator.SetBool("isMoving", false);
        }

        if (xLimits[limit] < transform.position.x)
        {
            if (camera.position != new Vector3 (xPos[limit + 1], camera.position.y, camera.position.z))
            {
                limit++;
                camera.position = new Vector3 (xPos[limit], camera.position.y, camera.position.z);
            }
        }
        if (xLimits[limit - 1] > transform.position.x)
        {
            if (camera.position != new Vector3 (xPos[limit - 1 ], camera.position.y, camera.position.z))
            {
                limit--;
                camera.position = new Vector3 (xPos[limit], camera.position.y, camera.position.z);
            }
        }

        
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement.normalized * moveSpeed * Time.fixedDeltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "trash")
        {
            trashFish.SetActive(false);
            trashText.SetActive(false);
            trash.SetActive(true);
        }
    }
    
}
