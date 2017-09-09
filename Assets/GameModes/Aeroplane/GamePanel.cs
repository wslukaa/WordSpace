using UnityEngine;
using System.Collections;

public class GamePanel : MonoBehaviour {

    public GameObject[] monster = new GameObject[1];
    public int[] normalMonsterPeriod=new int[1];
    int normalMonsterTime = 0;

    public int[] NormalMonsterTypeLevelPeriod=new int[1];

    public GameObject[] supplement = new GameObject[1];
    public int supplementPeriod;
    int supplementTime = 0;

    public AudioClip introduction;
    public AudioClip[] background = new AudioClip[3];
    public AudioClip[] monsterIntro = new AudioClip[1];


    // Use this for initialization
    void Start () {
        if (GameModeHandler.exstingNormalMonster.Count == 0 & GameModeHandler.exstingSupplement.Count == 0)
        {
            PlayIntroductionSound();
        }
        PlayBackgroundMusic();
        LoadNormalMonster();
        LoadSupplement();
    }

    // Update is called once per frame
    void FixedUpdate() {
        GenerateNormalMonster();
        GenerateSupplement();
        IncreaseNormalMonsterTypeLevel();
        IncreaseNormalMonsterPeriodLevel();
    }


    void GenerateNormalMonster() {
            if (normalMonsterTime > normalMonsterPeriod[GameModeHandler.NormalMonsterPeriodLevel])
            {
            GameObject newMonster = Instantiate(monster[GameModeHandler.NormalMonsterTypeLevel]);
            newMonster.transform.SetParent(gameObject.transform);
            newMonster.transform.localScale = (new Vector3(1, 1, 1));
            if (GameModeHandler.NormalMonsterIndex == long.MaxValue)
                GameModeHandler.NormalMonsterIndex = 0;
            newMonster.GetComponent<Monster>().index = GameModeHandler.NormalMonsterIndex;
            newMonster.transform.GetComponent<RectTransform>().localPosition = new Vector3(420 - Random.value * 820, 500, 0);
            GameModeHandler.exstingNormalMonster.Add(new ExistingNormalMonster(GameModeHandler.NormalMonsterIndex, GameModeHandler.NormalMonsterTypeLevel, newMonster.transform.GetComponent<RectTransform>().localPosition));
            GameModeHandler.NormalMonsterIndex++;

            normalMonsterTime = 0;

            GameModeHandler.currentNormalMonsterTypeLevelTime++;
        }
            else
            {
                normalMonsterTime++;
            }
        }

    void GenerateSupplement()
    {
        if (supplementTime > supplementPeriod)
        {
            int type = Mathf.RoundToInt(Random.value * 3);
            GameObject newSupplement = Instantiate(supplement[type]);
            newSupplement.transform.SetParent(gameObject.transform);
            newSupplement.transform.localScale = (new Vector3(1, 1, 1));
            if (GameModeHandler.existingSupplementIndex == long.MaxValue)
                GameModeHandler.existingSupplementIndex = 0;
            newSupplement.GetComponent<Supplement>().index = GameModeHandler.existingSupplementIndex;
            newSupplement.transform.GetComponent<RectTransform>().localPosition = new Vector3(420 - Random.value * 820, 500, 0);
            GameModeHandler.exstingSupplement.Add(new ExistingSupplement(GameModeHandler.existingSupplementIndex, type, newSupplement.transform.GetComponent<RectTransform>().localPosition));
            GameModeHandler.existingSupplementIndex++;

            supplementTime = 0;
        }
        else
        {
            supplementTime++;
        }
    }

    void IncreaseNormalMonsterTypeLevel() {
        if (GameModeHandler.currentNormalMonsterTypeLevelTime >= NormalMonsterTypeLevelPeriod[GameModeHandler.NormalMonsterTypeLevel])
        {
            if (GameModeHandler.NormalMonsterTypeLevel < GameModeHandler.maxNormalMonsterTypeLevel) {
                AudioSource.PlayClipAtPoint(monsterIntro[GameModeHandler.NormalMonsterTypeLevel], new Vector3(0, 0, 0));
                GameModeHandler.NormalMonsterTypeLevel++;
            }
            GameModeHandler.currentNormalMonsterTypeLevelTime = 0;
        }
    }

    void IncreaseNormalMonsterPeriodLevel() {

        if (GameModeHandler.score < 5000)
        {
            GameModeHandler.NormalMonsterPeriodLevel = 0;
        }
        else if (GameModeHandler.score < 10000)
        {
            GameModeHandler.NormalMonsterPeriodLevel = 1;
        }
        else if (GameModeHandler.score < 20000)
        {
            GameModeHandler.NormalMonsterPeriodLevel = 2;
        }
        else if (GameModeHandler.score < 30000)
        {
            GameModeHandler.NormalMonsterPeriodLevel = 3;
        }
        else if (GameModeHandler.score < 40000)
        {
            GameModeHandler.NormalMonsterPeriodLevel = 4;
        }
        else if (GameModeHandler.score < 50000)
        {
            GameModeHandler.NormalMonsterPeriodLevel = 5;
        }
        else {
            GameModeHandler.NormalMonsterPeriodLevel = 6;
        }
    }

    void LoadNormalMonster() {
        if (GameModeHandler.exstingNormalMonster.Count > 0)
        {
            foreach (ExistingNormalMonster existingnormalMonster in GameModeHandler.exstingNormalMonster)
            {
                GameObject newMonster = Instantiate(monster[existingnormalMonster.level]);
                newMonster.transform.SetParent(gameObject.transform);
                newMonster.GetComponent<Monster>().index = existingnormalMonster.index;
                newMonster.GetComponent<Monster>().HP = existingnormalMonster.HP;
                newMonster.transform.localScale = (new Vector3(1, 1, 1));
                newMonster.GetComponent<RectTransform>().localPosition = existingnormalMonster.position;
            }
        }
    }

    void LoadSupplement() {
        if (GameModeHandler.exstingSupplement.Count > 0)
        {
            foreach (ExistingSupplement existingsupplement in GameModeHandler.exstingSupplement)
            {
                GameObject newSupplement = Instantiate(supplement[existingsupplement.type]);
                newSupplement.transform.SetParent(gameObject.transform);
                newSupplement.GetComponent<Supplement>().index = existingsupplement.index;
                newSupplement.GetComponent<Supplement>().type = existingsupplement.type;
                newSupplement.transform.localScale = (new Vector3(1, 1, 1));
                newSupplement.GetComponent<RectTransform>().localPosition = existingsupplement.position;
            }
        }
    }

    void PlayIntroductionSound() {
        AudioSource.PlayClipAtPoint(introduction, new Vector3(0, 0, 0));
    }

    void PlayBackgroundMusic()
    {
        int i=Mathf.RoundToInt(Random.Range(0,3));


        AudioSource music = gameObject.transform.Find("BackgroundMusic").GetComponent<AudioSource>();
        music.clip = background[i];
        music.Play();
    }

}
