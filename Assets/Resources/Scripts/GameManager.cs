using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    #region GameManager Stats
    [SerializeField]
    private int nLightKarma = 0;
    [SerializeField]
    private int nDarkKarma = 0;
    [SerializeField]
    private int nTotalKarmaThreshold;

    [Header("Positive and Negative Min-Max Values")]
    public float nPosMax = 250;
    public float nNegMax = -250;

    [Header("Round Settings")]
    [SerializeField]
    private int startRound = 1;
    [SerializeField]
    private int RoundMax = 3;
    [SerializeField]
    private int currentRound = 1;

    [Header("Round Stats Holder")]
    [SerializeField]
    private List<int> nLightPoints = new List<int>();
    [SerializeField]
    private List<int> nDarkPoints = new List<int>();
    [SerializeField]
    private List<int> nTotalLightPoints = new List<int>();
    [SerializeField]
    private List<int> nTotalDarkPoints = new List<int>();
    private int _pastRound;
    [SerializeField]
    private int _lastRoundTotalKarma;
    #endregion
    #region UI Variables
    [SerializeField]
    private Text LKarmaText;
    [SerializeField]
    private Text DKarmaText;
    #endregion

    private void Awake()
    {
        OnGameStart();
    }

    private void Update()
    {
        KarmaClamps();
        KarmaGUI();
        DebugCommands();
    }

    private void KarmaGUI()
    {
        LKarmaText.text = "KARMA: " + nLightKarma.ToString();
        //DKarmaText.text = "$KARMA SCORE: {nDarkKarma}";
    }

    private void KarmaClamps()
    {
        // Holds the values in place
        Mathf.Clamp(nTotalKarmaThreshold, nNegMax, nPosMax);
        Mathf.Clamp(nLightKarma, nNegMax, nPosMax);
        Mathf.Clamp(nDarkKarma, nNegMax, nPosMax);
    }

    private void RoundLogic()
    {
        RoundErrorCatchAndFixes();
    }

    private void RoundErrorCatchAndFixes()
    {
        if (currentRound == 0)
        {
            // prints error and sets current round to 1
            print("Error round is set to zero");
            currentRound = 1;
        }
        if (currentRound == 4)
        {
            // prints error and sets current round to maxRound
            print("Error round is larger than max");
            currentRound = RoundMax;
        }
    }
    private void ObjGets()
    {
        LKarmaText = GameObject.FindGameObjectWithTag("LightKarmaText").GetComponent<Text>();
    }

    private void DebugCommands()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            print("get positive points");
            nLightKarma += 5;
        }
        if (Input.GetKeyDown(KeyCode.N))
        {
            print("lose some points.");
            nLightKarma -= 7;
        }
    }


    // Psuedo Code for Karma Give & Take
    public int AddKarma(int giveKarma)
    {
        if (gameObject.CompareTag("LightActor"))
        {
            nTotalLightPoints.Add(giveKarma);
            nLightPoints.Add(giveKarma);
            return nLightKarma += giveKarma;
        }
        else if (gameObject.CompareTag("DarkActor"))
        {
            nTotalDarkPoints.Add(giveKarma);
            nDarkPoints.Add(giveKarma);
            return nDarkKarma += giveKarma;
        }
        else
        {
            return 0;
        }
    }

    public int DecreaseKarma(int takeKarma)
    {
        if (gameObject.CompareTag("LightActor"))
        {
            // must be a negative integer
            return nLightKarma += takeKarma;
        }
        else if (gameObject.CompareTag("DarkActor"))
        {
            return nDarkKarma += takeKarma;
        }
        else
        {
            return 0;
        }
    }

    public void OnGameStart()
    {
        currentRound = startRound;
    }

    public void NextRound()
    {
        // Updates On Next Round
        currentRound += 1;
        _pastRound = currentRound;
        _lastRoundTotalKarma = nTotalKarmaThreshold;
    }
}
