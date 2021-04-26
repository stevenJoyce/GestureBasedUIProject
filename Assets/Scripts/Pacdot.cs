using UnityEngine;
using System.Collections;

public class Pacdot : MonoBehaviour {

	//Method used to add a score everytime a collision with pacman is triggered
	//When event occurs, the pacdot is destroyed
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.name == "pacman")
		{
			//add to score
			ScoreManager.instSc.PacDotScore();
			//Debug.Log("pacdot collected");

			Destroy(gameObject);
        }
	}
}
