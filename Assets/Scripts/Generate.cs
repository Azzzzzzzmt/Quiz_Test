using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class Generate : MonoBehaviour
{
    public Text findText;

    public GameObject [] images;
    public GameObject [] easyLevel;
    public GameObject [] normalLevel;
    public GameObject [] hardLevel;
    public GameObject [] levels;
    public GameObject restart;
    public GameObject findTextObject;
    public Image fadeImage;
    List<int> alreadyHave = new List<int>();

    public string[] letters = new string[36];
    int randomRandomize;
    int correctChoise;
    int currentLevel = 1;

    Animation animation = new Animation();
    // Start is called before the first frame update
    void Start()
    {
        EasyLevelStart(3);
    }
    void EasyLevelStart(int r)
    {
        animation.Open(levels[0]);
        findText.DOFade(0.0f, 0.0f);
        findText.DOFade(1.0f,3.0f);
        alreadyHave.Clear();
        int random = Random.Range(0, 36);
        if (random < 10)
        {
            for(int i = 0; i < r; i++)
            {
                int rnd = RandomizeInt();
                alreadyHave.Add(rnd);
            }
            for(int i = 0; i < r; i++)
            {
                easyLevel[i].GetComponent<Image>().sprite = images[alreadyHave[i]].GetComponent<SpriteRenderer>().sprite;
            }
        }
        else
        {
            for (int i = 0; i < r; i++)
            {
                int rnd = RandomizeChar();
                alreadyHave.Add(rnd);
            }
            for (int i = 0; i < r; i++)
            {
                easyLevel[i].GetComponent<Image>().sprite = images[alreadyHave[i]].GetComponent<SpriteRenderer>().sprite;
            }
        }
        correctChoise = Random.Range(0, alreadyHave.Count);
        findText.text = "Find  " + letters[alreadyHave[correctChoise]];
    }
    void NormalLevelStart(int r)
    {
        animation.Open(levels[1]);
        findText.DOFade(0.0f, 0.0f);
        findText.DOFade(1.0f, 3.0f);
        alreadyHave.Clear();
        int random = Random.Range(0, 36);
        if (random < 10)
        {
            for (int i = 0; i < r; i++)
            {
                int rnd = RandomizeInt();
                alreadyHave.Add(rnd);
            }
            for (int i = 0; i < r; i++)
            {
                normalLevel[i].GetComponent<Image>().sprite = images[alreadyHave[i]].GetComponent<SpriteRenderer>().sprite;
            }
        }
        else
        {
            for (int i = 0; i < r; i++)
            {
                int rnd = RandomizeChar();
                alreadyHave.Add(rnd);
            }
            for (int i = 0; i < r; i++)
            {
                normalLevel[i].GetComponent<Image>().sprite = images[alreadyHave[i]].GetComponent<SpriteRenderer>().sprite;
            }
        }
        correctChoise = Random.Range(0, alreadyHave.Count);
        findText.text = "Find  " + letters[alreadyHave[correctChoise]];
    }
    void HardLevelStart(int r)
    {
        animation.Open(levels[2]);
        findText.DOFade(0.0f, 0.0f);
        findText.DOFade(1.0f, 3.0f);
        alreadyHave.Clear();
        int random = Random.Range(0, 36);
        if (random < 10)
        {
            for (int i = 0; i < r; i++)
            {
                int rnd = RandomizeInt();
                alreadyHave.Add(rnd);
            }
            for (int i = 0; i < r; i++)
            {
                hardLevel[i].GetComponent<Image>().sprite = images[alreadyHave[i]].GetComponent<SpriteRenderer>().sprite;
            }
        }
        else
        {
            for (int i = 0; i < r; i++)
            {
                int rnd = RandomizeChar();
                alreadyHave.Add(rnd);
            }
            for (int i = 0; i < r; i++)
            {
                hardLevel[i].GetComponent<Image>().sprite = images[alreadyHave[i]].GetComponent<SpriteRenderer>().sprite;
            }
        }
        correctChoise = Random.Range(0, alreadyHave.Count);
        findText.text = "Find  " + letters[alreadyHave[correctChoise]];
    }
    int RandomizeInt()
    {
        randomRandomize = Random.Range(0,10);
        foreach(int i in alreadyHave)
        {
            if (i == randomRandomize) RandomizeInt();
        }
        return randomRandomize;
    }
    int RandomizeChar()
    {
        randomRandomize = Random.Range(10,36);
        foreach (int i in alreadyHave)
        {
            if (i == randomRandomize) RandomizeChar();
        }
        return randomRandomize;
    }
    public void ButtonSelect(int i)
    {
        if (currentLevel == 1)
        {
            if (i == correctChoise)
            {
                animation.Bounce(easyLevel[i]);
                currentLevel++;
                findText.DOFade(0.0f, 2.0f);
                NormalLevelStart(6);
                levels[0].SetActive(false);
                levels[1].SetActive(true);
            }
            else animation.Shake(easyLevel[i]);
        }
        else if (currentLevel == 2)
        {
            if (i == correctChoise)
            {
                animation.Bounce(normalLevel[i]);
                currentLevel++;
                HardLevelStart(9);
                levels[1].SetActive(false);
                levels[2].SetActive(true);
            }
            else animation.Shake(normalLevel[i]);
        }
        else if (currentLevel > 2)
        {
            if (i == correctChoise)
            {
                animation.Bounce(hardLevel[i]);
                currentLevel =1;
                fadeImage.DOFade(0.7f, 3.0f);
                restart.SetActive(true);
                for (int j = 0; j < hardLevel.Length; j++)
                {
                    hardLevel[j].GetComponent<Button>().interactable = false;
                }
            }
            else animation.Shake(hardLevel[i]);
        }
    }
    public void Restart()
    {
        EasyLevelStart(3);
        levels[2].SetActive(false);
        levels[0].SetActive(true);
        restart.SetActive(false);
        for (int j = 0; j < hardLevel.Length; j++)
        {
            hardLevel[j].GetComponent<Button>().interactable = true;
        }
    }
}
