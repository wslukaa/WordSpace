using UnityEngine;
using System.Collections;

public class MenuButton : MonoBehaviour {

    public void Continue() {
        Application.LoadLevel("Aeroplane");
    }

    public void NewGame() {
        GameModeHandler.SetZero();
        Application.LoadLevel("Aeroplane");
    }

    public void HighScores() {
        Application.LoadLevel("HighScores");
    }
}
