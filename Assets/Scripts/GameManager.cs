using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; set; }

    public GameObject video_ending;

    public TextMeshProUGUI textMeshPro;

    public GameObject progressBar;
    public TextMeshProUGUI durationText;
    private Image loadingBar;
    private float currentTime;
    private float result;

    public GameObject explosion;
    public bool isCooking;

    public GameObject deathpanel;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            //DontDestroyOnLoad(gameObject);
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
        isCooking = false;
        deathpanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void StartTimer(float duration, bool isStove, float outcome = 0)
    {
        StartCoroutine(Timer(duration, isStove));//TO DO check if coroutine is done
        result = outcome;
        isCooking = true;
    }

    private IEnumerator Timer(float duration, bool isStove)
    {
        progressBar.SetActive(true);
        currentTime = duration;
        while(currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            loadingBar.fillAmount = currentTime / duration;
            durationText.text = currentTime.ToString("F0");
            yield return null;
        }
        progressBar.SetActive(false);
        if(isStove){
            End();
        }
        isCooking = false;
    }

    private void End()
    {
        print("Cooked: " + result);
        if (result < 480)
        {
            displayText("product failed, nothing happend");
            FailedPanel();
        }
        else if (result > 480 && result < 780)
        {
            //video_ending.GetComponent<VideoPlayer>().Play();
        }
        else if (result > 780)
        {
            displayText("Deadly product, Game over");
            FailedPanel();
        }
    }

    public void FailedPanel()
    {
        //Time.timeScale = 0;
        deathpanel.SetActive(true);
    }

    public void Explosion(Transform pos)
    {
        Instantiate(explosion, pos.transform.position, Quaternion.identity);
    }

    public void displayText(string text)
    {
        textMeshPro.text = text;
    }

    public void RestartGame()
    {
        //isCooking = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
