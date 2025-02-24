﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms;


public class ballScript : MonoBehaviour {

    public static bool firstClick = false;

    private bool firstStart = true;
    private bool waitIsOver = false;
    private bool firstHighScore;
    private int ballSpeed = -12;
    private int ballHeight = 9;
    private int totalCoins;
    private int doubleRewardRand;
    private int highScore;
    private int characterIndex;
    private long scoreForLeaderboard;
    private GameObject childBall;
    private GameObject modelToLoad;
    private GameObject modelClone;
    private Rigidbody ballRigidBody;
    private Animator deathUIAnimator;
    private Vector3 playerStartPosition = new Vector3(141.84f, -27.101f, 57.08f);

    public static int coinsAddedThisRound = 0;
    public int score = 0;
    public int upOrDown;
    public GameObject ball;
    public GameObject player;
    public GameObject deathUI;
    public GameObject mainUI;
    public AudioSource Go;
    public AudioSource coinAddSound;
    public AudioSource countdownSound;
    public AudioSource scoreSound;
    public AudioSource deathSound;
    public Button leaderboardButton;
    public Button characterSelectionButton;
    public Text scoreText;
    public Text coinsText;
    public Text highScoreText;
    public Text newBestText;
    public Animator deathAdUIAnimator;
    public Animator doubleRewardAnimator;
    public Animator goalieAnimator;
    public Animator goalie2Animator;
    public Animator giftUIAnimator;
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
            leaderboardButton.gameObject.SetActive(false);
            characterSelectionButton.gameObject.SetActive(false);
            highScoreText.enabled = false;
            StartCoroutine("countdown");
            firstStart = false;
        }
        if(score > highScore && firstHighScore == true)
        {
            StartCoroutine("FlashText");
            firstHighScore = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Goalie1")
        {
            PlayScoreSound();
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
            PlayScoreSound();
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
            PlayDeathSound();
            playerDeathParticles.Play();
            Destroy(modelClone);
            deathUIAnimator.SetBool("Died", true);
            deathAdUIAnimator.SetBool("Died", true);
            if(doubleRewardRand == 15)
            {
                doubleRewardAnimator.SetBool("isShowing", true);
            }
            ballRigidBody.velocity = Vector3.zero;
            childBall.GetComponent<Renderer>().enabled = false;
            waitIsOver = false;
            CheckIfGiftShouldShow();
            deathUI.SetActive(true);
            ballRigidBody.isKinematic = true;
            UpdatePlayersCoins();
            CheckForAndSetHighScore();
            if(score > 0)
            {
                StartCoroutine("addCoins");
            }
        }
    }

    IEnumerator countdown()
    {
        var num = ball;
        GameObject clone;
        num = Resources.Load("3", typeof(GameObject)) as GameObject;
        clone = Instantiate(num, new Vector3(141.84f, -25.5f, 57.1f), Quaternion.Euler(new Vector3(0, 270, 0)));
        countdownSound.Play();
        yield return new WaitForSeconds(1);
        Destroy(clone);
        num = Resources.Load("2", typeof(GameObject)) as GameObject;
        clone = Instantiate(num, new Vector3(141.84f, -25.5f, 57.1f), Quaternion.Euler(new Vector3(0, 270, 0)));
        countdownSound.Play();
        yield return new WaitForSeconds(1);
        Destroy(clone);
        num = Resources.Load("1", typeof(GameObject)) as GameObject;
        clone = Instantiate(num, new Vector3(141.84f, -25.5f, 57.1f), Quaternion.Euler(new Vector3(0, 270, 0)));
        countdownSound.Play();
        yield return new WaitForSeconds(1);
        Go.Play();
        Destroy(clone);

        waitIsOver = true;
        mainUI.SetActive(false);
    }

    IEnumerator FlashText()
    {
        newBestText.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        newBestText.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        newBestText.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        newBestText.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        newBestText.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        newBestText.gameObject.SetActive(false);
        yield return new WaitForSeconds(.5f);
        newBestText.gameObject.SetActive(true);
        yield return new WaitForSeconds(.5f);
        newBestText.gameObject.SetActive(false);
    }

    IEnumerator addCoins()
    {
        yield return new WaitForSeconds(1.5f);
        totalCoins -= coinsAddedThisRound;
        for (int i = 0; i <= coinsAddedThisRound; i++)
        {
            yield return new WaitForSeconds(0.03f);
            coinAddSound.Play();
            coinsText.text = totalCoins.ToString();
            totalCoins++;
        }
    }

    public void InitializeScene()
    {
        scoreForLeaderboard = 0;
        childBall.GetComponent<Renderer>().enabled = true;
        firstStart = true;
        firstClick = false;
        firstHighScore = true;
        ballSpeed = -12;
        doubleRewardRand = Random.Range(0, 25);
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
        if (score > highScore)
        {
            PlayerPrefs.SetInt("HighScore", score);
            scoreForLeaderboard = score;
#if UNITY_IOS
            reportScoresToLeaderboardsIOS();
#endif
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

    private void PlayScoreSound()
    {
        scoreSound.Play();
    }

    private void PlayDeathSound()
    {
        deathSound.Play();
    }

    private void UpdatePlayersCoins()
    {
        totalCoins += coinsAddedThisRound;
        PlayerPrefs.SetInt("Coins", totalCoins);
    }

    private void reportScoresToLeaderboardsIOS()
    {
        Social.ReportScore(scoreForLeaderboard, "Daily_Leaderboard", success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
        Social.ReportScore(scoreForLeaderboard, "Weekly_Leaderboard", success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
        Social.ReportScore(scoreForLeaderboard, "All_Time_Leaderboard", success => {
            Debug.Log(success ? "Reported score successfully" : "Failed to report score");
        });
    }

    private void CheckIfGiftShouldShow()
    {
        if(FreeGift.rand == 25)
        {
            giftUIAnimator.SetBool("isShowing", true);
        }
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
            case 6:
                modelToLoad = Resources.Load("Player6Load", typeof(GameObject)) as GameObject;
                break;
            case 7:
                modelToLoad = Resources.Load("Player7Load", typeof(GameObject)) as GameObject;
                break;
            case 8:
                modelToLoad = Resources.Load("Player8Load", typeof(GameObject)) as GameObject;
                break;
            case 9:
                modelToLoad = Resources.Load("Player9Load", typeof(GameObject)) as GameObject;
                break;
            case 10:
                modelToLoad = Resources.Load("Player10Load", typeof(GameObject)) as GameObject;
                break;
            case 11:
                modelToLoad = Resources.Load("Player11Load", typeof(GameObject)) as GameObject;
                break;
            case 12:
                modelToLoad = Resources.Load("Player12Load", typeof(GameObject)) as GameObject;
                break;
            case 13:
                modelToLoad = Resources.Load("Player13Load", typeof(GameObject)) as GameObject;
                break;
            case 14:
                modelToLoad = Resources.Load("Player14Load", typeof(GameObject)) as GameObject;
                break;
            case 15:
                modelToLoad = Resources.Load("Player15Load", typeof(GameObject)) as GameObject;
                break;
            case 16:
                modelToLoad = Resources.Load("Player16Load", typeof(GameObject)) as GameObject;
                break;
            case 17:
                modelToLoad = Resources.Load("Player17Load", typeof(GameObject)) as GameObject;
                break;
            case 18:
                modelToLoad = Resources.Load("Player18Load", typeof(GameObject)) as GameObject;
                break;
            case 19:
                modelToLoad = Resources.Load("Player19Load", typeof(GameObject)) as GameObject;
                break;
            case 20:
                modelToLoad = Resources.Load("Player20Load", typeof(GameObject)) as GameObject;
                break;
            case 21:
                modelToLoad = Resources.Load("Player21Load", typeof(GameObject)) as GameObject;
                break;
            case 22:
                modelToLoad = Resources.Load("Player22Load", typeof(GameObject)) as GameObject;
                break;
            case 23:
                modelToLoad = Resources.Load("Player23Load", typeof(GameObject)) as GameObject;
                break;
            case 24:
                modelToLoad = Resources.Load("Player24Load", typeof(GameObject)) as GameObject;
                break;
            case 25:
                modelToLoad = Resources.Load("Player25Load", typeof(GameObject)) as GameObject;
                break;
            case 26:
                modelToLoad = Resources.Load("Player26Load", typeof(GameObject)) as GameObject;
                break;
            case 27:
                modelToLoad = Resources.Load("Player27Load", typeof(GameObject)) as GameObject;
                break;
            case 28:
                modelToLoad = Resources.Load("Player28Load", typeof(GameObject)) as GameObject;
                break;
        }
    }
}
