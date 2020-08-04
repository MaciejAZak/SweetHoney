using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinLoseConditions : MonoBehaviour
{
    [SerializeField] public int EndBeeKeeperScore = 100;
    [SerializeField] public int EndHoneyGathered = 200;
    [SerializeField] public int EndnumberOfBees = 30;
    [SerializeField] public int EndHexes = 6;
    GameObject menuWin;
    GameObject menuLose;

    bool menuActive = false;
    int TotalHoneyGathered;
    int HoneyGathered;
    int BeekeeperScore;
    int numberOfBees;
    int numberOfWorkerBees;
    int totalBees;
    int ActiveHexes;
    float timePassed;
    public int EndScore;


    int HoneyGatheredScore;
    int TotalHoneyGatheredScore; 
    int totalBeesScore; 
    int ActiveHexesScore; 
    int BeekeeperMinusScore; 
    int timePassedMinusScore; 

    // Start is called before the first frame update
    void Start()
    {
        WinScreenScript Win = FindObjectOfType<WinScreenScript>();
        menuWin = Win.gameObject;
        menuWin.gameObject.SetActive(false);
        LoseScreenScript Lose = FindObjectOfType<LoseScreenScript>();
        menuLose = Lose.gameObject;
        menuLose.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        HoneyManager honeyManager = FindObjectOfType<HoneyManager>();
        TotalHoneyGathered = honeyManager.TotalHoneyGathered;
        HoneyGathered = honeyManager.HoneyGathered;

        honeyStolenScript Beekeeper = FindObjectOfType<honeyStolenScript>();
        BeekeeperScore = Beekeeper.BeekeeperScore;

        BeeCounter Bees = FindObjectOfType<BeeCounter>();
        numberOfBees = Bees.numberOfBees;

        BeeWorkerCounter WorkerBees = FindObjectOfType<BeeWorkerCounter>();
        numberOfWorkerBees = WorkerBees.numberOfBees;

        GenerateHexes Hexes = FindObjectOfType<GenerateHexes>();
        ActiveHexes = Hexes.ActiveHexes.Count;

        Game_Timer Timer = FindObjectOfType<Game_Timer>();
        timePassed = Timer.current_time;

        totalBees = numberOfBees + numberOfWorkerBees;

        CheckLose();
        CheckWin();
    }

    void CheckLose()
    {
        if (BeekeeperScore >= EndBeeKeeperScore)
        {

            // LOSE
            menuLose.SetActive(true);
            //Debug.Log("Lost");
            GenerateHexes board = FindObjectOfType<GenerateHexes>();
            board.HideCost();
            HoneyGatheredScore = HoneyGathered * 10;
            TotalHoneyGatheredScore = TotalHoneyGathered;
            totalBeesScore = totalBees * 20;
            ActiveHexesScore = ActiveHexes * 125;
            BeekeeperMinusScore = -BeekeeperScore * 50;
            timePassedMinusScore = -(int)timePassed * 2; ;

            EndScore = HoneyGatheredScore + TotalHoneyGatheredScore + totalBeesScore + ActiveHexesScore + BeekeeperMinusScore + timePassedMinusScore - 1000;

            ScoreText scoreText = FindObjectOfType<ScoreText>();
            scoreText.GetComponent<TextMesh>().text = EndScore.ToString();

            Time.timeScale = 0f;
        }
        else
        {
            return;
        }
    }

    void CheckWin()
    {
        if (HoneyGathered >= EndHoneyGathered && totalBees >= EndnumberOfBees && ActiveHexes >= EndHexes)
        {

            // WIN
            //Debug.Log("Win");
            GenerateHexes board = FindObjectOfType<GenerateHexes>();
            board.HideCost();
            HoneyGatheredScore = HoneyGathered * 10;
            TotalHoneyGatheredScore = TotalHoneyGathered;
            totalBeesScore = totalBees * 20;
            ActiveHexesScore = ActiveHexes * 55;
            BeekeeperMinusScore = -BeekeeperScore * 100;
            timePassedMinusScore = -(int)timePassed * 2; ;

            EndScore = HoneyGatheredScore + TotalHoneyGatheredScore + totalBeesScore + ActiveHexesScore + BeekeeperMinusScore + timePassedMinusScore;

            menuWin.SetActive(true);

            ScoreText scoreText = FindObjectOfType<ScoreText>();
            scoreText.GetComponent<TextMesh>().text = EndScore.ToString();

            HexScoreNumber hexScoreNumber = FindObjectOfType<HexScoreNumber>();
            hexScoreNumber.GetComponent<TextMesh>().text = ActiveHexesScore.ToString();
            HoneyScoreNumber honeyScoreNumber = FindObjectOfType<HoneyScoreNumber>();
            honeyScoreNumber.GetComponent<TextMesh>().text = HoneyGatheredScore.ToString();
            BeeScoreNumber beeScoreNumber = FindObjectOfType<BeeScoreNumber>();
            beeScoreNumber.GetComponent<TextMesh>().text = totalBeesScore.ToString();
            TotalHoneyScoreNumber totalHoneyScoreNumber = FindObjectOfType<TotalHoneyScoreNumber>();
            totalHoneyScoreNumber.GetComponent<TextMesh>().text = TotalHoneyGatheredScore.ToString();
            BeeKeeperScoreNumber beeKeeperScoreNumber = FindObjectOfType<BeeKeeperScoreNumber>();
            beeKeeperScoreNumber.GetComponent<TextMesh>().text = BeekeeperMinusScore.ToString();
            TimerScoreNumber timerScoreNumber = FindObjectOfType<TimerScoreNumber>();
            timerScoreNumber.GetComponent<TextMesh>().text = timePassedMinusScore.ToString();

            Time.timeScale = 0f;
        }
        else
        {
            return;
        }
    }

}
