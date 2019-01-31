using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ballScript : MonoBehaviour {

    public static bool isDead;
    public static bool isPlaying = true;
    public static bool firstClick = false;

    private bool firstBallGo = false;
    private bool firstStart = true;
    private bool waitIsOver = false;
    private int ballSpeed = -12;
    private int ballHeight = 9;
    private Vector3 originalPos;
    private GameObject childBall;
    private Rigidbody ballRigidBody;

    public int score = 0;
    private int totalCoins;
    private int highScore;
    private int coinsAddedThisRound = 0;
    public int upOrDown;
    public GameObject ball;
    public GameObject player;
    public GameObject divider;
    public Image jumpTut;
    public Image crouchTut;
    public GameObject deathUI;
    public Text scoreText;
    public Text coinsText;
    public Text highScoreText;
    private Animator deathUIAnimator;
    public Animator goalieAnimator;
    public Animator goalie2Animator;
    public ParticleSystem playerParticle;


    void Start () {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        ballRigidBody = GetComponent<Rigidbody>();
        deathUIAnimator = deathUI.GetComponent<Animator>();
        childBall = ball.transform.GetChild(0).gameObject;
        InitializeScene();
    }

    void Update()
    {
        scoreText.text = score.ToString();
        if(firstClick == true && firstStart == true)
        {
            StartCoroutine("countdown");
            firstStart = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goalie1")
        {
            goalieAnimator.SetTrigger("hitGoalie");
            upOrDown = Random.Range(1, 3);
            ballSpeed = -12;
            score += 1;
            coinsAddedThisRound += 1;
            if(upOrDown == 1)
            {
                goBall();
            }
            else
            {
                goBallUp();
            }
        }
        else if(collision.gameObject.tag == "Goalie2")
        {
            goalie2Animator.SetTrigger("Goalie2Hit");
            upOrDown = Random.Range(1, 3);
            ballSpeed = 12;
            score += 1;
            coinsAddedThisRound += 1;
            if (upOrDown == 1)
            {
                goBall();
            }
            else
            {
                goBallUp();
            }
        }
        else if(collision.gameObject.tag == "User")
        {
            playerParticle.Play();
            player.SetActive(false);
            deathUIAnimator.SetBool("Died", true);
            ballRigidBody.velocity = Vector3.zero;
            childBall.GetComponent<Renderer>().enabled = false;
            isDead = true;
            isPlaying = false;
            waitIsOver = false;
            gameObject.transform.position = originalPos;
            deathUI.SetActive(true);
            ballRigidBody.isKinematic = true;
            totalCoins += coinsAddedThisRound;
            PlayerPrefs.SetInt("Coins", totalCoins);
            if(score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            StartCoroutine("addCoins");
        }
    }

    IEnumerator countdown()
    {
        var num = ball;
        GameObject clone;
        num = Resources.Load("3", typeof(GameObject)) as GameObject;
        clone = Instantiate(num, new Vector3(141.84f, -25.5f, 57.1f), Quaternion.Euler(new Vector3(0, 270, 0)));
        yield return new WaitForSeconds(1);
        Destroy(clone);
        num = Resources.Load("2", typeof(GameObject)) as GameObject;
        clone = Instantiate(num, new Vector3(141.84f, -25.5f, 57.1f), Quaternion.Euler(new Vector3(0, 270, 0)));
        yield return new WaitForSeconds(1);
        Destroy(clone);
        num = Resources.Load("1", typeof(GameObject)) as GameObject;
        clone = Instantiate(num, new Vector3(141.84f, -25.5f, 57.1f), Quaternion.Euler(new Vector3(0, 270, 0)));
        yield return new WaitForSeconds(1);
        Destroy(clone);

        waitIsOver = true;
        divider.SetActive(false);
        jumpTut.enabled = false;
        crouchTut.enabled = false;
        highScoreText.enabled = false;
    }

    IEnumerator addCoins()
    {
        totalCoins -= coinsAddedThisRound;
        for (int i = 0; i <= coinsAddedThisRound; i++)
        {
            yield return new WaitForSeconds(0.1f);
            coinsText.text = totalCoins.ToString();
            totalCoins++;
        }


    }

    public void InitializeScene()
    {
        resetBallPosition();
        childBall.GetComponent<Renderer>().enabled = true;
        isDead = false;
        firstBallGo = true;
        firstStart = true;
        firstClick = false;
        ballSpeed = -12;
        score = 0;
        coinsAddedThisRound = 0;
        totalCoins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = totalCoins.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best " + highScore.ToString();
        isPlaying = true;
    }

    void goBall()
    {
        ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, ballRigidBody.velocity.y, ballSpeed);
    }

    void goBallUp()
    {
        ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, ballHeight, ballSpeed);
    }

    private void FixedUpdate()
    {
        if (waitIsOver == true)
        {
            var velocity = ballRigidBody.velocity;
            velocity.z = ballSpeed;
            ballRigidBody.velocity = velocity;
            if(firstBallGo == true)
            {
                goBall();
                firstBallGo = false;
            }
        }
    }

    private void resetBallPosition()
    {
        ballRigidBody.velocity = new Vector3(0f, 0f, 0f);
        ballRigidBody.angularVelocity = new Vector3(0f, 0f, 0f);
        ballRigidBody.transform.position = originalPos;
    }
}
