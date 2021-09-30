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

    [Header("Progress-bar")]
    public GameObject progressBar;
    public TextMeshProUGUI durationText;

    private Image loadingBar;
    private float currentTime;
    private float result;

    public GameObject explosion;
    public bool isCooking;

    [Header("Death panel")]
    public GameObject deathpanel;

    [Header("Popup")]
    public GameObject popUpBox;
    public TextMeshProUGUI popUp_titel;
    public TextMeshProUGUI popUp_deatchance;
    public TextMeshProUGUI popUp_failureRate;
    public TextMeshProUGUI popUp_multiplier;
    public TextMeshProUGUI popUp_type;

    public GameObject panel;

    [Header("Audio")]
    public AudioSource audioMicrowave;
    public AudioSource audioStove;

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
        panel.SetActive(true);
    }
    // Start is called before the first frame update
    void Start()
    {
        loadingBar = progressBar.transform.GetChild(0).GetComponent<Image>();
        isCooking = false;
        deathpanel.SetActive(false);
    }

    public void StartTimer(float duration, bool isStove, float outcome = 0)
    {
        StartCoroutine(Timer(duration, isStove));//TO DO check if coroutine is done
        result = outcome;
        isCooking = true;
    }

    private IEnumerator Timer(float duration, bool isStove)
    {
        if(isStove)
        {
            audioStove.Play(0);
        }else
        {
            audioMicrowave.Play(0);
        }
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
            audioStove.Pause();
        }else{
            audioMicrowave.Pause();
        }
        isCooking = false;
    }

    private void End()
    {
        print("Cooked: " + result);
        if (result < 230)
        {
            displayText("product failed, nothing happend");
            FailedPanel();
        }
        else if (result > 230 && result < 400)
        {
            video_ending.GetComponent<VideoPlayer>().Play();
        }
        else if (result > 400)
        {
            displayText("Deadly product, Game over");
            FailedPanel();
        }
    }

    public void FailedPanel()
    {
        Time.timeScale = 0;
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
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void setPopUp(Ingredient ing)
    {
        StartCoroutine(PopUp(ing));
    }

    private IEnumerator PopUp(Ingredient ingredient)
    {
        popUpBox.SetActive(true);

        popUp_titel.text = ingredient.Name;
        popUp_deatchance.text = "Death Chance: " + ingredient.DeathChance.ToString();
        popUp_failureRate.text = "Failure rate: " + ingredient.FailureRate.ToString();
        popUp_multiplier.text = "Multiplier: " + ingredient.Multiplier.ToString();
        popUp_type.text = "Type: " + ingredient.Type.ToString();

        yield return new WaitForSeconds(5);

        popUpBox.SetActive(false);
    }

    public void PanelOff()
    {
        panel.SetActive(false);
    }
}
