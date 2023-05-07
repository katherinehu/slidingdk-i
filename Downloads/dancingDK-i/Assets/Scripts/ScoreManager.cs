using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI jewelCount;
    public static ScoreManager instance;

    int score = 0;
    int total;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        total = GameObject.FindGameObjectsWithTag("Jewel").Length;
        jewelCount.text = score.ToString() + "/" + total.ToString();
    }

    public void AddPt()
    {
        score++;
        jewelCount.text = score.ToString() + "/" + total.ToString();
    }
}
