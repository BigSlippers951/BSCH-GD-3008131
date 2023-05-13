
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{

    public Text scoreText;
    public float currentScore;
    public float hitPower;
    public float scoreIncreasedPerSecond;
    public float x;

    public int shop1Price;
    public Text shop1Text;

    public int shop2Price;
    public Text shop2Text;

    public int amount1;
    public Text amount1Text;
    public float amount1Profit;

    public int amount2;
    public Text amount2Text;
    public float amount2Profit;

    public int upgradePrize;
    public Text upgradeText;

    public Sprite sp1, sp2, sp3, sp4;
    public Image clickerButton;

    public Slider slider;
    float sliderValue;

    public bool nowIsEvent;
    public GameObject goldButton;

    public GameObject plusObject;
    public Text plusText;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        hitPower = 1;
        scoreIncreasedPerSecond = 1;
        x = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Good Boy Pats:" + (int)currentScore;
        scoreIncreasedPerSecond = x * Time.deltaTime;
        currentScore = currentScore + scoreIncreasedPerSecond;

        shop1Text.text = "Dog Walker: " + shop1Price;
        shop2Text.text = "Groomer: " + shop2Price;

        amount1Text.text = "Walkers: " + amount1 + " Pats: " + amount1Profit + "/s";
        amount2Text.text = "Groomers: " + amount2 + " Pats: " + amount2Profit + "/s";

        upgradeText.text = "Cost: " + upgradePrize;

        sliderValue = slider.value;
        if(sliderValue >= 0 && sliderValue <= 0.25)
        {
            clickerButton.sprite = sp1;
        }
        else if(sliderValue > 0.25 && sliderValue < 0.50)
        {
            clickerButton.sprite = sp2;
        }
        else if(sliderValue > 0.50 && sliderValue < 0.75)
        {
            clickerButton.sprite = sp3;
        }
        else
        {
            clickerButton.sprite = sp4;
        }
        
        if(nowIsEvent == false && goldButton.active == true)
        {
            goldButton.SetActive(false);
            StartCoroutine(WaitForEvent());
        }

        if(nowIsEvent == true && goldButton.active == false)
        {
            goldButton.SetActive(true);
            goldButton.transform.position = new Vector3(Random.Range(0, 751), Random.Range(0, 401), 0);
        }

        plusText.text = "+ " + hitPower;

    }

    public void Hit()
    {
        currentScore += hitPower;

        plusObject.SetActive(false);

        plusObject.transform.position = new Vector3(Random.Range(400, 500 + 1), Random.Range(105, 305 + 1), 0);

        plusObject.SetActive(true);

        StartCoroutine(Fly());
    }

    public void Shop1()
    {
        if (currentScore >= shop1Price)
        {
            currentScore -= shop1Price;
            amount1 += 1;
            amount1Profit += 1;
            x += 1;
            shop1Price += 25;
        }
    }

    public void Shop2()
    {
        if (currentScore >= shop2Price)
        {
            currentScore -= shop2Price;
            amount2 += 1;
            amount2Profit += 5;
            x += 5;
            shop2Price += 125;
        }
    }

    public void Upgrade()
    {
        if(currentScore >= upgradePrize)
        {
            currentScore -= upgradePrize;
            hitPower *= 2;
            upgradePrize *= 3;
        }
    }

    public void GetReward()
    {
        currentScore = currentScore + Random.Range(1, 2500);
        nowIsEvent = false;
        StartCoroutine(WaitForEvent());
    }

    IEnumerator WaitForEvent()
    {
        yield return new WaitForSeconds(5f);

        int x = 0;
        x = Random.Range(1, 3);

        if(x == 2)
        {
            nowIsEvent = true;
        }
        else
        {
            goldButton.SetActive(true);
        }
    }

    IEnumerator Fly()
    {
        for(int i = 0; i <= 19; i++)
        {
            yield return new WaitForSeconds(0.01f);

            plusObject.transform.position = new Vector3(plusObject.transform.position.x, plusObject.transform.position.y + 2, 0);
        }

        plusObject.SetActive(false);
    }

}
