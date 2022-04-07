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
    [SerializeField]GameObject[] rooms;
    int roomNumber;
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
        if (other.tag == "border")
        {
            if (trash.activeSelf)
            { 
                roomNumber++;
                for (int i = 0; i < rooms.Length; i++)
                {
                    rooms[i].SetActive(false);
                }
                rooms[roomNumber].SetActive(true);
                camera.position = new Vector3 (camera.position.x + 842, camera.position.y, camera.position.z);
                transform.position = new Vector3(transform.position.x + 100, transform.position.y, transform.position.z);
            }
        }
        if (other.tag == "fishCar")
        {
             roomNumber = 0;
             for (int i = 0; i < rooms.Length; i++)
                {
                    rooms[i].SetActive(false);
                }
                rooms[roomNumber].SetActive(true);
             camera.localPosition = new Vector3 (0.2f, camera.localPosition.y, camera.localPosition.z);
            transform.localPosition = new Vector3(-49.16f, 45.2f, transform.localPosition.z);

        }
    }
}
