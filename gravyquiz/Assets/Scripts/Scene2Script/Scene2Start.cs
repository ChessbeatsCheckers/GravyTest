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

public class Scene2Start : MonoBehaviour
{

    // This is our button covering the whole screen

    [SerializeField]
    private GameObject Nextphase;

    //Bigtxt and small txt are out text bubbles

    [SerializeField]
    private GameObject BigBubbleTxt;
    //[SerializeField]
    //private GameObject SmallBubbleTxt;

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
                    StartCoroutine(type(BigBubbleTxt.GetComponent<TextMeshProUGUI>(), "Nice try buddy.. I've got nerves of steel."));

                    break;
                case 1:

                    SceneManager.LoadScene("GravyQuizScene3");
                    break;
                

            }
            count++;
        }
    }
    // we call this function to begin typeing our text and wait .1 seconds for each character, after everything is typed the cycle is complete

    IEnumerator type(TextMeshProUGUI tex, string body)
    {
        tex.text = "";
        int count = 0;

        while (tex.text.Length != body.Length)
        {
            tex.text = tex.text + body[count];
            count++;
            yield return new WaitForSeconds(.1f);
            //yield return null;
        }

        debounce = false;
    }
}
