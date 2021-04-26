using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PacmanHealth : MonoBehaviour
{
    //Variables used to give pacman 3 lives
    public static PacmanHealth instPh;
    public GameObject[] life;
    int lifeCount = 3;
    void Start()
    {
        instPh = this;
        lifeCount = life.Length;
    }
    /*Method used to remove a life from pacman whenever the ghost hits pacman,
    If life count reaches 0, pacmanController die method is called*/
    public void LoseLife(int dam)
    {
        if (lifeCount >= 1)
        {
            lifeCount -= dam;
            life[lifeCount].gameObject.SetActive(false);

        }
        else
        {
            //if player has no life left - game over
            PacManController.instPc.Die();
        }

    }
}
