using UnityEngine;
using System.Collections;

public class Frequency_plus_button : MonoBehaviour {

    public void pressFrequency_plus()
    {
        if (GameModeHandler.Frequency_plus > 0)
        {
            GameModeHandler.Frequency_plus--;
            GameModeHandler.GameModeStart("MC");
        }
    }
}
