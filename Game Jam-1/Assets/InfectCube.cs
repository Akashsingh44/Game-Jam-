using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectCube : MonoBehaviour
{
    public Spawn spawn;
    private void Start()
    {
        spawn = GameObject.FindObjectOfType<Spawn>().GetComponent<Spawn>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Red")
        {
            spawn.RedobjList.Remove(collision.collider.gameObject);
            collision.collider.GetComponent<Renderer>().material.color = Color.white;
            collision.collider.tag = "Balls";
            collision.collider.GetComponent<ChangeColor>().Added = false;
        }
    }
}
