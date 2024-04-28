using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    float xInput;
    float yInput;
    int hitsNr = 0;
    public int coinNr;
    public GameObject winText;

    public AudioSource src;
    public AudioClip sound1;

    public TextMeshProUGUI scoreUI;
    private int scoreNr = 0;

    // private float time1;

    void Start()  
    {
      //  time1 = Time.time;
    }


    private void Awake()
    {
        rb= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -5f)
            SceneManager.LoadScene("Game");
    }

    private void FixedUpdate()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis ("Vertical");

        rb.AddForce(xInput * speed, 0, yInput * speed);


    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Coin")
        {
            src.clip= sound1;
            src.Play();

            other.gameObject.SetActive(false);
            hitsNr++;

            // int timeScore = ((int)(time1 - Time.time)/2);
            // time1 = Time.time;
            scoreNr = hitsNr * 10; //+ timescore
            scoreUI.text = "Score: " + scoreNr.ToString();

            if(hitsNr >= coinNr)
            {
                winText.SetActive(true);
            }
        }
    }
}
