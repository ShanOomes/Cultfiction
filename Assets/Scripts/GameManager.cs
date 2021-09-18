using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    public GameObject video_ending;
    public GameObject video_again;

    public TextMeshProUGUI textMeshPro;
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void End(float outcome)
    {
        print("Cooked: " + outcome);
        if (outcome < 480)
        {
            displayText("product failed, nothing happend");
            video_again.GetComponent<VideoPlayer>().Play();
        }
        else if (outcome > 480 && outcome < 780)
        {
            video_ending.GetComponent<VideoPlayer>().Play();
        }
        else if (outcome > 780)
        {
            displayText("Deadly product, Game over");
        }
    }

    public void displayText(string text)
    {
        textMeshPro.text = text;
    }
}
