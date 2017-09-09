using UnityEngine;
using System.Collections;

public class MC_button : MonoBehaviour
{
    GameObject tick;
    GameObject cross;
    void FixedUpdate()
    {
        if (tick != null)
            if (tick.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit"))
            {
                finishStage();
            }
        if (cross != null)
            if (cross.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("Exit"))
            {
                finishStage();
            }
    }
    public void buttonPress()
    {
        if (gameObject.tag == gameObject.transform.parent.parent.Find("LPanel").Find("question").tag)
        {
            tick = Instantiate(gameObject.transform.parent.parent.GetComponent<MC_eventHandler>().tick);
            tick.transform.SetParent(gameObject.transform);
            tick.transform.localScale = new Vector3(1, 1, 1);
            tick.GetComponent<Animator>().cullingMode = AnimatorCullingMode.AlwaysAnimate;
            GameModeHandler.correct++;
            gameObject.transform.parent.parent.GetComponent<MC_eventHandler>().playSound(true);

        }
        else
        {
            cross = Instantiate(gameObject.transform.parent.parent.GetComponent<MC_eventHandler>().cross);
            cross.transform.SetParent(gameObject.transform);
            cross.transform.localScale = new Vector3(1, 1, 1);
            cross.GetComponent<Animator>().cullingMode = AnimatorCullingMode.AlwaysAnimate;
            GameModeHandler.wrong++;
            gameObject.transform.parent.parent.GetComponent<MC_eventHandler>().playSound(false);
        }
    }
    void finishStage()
    {
        if (GameModeHandler.correct >= 5)
        {
            GameModeHandler.pass = true;
            GameModeHandler.Exit();
        }
        else if (GameModeHandler.wrong >= 5)
            GameModeHandler.Exit();
        else
            gameObject.transform.parent.parent.GetComponent<MC_eventHandler>().Start();
    }
}

