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

    public TextMeshProUGUI textMeshPro;

    public GameObject progressBar;
    public TextMeshProUGUI durationText;
    private Image loadingBar;
    public float duration;

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
        loadingBar = progressBar.transform.GetChild(0).GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartTimer(float duration)
    {
        StartCoroutine(Timer(duration));//TO DO check if coroutine is done
    }

    private IEnumerator Timer(float duration)
    {
        progressBar.SetActive(true);
        float startTime = Time.time;
        float time = duration;
        float value = 0;

        while(Time.time - startTime < duration)
        {
            time -= Time.deltaTime;
            value = time / duration;
            loadingBar.fillAmount = value;
            durationText.text = Mathf.Round(time).ToString();
            yield return null;
        }
        progressBar.SetActive(false);
    }

    public void End(float outcome)
    {
        print("Cooked: " + outcome);
        if (outcome < 480)
        {
            displayText("product failed, nothing happend");
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
