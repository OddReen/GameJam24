using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzlesController : MonoBehaviour
{
    public static PuzzlesController instance;

    public bool arcadePuzzle;
    public bool potPuzzle;
    public bool radioPuzzle;
    public bool elementsPuzzle;

    public Animator anim;


    private void Start()
    {
        instance = this;
    }

    public void CheckAllPuzzles()
    {
        if (!arcadePuzzle)
        {
            return;
        }
        else if (!potPuzzle)
        {
            return;
        }
        else if (!radioPuzzle)
        {
            return;
        }
        else if (!elementsPuzzle)
        {
            return;
        }

        Invoke(nameof(End), 2);
        //win 
    }

    public void End()
    {
        anim.SetTrigger("End");
    }
}
