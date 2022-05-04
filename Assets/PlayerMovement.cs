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
    public int playerHealth = 10;
    public int maxHealth = 10;
    public GameObject ragdollPrefab;
    EnemyController Enemy;
    public Slider healthBar;
    int zombie=0;
    public Text zombies;
    public Text gameOver;
    public Button playAgain;
    public Text taptoPlay;
    public bool isGameOver = false;
    public GameObject bulletExplosion;
   // public Text youLost;
    //public AudioClip audio;
    //AudioSource audioSource;

    void Start()
    {
        characterController= GetComponent<CharacterController>();
        animator = GetComponentInChildren<Animator>();
        audio = GetComponent<AudioSource>();
        Enemy = GameObject.Find("Enemy").GetComponent<EnemyController>();
        //audio = GetComponent<AudioClip>();
       // audioSource = GetComponent<AudioSource>();
       
    }
   
    // Update is called once per frame
    void Update()
    {
        if (isGameOver == false)
        {
            float inputX = Input.GetAxis("Horizontal") * playerSpeed;        //Movement of the player in horizontal direction
            float inputZ = Input.GetAxis("Vertical") * playerSpeed;
            Vector3 movement = new Vector3(inputX * Time.deltaTime, 0f, inputZ * Time.deltaTime);
        
        healthBar.value = (float)playerHealth / 10f;

        //characterController.SimpleMove(movement*Time.deltaTime);
        animator.SetFloat("Speed", movement.magnitude);
      
       transform.Rotate(Vector3.up,inputX*rotateSpeed*Time.deltaTime);
        if(inputZ!=0)
        {
            characterController.SimpleMove(transform.forward*Time.deltaTime*inputZ);
        }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                audio.Play();
                Debug.DrawRay(bulletDirection.transform.position, transform.forward * 100, Color.red, 3f);
                RaycastHit hit;
                if (Physics.Raycast(bulletDirection.transform.position, bulletDirection.transform.forward, out hit, 100f))
                {



                    GameObject enemyhit = hit.collider.gameObject;
                    Debug.Log(enemyhit.name);
                    if (enemyhit.tag == "Enemy")
                    {
                        //enemyhit.SetActive(false);
                        // Destroy(enemyhit);
                        GameObject tempRd = enemyhit.GetComponent<EnemyController>().ragdollPrefab;

                        GameObject newTempRd = Instantiate(tempRd, enemyhit.transform.position, enemyhit.transform.rotation);

                        newTempRd.transform.Find("Hips").GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * 10000);

                        Destroy(enemyhit);
                        GameObject temp = Instantiate(bulletExplosion, enemyhit.transform.position, Quaternion.identity);
                        Destroy(temp, 0.3f);
                        zombie++;
                        zombies.text = zombie.ToString();
                        if (zombie == 6)
                        {
                            gameOver.GetComponent<Text>().enabled = true;
                            isGameOver = true;
                            playAgain.GetComponent<Image>().enabled = true;
                            // playAgain.GetComponent<Text>().enabled = true;

                            playAgain.GetComponent<Button>().enabled = true;
                            taptoPlay.GetComponent<Text>().enabled = true;
                            isGameOver = true;

                            zombie = 0;
                        }
                        // Destroy(tempRd, 3f);
                    }
                }
               /* if(playerHealth==0)
                {
                    youLost.GetComponent<Text>().enabled = true;
                   isGameOver = true;
                }*/
            }
        }
    }
   
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag=="Health"&& playerHealth<maxHealth)
        {
            playerHealth = Mathf.Clamp(playerHealth + 1, 0,maxHealth);
            collision.gameObject.SetActive(false);
            print("player Health inc:" + playerHealth);
        }
    }
}
