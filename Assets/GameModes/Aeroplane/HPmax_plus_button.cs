using UnityEngine;
using System.Collections;

public class HPmax_plus_button : MonoBehaviour {

    public void pressHPmax_plus()
    {
        if (GameModeHandler.HPmax_plus > 0)
        {
            GameModeHandler.HPmax_plus--;
            GameModeHandler.GameModeStart("Cut");
        }
    }
}
