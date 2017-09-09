using UnityEngine;
using System.Collections;

public class BulletLevel_plus_button : MonoBehaviour {
    public void pressBulletLevel_plus()
    {
        if (GameModeHandler.BulletLevel_plus > 0)
        {
            GameModeHandler.BulletLevel_plus--;
            GameModeHandler.GameModeStart("Belly");
        }
    }
}
