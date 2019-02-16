using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ballScript : MonoBehaviour {

    public static bool firstClick = false;

    private bool firstStart = true;
    private bool waitIsOver = false;
    private int ballSpeed = -12;
    private int ballHeight = 9;
    private GameObject childBall;
    private Rigidbody ballRigidBody;
    private GameObject modelToLoad;
    private GameObject modelClone;

    public int score = 0;
    private int totalCoins;
    private int highScore;
    private int coinsAddedThisRound = 0;
    private int characterIndex;
    private Vector3 playerStartPosition = new Vector3(141.84f, -27.101f, 57.08f);
    public int upOrDown;
    public GameObject ball;
    public GameObject player;
    public GameObject deathUI;
    public GameObject mainUI;
    public GameObject temporaryStartMenu;
    public Text scoreText;
    public Text coinsText;
    public Text highScoreText;
    private Animator deathUIAnimator;
    public Animator goalieAnimator;
    public Animator goalie2Animator;
    public ParticleSystem playerDeathParticles;


    void Start () {
        characterIndex = PlayerPrefs.GetInt("characterIndex", 1);
        SelectCharacterToLoad();
        modelClone = Instantiate(modelToLoad, playerStartPosition, Quaternion.Euler(new Vector3(0, 270, 0)));
        ballRigidBody = GetComponent<Rigidbody>();
        deathUIAnimator = deathUI.GetComponent<Animator>();
        childBall = ball.transform.GetChild(0).gameObject;
        InitializeScene();
    }

    void Update()
    {
        if(firstClick && firstStart)
        {
            temporaryStartMenu.SetActive(false);
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
            scoreText.text = score.ToString();
            coinsAddedThisRound += 1;
            ChooseIfBallGoesUpOrDown();
        }
        else if(collision.gameObject.tag == "Goalie2")
        {
            goalie2Animator.SetTrigger("Goalie2Hit");
            upOrDown = Random.Range(1, 3);
            ballSpeed = 12;
            score += 1;
            scoreText.text = score.ToString();
            coinsAddedThisRound += 1;
            ChooseIfBallGoesUpOrDown();
        }
        else if(collision.gameObject.tag == "User")
        {
            playerDeathParticles.Play();
            Destroy(modelClone);
            deathUIAnimator.SetBool("Died", true);
            ballRigidBody.velocity = Vector3.zero;
            childBall.GetComponent<Renderer>().enabled = false;
            waitIsOver = false;
            deathUI.SetActive(true);
            ballRigidBody.isKinematic = true;
            UpdatePlayersCoins();
            CheckForAndSetHighScore();
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
        mainUI.SetActive(false);
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
        childBall.GetComponent<Renderer>().enabled = true;
        firstStart = true;
        firstClick = false;
        ballSpeed = -12;
        score = 0;
        scoreText.text = score.ToString();
        coinsAddedThisRound = 0;
        totalCoins = PlayerPrefs.GetInt("Coins", 0);
        coinsText.text = totalCoins.ToString();
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        highScoreText.text = "Best " + highScore.ToString();
    }

    void KickBallStraight()
    {
        ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, ballRigidBody.velocity.y, ballSpeed);
    }

    void KickBallUp()
    {
        ballRigidBody.velocity = new Vector3(ballRigidBody.velocity.x, ballHeight, ballSpeed);
    }

    private void FixedUpdate()
    {
        if (waitIsOver)
        {
            var velocity = ballRigidBody.velocity;
            velocity.z = ballSpeed;
            ballRigidBody.velocity = velocity;
            KickBallStraight();
        }
    }

    private void CheckForAndSetHighScore()
    {
        if(score > highScore)
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
    }

    private void ChooseIfBallGoesUpOrDown()
    {
        if (upOrDown == 1)
        {
            KickBallStraight();
        }
        else
        {
            KickBallUp();
        }
    }

    private void UpdatePlayersCoins()
    {
        totalCoins += coinsAddedThisRound;
        PlayerPrefs.SetInt("Coins", totalCoins);
    }

    private void SelectCharacterToLoad()
    {
        switch(characterIndex)
        {
            case 1:
                modelToLoad = Resources.Load("PlayerLoad", typeof(GameObject)) as GameObject;
                break;
            case 2:
                modelToLoad = Resources.Load("Player2Load", typeof(GameObject)) as GameObject;
                break;
            case 3:
                modelToLoad = Resources.Load("Player3Load", typeof(GameObject)) as GameObject;
                break;
            case 4:
                modelToLoad = Resources.Load("Player4Load", typeof(GameObject)) as GameObject;
                break;
            case 5:
                modelToLoad = Resources.Load("Player5Load", typeof(GameObject)) as GameObject;
                break;
        }
    }
}
