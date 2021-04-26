using UnityEngine;

public class GhostAi : MonoBehaviour
{
    //Gets all the waypoints set for each ghost
    public Transform[] waypoints;
    //used for finding current position of ghost
    int curpos = 0;
    //speed in which the ghosts will move at
    public float speed = 0.1f;

    void FixedUpdate()
    {
        //Used to move the ghosts through the maze
        if (transform.position != waypoints[curpos].position)
        {
            Vector2 p = Vector2.MoveTowards(transform.position,waypoints[curpos].position, speed);
            GetComponent<Rigidbody2D>().MovePosition(p);
        }
        else curpos = (curpos + 1) % waypoints.Length;

        // Animation of ghost while moving
        Vector2 dir = waypoints[curpos].position - transform.position;
        GetComponent<Animator>().SetFloat("DirX", dir.x);
        GetComponent<Animator>().SetFloat("DirY", dir.y);
    }
    //If ghost collides with pacman he loses a life
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.name == "pacman")
            PacmanHealth.instPh.LoseLife(1);
    }


}
