using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public float speed;

    private Rigidbody rb;

    bool isGrounded;

    public AudioSource pickupsound;

    private int Count;

    public Text countText;

    public Text WinText;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        pickupsound = GetComponent<AudioSource>();
        Count = 0;
        SetCountText();
        WinText.text = "";
     }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        GetComponent<Rigidbody>().AddForce(movement * speed);

     
        
        

        if (Input.GetKeyDown (KeyCode.Space) && isGrounded)
        {
            Vector3 jump = new Vector3(0.0f, 300.0f, 0.0f);

            GetComponent<Rigidbody>().AddForce(jump);
        }
     }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) ;
        {
           isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Floor")) ;
        {
           isGrounded = false;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag ("Pick Up"))
        {
            pickupsound.Play();
            other.gameObject.SetActive(false);
            Count = Count + 1;
            SetCountText();
        }
    }

    void SetCountText ()
    {
        countText.text = "Count:" + Count.ToString();
        if (Count >= 12)
        {
            WinText.text = "You Win!";
        }
    }
}
