 using UnityEngine;
using SceneManager= UnityEngine.SceneManagement.SceneManager;
using System.Collections;
using System;

public class playercontorol : MonoBehaviour
{
    public AudioClip FlyClip;
    public AudioClip HitCLip;
    
    private AudioSource audioSource;


    private const string addscoretag = "addscore";
    private const string Deadstate = "Dead";
    private float gravityvalue;
    [SerializeField] float gravityspeed = 50;
    [SerializeField] float jumpvalue = 20;
    [SerializeField] float firstjumpvalue = 30;
    [SerializeField] float limitscreen = 5;

    [SerializeField] float fallingspeed = 6;

    private bool Gameover;

    private Animator animator;

    private Transform tr;
    private int score;

    private bool plyaed;
    private void Awake()
    {// get component //
        tr = transform;
        animator = GetComponent<Animator>();
        audioSource = tr.GetComponent<AudioSource>();
        audioSource.clip = FlyClip;
    }
    private void Update()
    {
        // if game over true reset the game and update it //
        if (Gameover)
        {
            
             if (Input.anyKeyDown)
            {
                Time.timeScale=1;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            return;
        }
        if (!plyaed)// if we didnt press any key dont play //
        {
            if (Input.anyKeyDown)// if we press key start game //
            {
                audioSource.Play();
                plyaed = true;
                ObstacleSoawner.Instance.playing = true;
                gravityvalue -= firstjumpvalue; //jumping //
                UlManeger.Instance.PlayGame();
            }
            return;
        }
        gravityvalue += gravityspeed * Time.deltaTime;
        tr.position += Vector3.down * gravityvalue * Time.deltaTime;// virus go down //
        if (Input.anyKeyDown)
        {
            audioSource.Play();
            gravityvalue = -jumpvalue;// if you pres key virus go up //
        }
        if (tr.position.y > limitscreen || tr.position.y < -limitscreen)// if virus go out of screen retunr game //

            OutofScreenDanger();
    }

    private void OutofScreenDanger()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        UlManeger.Instance.GameOver();

    }
    private System.Collections.IEnumerator DoGameOver()
    {
        // if the virus go into the obstacelss show the game over  //
        audioSource.clip = HitCLip;
        audioSource.Play();
        animator.Play(Deadstate);

        Time.timeScale = 0;
        plyaed = false;
        ObstacleSoawner.Instance.playing = false;
        // when the virus dead with 1 second and come down  //
        yield return new WaitForSecondsRealtime(1);

        UlManeger.Instance.GameOver();
      
        float fallingTime = 2;

        while(fallingTime>0)
        {
            audioSource.clip = HitCLip;
            audioSource.Play();
            animator.Play(Deadstate);
            fallingTime -= Time.unscaledDeltaTime;
            tr.position += Vector3.down * fallingspeed * Time.unscaledDeltaTime;
            yield return new WaitForEndOfFrame();

        }
        Gameover = true;
       
    }
    private void OnTriggerEnter2D(Collider2D colidor)
    {    if (!plyaed) return;
       
        if (colidor.tag == Obstacelcontoroll.Tag)
           StartCoroutine(DoGameOver());
        // add score //
        if (colidor.tag == addscoretag)
            Gamemaneger.Instance.addscore();
    }
}