using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    float xPos;
    float zPos;
    public int ballSpawn;
    public int cubeSpawn;
    public int ballsinfected;
    public int ballLeft;
    public float timelimit;
    public GameObject player;
    public Text time;
    public Text BallsInfected;
    public Text BallsLeft;
    float timer;
    public GameObject Ball;
    public GameObject InfectCube;
    public List<GameObject> RedobjList = new List<GameObject>();
    public bool infectionCube;
    float displaytime;

    void Start()
    {
        ballLeft = ballSpawn;
        timer = timelimit;
        StartCoroutine(BallSpawn());
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(SpawnCube());
    }

    private void Update()
    {
        if (timer <= timelimit)
        {
            timer -= Time.deltaTime;
            displaytime = (int)timer;
            time.text = "Time : " + displaytime.ToString();
        }

        if (timer < 0)
        {
            Time.timeScale = 0.1f;         
            if(ballLeft == 0 )
            {
                Invoke("NextLevel", 0.3f);
            }
            else
            {
                Invoke("ReloadLevel", 0.3f);
            }
        }

    }
    
    public void NextLevel()
    {
        int currentbuildindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentbuildindex + 1);
    }

    void ReloadLevel()
    {
        int currentbuildindex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentbuildindex);
    }

    IEnumerator SpawnCube()
    {
        for(int i=0; i< cubeSpawn; i++)
        {
            GameObject Cube = Instantiate(InfectCube, new Vector3(Random.Range(5, -3.6f), 10f, Random.Range(5.3f, 13.5f)), Quaternion.identity);
            Destroy(Cube, 3f);
            yield return new WaitForSeconds(8f);
        }
    }

    IEnumerator BallSpawn()
    {

        for (int i = 0; i< ballSpawn; i++)
        {
            xPos = Random.Range(5, -3.6f);
            zPos = Random.Range(5.13f, 13.5f);
            GameObject Go = Instantiate(Ball, new Vector3(xPos, 6.37f, zPos), Quaternion.identity);
            yield return new WaitForSeconds(0.1f);
        }
    }

}
