using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public int score = 0;
    public string scoreText;
    public string[] characters;
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        scoreText = score.ToString();

        foreach(char num in score.ToString())
        {
            int i = (int)num;
            int z = 0;
            string path = "Models/Numbers/" + i.ToString() + ".obj";
            Instantiate(Resources.Load<GameObject>(path), new Vector3(z * 2.0f, 0, 0), Quaternion.identity);
        }
	}
}
