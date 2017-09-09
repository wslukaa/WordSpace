using UnityEngine;
using System.Collections;

public class HP_plus_button : MonoBehaviour {
    public void pressHP_plus()
    {
        if (GameModeHandler.HP_plus > 0) {
            GameModeHandler.HP_plus--;
            GameModeHandler.GameModeStart("Drag");
        }
    }
}
