using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameModeHandler : MonoBehaviour {

    static public int current_level = 1;
    static public int max_level = 10;
    static public int max_available_level = 40;
    static private int max_level_digit = 3;
    static public int correct = 0;
    static public int wrong = 0;
    static public bool pass = false;

    static public long existingSupplementIndex = 0;
    static public List<ExistingSupplement> exstingSupplement = new List<ExistingSupplement>();

    static public int maxPlaneBulletLevel = 7;
    static public int maxPlaneBulletFrequencyLevel = 7;
    static public int maxPlaneHPmax = 900;

    static public int PlaneBulletLevel=0;
    static public int PlaneBulletFrequencyLevel = 0;
    static public float PlanePosition = 0;
    static public int PlaneHP=100;
    static public int PlaneHPmax = 100;

    static public long NormalMonsterIndex = 0;
    static public List<ExistingNormalMonster> exstingNormalMonster=new List<ExistingNormalMonster>();
    static public int NormalMonsterTypeLevel = 0;
    static public int NormalMonsterPeriodLevel = 0;

    static public int maxNormalMonsterTypeLevel = 5;

    static public int currentNormalMonsterTypeLevelTime = 0;

    static public int HP_plus = 0;
    static public int HPmax_plus = 0;
    static public int BulletLevel_plus = 0;
    static public int Frequency_plus = 0;

    static public long score = 0;

    static public void GameModeStart(string gameModeName)
    {
        current_level = 1;
        correct = 0;
        wrong = 0;
        pass = false;
        if (gameModeName == "Drag")
            //dunno whether I should use LoadLevel
            Application.LoadLevel(generate_random_level("drag_mode_"));
        else if (gameModeName == "Cut")
            Application.LoadLevel(generate_random_level("cut_mode_"));
        else if (gameModeName == "Belly")
            Application.LoadLevel("hit_belly");
        else if (gameModeName == "MC")
            Application.LoadLevel("MC");
        else
        {
            Debug.Log("None of the Game Mode called " + gameModeName);
        }
    }

    static public void loadnextlevel()
    {
        if (current_level == max_level) {
            pass = true;
            Exit();
        }
        else
        {
            string current_game_mode_name = Application.loadedLevelName.Substring(0, Application.loadedLevelName.Length - max_level_digit);
            int random_level_number = Mathf.CeilToInt(Random.value * max_available_level);
            string random_level_number_name = random_level_number.ToString();
            for (int i = 1; i < max_level_digit - Mathf.FloorToInt(Mathf.Log10(random_level_number));i++) {
                random_level_number_name = "0" + random_level_number_name;
            }
            current_level++;
            Application.LoadLevel(current_game_mode_name + random_level_number_name);
        }
    }

    static private string generate_random_level(string game_mode_name) {
        int random_level_number = Mathf.CeilToInt(Random.value * max_available_level);
        string random_level_number_name = random_level_number.ToString();
        for (int i = 1; i < max_level_digit - Mathf.FloorToInt(Mathf.Log10(random_level_number)); i++)
        {
            random_level_number_name = "0" + random_level_number_name;
        }
        return game_mode_name + random_level_number_name;
    }

    static public void Exit(){
        //just testing
        if (Application.loadedLevelName != "Aeroplane" & Application.loadedLevelName != "menu" & Application.loadedLevelName != "HighScores")
        {
            if (Application.loadedLevelName.Contains("drag_mode_") & pass)
            {
                PlaneHP += (int)(PlaneHPmax * 0.25);
                if (PlaneHP > PlaneHPmax)
                    PlaneHP = PlaneHPmax;
            }
            else if (Application.loadedLevelName.Contains("cut_mode_") & pass)
            {
                if (PlaneHPmax + 25 <= maxPlaneHPmax)
                    PlaneHPmax += 25;
            }
            else if (Application.loadedLevelName == "hit_belly" & pass)
            {
                if (PlaneBulletLevel < maxPlaneBulletLevel)
                    PlaneBulletLevel++;
            }
            else if (Application.loadedLevelName == "MC" & pass)
            {
                if (PlaneBulletFrequencyLevel < maxPlaneBulletFrequencyLevel)
                    PlaneBulletFrequencyLevel++;
            }
            Application.LoadLevel("Aeroplane");
        }
        else if (Application.loadedLevelName == "Aeroplane"|| Application.loadedLevelName == "HighScores")
        {
            Application.LoadLevel("menu");
        }
        else {
            Application.Quit();
        }
        }

    static public void SetZero() {
        current_level = 1;
        max_level = 10;
        max_available_level = 40;
        max_level_digit = 3;
        correct = 0;
        wrong = 0;
        pass = false;

        existingSupplementIndex = 0;
        exstingSupplement = new List<ExistingSupplement>();

        maxPlaneBulletLevel = 7;
        maxPlaneBulletFrequencyLevel = 7;
        maxPlaneHPmax = 900;

        PlaneBulletLevel = 0;
        PlaneBulletFrequencyLevel = 0;
        PlanePosition = 0;
        PlaneHP = 100;
        PlaneHPmax = 100;

        NormalMonsterIndex = 0;
        exstingNormalMonster = new List<ExistingNormalMonster>();
        NormalMonsterTypeLevel = 0;
        NormalMonsterPeriodLevel = 0;

        maxNormalMonsterTypeLevel = 5;

        currentNormalMonsterTypeLevelTime = 0;

        HP_plus = 0;
        HPmax_plus = 0;
        BulletLevel_plus = 0;
        Frequency_plus = 0;

        score = 0;
    }

}
