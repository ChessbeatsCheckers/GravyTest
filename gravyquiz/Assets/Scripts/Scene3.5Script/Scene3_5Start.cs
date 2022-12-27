using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using static System.Net.Mime.MediaTypeNames;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class Scene3_5Start : MonoBehaviour
{
    // This is our button covering the whole screen

    [SerializeField]
    private GameObject Nextphase;
    //Bigtxt and small txt are out text bubbles

    

    // count will allow us to keep track of the pase of the game
    private int count = 0;
    // debounce will not allow repetition until the cycle is complete
    private bool debounce = false;

    // Start is called before the first frame update

    void Start()
    {
        Nextphase.GetComponent<Button>().onClick.AddListener(phasecontinue);
    }

    // Update is called once per frame
    void Update()
    {

    }
    // phasecontinue only activates when there is a click on the screen

    void phasecontinue()
    {
        // if cycle is complete we can use the if statement
        if (!debounce)
        {
            debounce = true;
            // we use a switch case statement for our count as we increment past the phases
            switch (count)
            {
                case 0:
                    StartCoroutine(flash(Nextphase.GetComponent<Image>().color));
                    break;
                case 1:
                    SceneManager.LoadScene("GravyQuizScene4");
                    break;

            }
            count++;
        }
    }
    

    // we call this function to begin typeing our text and wait .1 seconds for each character, after everything is typed the cycle is complete
    IEnumerator flash(Color ourcolor)
    {

        int count = 0;

        while (count < 4)
        {
            ourcolor.a = .9f;
            Nextphase.GetComponent<Image>().color = ourcolor; 

            yield return new WaitForSeconds(.5f);

            ourcolor.a = 0f;
            Nextphase.GetComponent<Image>().color = ourcolor;
            yield return new WaitForSeconds(.5f);
            Debug.Log("cycle " + count);
            count++;

        }

        debounce = false;
    }
}
