using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public Spawn spawn;
    public bool Added = false;

    private void Start()
    {
        spawn = GameObject.FindObjectOfType<Spawn>().GetComponent<Spawn>();
        //Destroy(this.gameObject, 3f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player" || collision.collider.tag == "Red")
        {
            if (!Added)
            {
                spawn.RedobjList.Add(this.gameObject);
                Added = true;
            }

            Debug.Log("hit");
            this.GetComponent<Renderer>().material.color = Color.red;
            this.gameObject.tag = "Red";
            Debug.Log(spawn.RedobjList.Count);
            spawn.ballsinfected = spawn.RedobjList.Count;
        }
        spawn.ballLeft = (spawn.ballSpawn - spawn.ballsinfected);
        spawn.BallsInfected.text = "Balls Infected : " + spawn.ballsinfected.ToString();
        spawn.BallsLeft.text = "Balls Left : " + spawn.ballLeft.ToString();

        if(spawn.ballLeft == 0)
        {
            spawn.NextLevel();
        }
    }
}
