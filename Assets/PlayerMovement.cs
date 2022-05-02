using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    AudioSource audio;
    // Start is called before the first frame update
    public float playerSpeed;
    public GameObject bulletDirection;
    CharacterController characterController;
    Animator animator;
    public float rotateSpeed;
    public Slider healthBar;
    int playerHealth = 10;
    int maxHealth = 10;
    //public AudioClip audio;
    //AudioSource audioSource;

    void Start()
    {
        characterController= GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        audio = GetComponent<AudioSource>();
        //audio = GetComponent<AudioClip>();
       // audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        float inputX=Input.GetAxis("Horizontal")*playerSpeed;        //Movement of the player in horizontal direction
        float inputZ = Input.GetAxis("Vertical")*playerSpeed;
        Vector3 movement = new Vector3(inputX*Time.deltaTime, 0f, inputZ*Time.deltaTime);

   
        //characterController.SimpleMove(movement*Time.deltaTime);
        animator.SetFloat("Speed", movement.magnitude);
       /* if (movement.magnitude > 0f)
        {
            Quaternion tempDirection = Quaternion.LookRotation(movement);
            transform.rotation = Quaternion.Slerp(transform.rotation, tempDirection, Time.deltaTime * rotateSpeed);
        }*/
       transform.Rotate(Vector3.up,inputX*rotateSpeed*Time.deltaTime);
        if(inputZ!=0)
        {
            characterController.SimpleMove(transform.forward*Time.deltaTime*inputZ);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            audio.Play();
          
            RaycastHit hit;
            if (Physics.Raycast(bulletDirection.transform.position, bulletDirection.transform.forward, out hit, 20f))
            {
                Debug.Log("Enemy RaycastHit");
                GameObject enemyhit = hit.collider.gameObject;
                if (enemyhit.tag == "Enemy")
                {
                    //enemyhit.SetActive(false);
                    Destroy(enemyhit);
                }
            }
        }
    }
    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            playerHealth--;
            collision.gameObject.SetActive(false);
            print("player Health Dec:" + playerHealth);

        }
        if (collision.gameObject.tag == "Health" && playerHealth < maxHealth)
        {
            playerHealth = Mathf.Clamp(playerHealth + 1, 0, maxHealth);
            collision.gameObject.SetActive(false);
            print("player Health inc:" + playerHealth);
        }
    }
}
