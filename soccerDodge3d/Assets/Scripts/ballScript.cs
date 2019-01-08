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
    private List<GameObject> scoreTextInstances;

    public string scoreText = "0";
    public int score = 0;
    public int upOrDown;
    public GameObject ball;
    public GameObject player;
    public GameObject divider;
    public Image jumpTut;
    public Image crouchTut;
    public GameObject deathUI;
    private Animator deathUIAnimator;


    void Start () {
        originalPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
        ballRigidBody = GetComponent<Rigidbody>();
        deathUIAnimator = deathUI.GetComponent<Animator>();
        scoreTextInstances = new List<GameObject>();
        childBall = ball.transform.GetChild(0).gameObject;
        init();
    }

    void Awake()
    {

    }

    void Update()
    {
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

            upOrDown = Random.Range(1, 3);
            ballSpeed = -12;
            score += 1;
            scoreLoop();
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
            upOrDown = Random.Range(1, 3);
            ballSpeed = 12;
            score += 1;
            scoreLoop();
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
            ballRigidBody.velocity = Vector3.zero;
            childBall.GetComponent<Renderer>().enabled = false;
            foreach (GameObject O in scoreTextInstances)
            {
                Destroy(O);
            }
            isDead = true;
            isPlaying = false;
            waitIsOver = false;
            gameObject.transform.position = originalPos;
            deathUI.SetActive(true);
            deathUIAnimator.SetBool("Died", true);
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
        scoreLoop();
    }

    public void init()
    {
        resetBallPosition();
        childBall.GetComponent<Renderer>().enabled = true;
        isDead = false;
        firstBallGo = true;
        firstStart = true;
        ballSpeed = -12;
        score = 0;
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

    public void scoreLoop()
    {
        scoreText = score.ToString();
        float z = 57.1f;
        if (score > 0)
        {
            //GameObject[] numsToDestroy = new GameObject[score];
            //numsToDestroy = GameObject.FindGameObjectsWithTag("Num");
            foreach(GameObject O in scoreTextInstances)
            {
                Destroy(O);
            }
        }
        foreach (char num in scoreText)
        {
            int i = (int)num;
            var number = Resources.Load(num.ToString(), typeof(GameObject)) as GameObject;
            GameObject clone = Instantiate(number, new Vector3(141.84f, -25.5f, z), Quaternion.Euler(new Vector3(0, 270, 0)));
            scoreTextInstances.Add(clone);
            z -= .4f;
        }
    }


}
