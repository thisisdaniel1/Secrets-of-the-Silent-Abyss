using UnityEngine;
using TMPro;
using System.Linq;

public class CountdownTimer : MonoBehaviour
{
    public float totalTime = 600f;

    private float currentTime;

    private TMP_Text[] timerTexts;

    /*
    [SerializeField]
    private TMP_Text timerText;

    [SerializeField]
    private TMP_Text timerText2;
    */

    private static CountdownTimer countdownTimer;

    public GameObject blackScreen;

    private AudioManager audioManager;

    private static CountdownTimer instance;

    public static CountdownTimer Instance{
        get{
            if (instance == null){
                instance = FindObjectOfType<CountdownTimer>();
            }
            return instance;
        }
    }

    void Awake(){
        if (instance == null){
            instance = this;
        }
        else if (instance != this){
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // get all the timer texts and store them here
        timerTexts = FindObjectsOfType<TMP_Text>().Where(text => text.gameObject.name == "TimerText").ToArray();
        // if you couldn't tell this is pulled straight form ChatGPT
        // here's its explanation:
        //     FindObjectsOfType<TMP_Text>() returns all instances of TMP_Text in the scene.
        //     Where(text => text.gameObject.name == "Timer_Text") filters the array to only include objects with the name "TimerText."
        //     ToArray() converts the filtered objects into an array.
        //     I would say it makes enough sense and certainly saves me from having to manually populate the array with references

        currentTime = totalTime;

        audioManager = AudioManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.R)){
            DecreaseByOneMinute();
        }
        if (Input.GetKeyDown(KeyCode.T)){
            DecreaseByTwoMinutes();
        }

        if (currentTime <= 0f){
            UpdateTimers(0);
            // if player has ran out of time, enable the black screen and functionally kill them. Also play the kill message
            blackScreen.SetActive(true);

        }
        else{
            // if timer is not up, display current time
            UpdateTimers(currentTime);

            // decrease current time by time passed since last frame
            currentTime = currentTime - Time.deltaTime;
        }
    }

    public void DecreaseByOneMinute(){
        currentTime -= 60f;

        UpdateTimers(currentTime);
    }

    public void IncreaseByOneMinute(){
        currentTime += 60f;

        UpdateTimers(currentTime);
    }

    public void DecreaseByTwoMinutes(){
        currentTime -= 120f;

        UpdateTimers(currentTime);
    }

    public void IncreaseByTwoMinutes(){
        currentTime += 120f;

        UpdateTimers(currentTime);
    }

    void UpdateTimers(float currentTime){
        string formatTime = FormatTime(currentTime);

        foreach (TMP_Text timerText in timerTexts){
            timerText.text = formatTime;
        }
    }

    string FormatTime(float seconds){
        // rounds the total seconds left down to minutes
        int minutes = Mathf.FloorToInt(seconds / 60f);

        // gets the remaining seconds to next minute
        int remainingSeconds = Mathf.FloorToInt(seconds % 60f);

        // both minutes and seconds are represented as two digit numbers
        // with these numbers in the code being placeholders
        return string.Format("{0:00}:{1:00}", minutes, remainingSeconds);
    }
}
