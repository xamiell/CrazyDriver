using System.Collections;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static float GAME_SPEED = 1f;
    public static bool isPlayerReady = false;
    public static float delayTime = 1f;
    public static float speedFallingObjects = 5f;
    public static float backgroundScrollSpeed = 0.3f;

    [SerializeField] TextMeshProUGUI playerScoreText;
    [SerializeField] TextMeshProUGUI playerHealthText;
    [SerializeField] TextMeshProUGUI speedLevelText;
    [SerializeField] GameObject menu;
    [SerializeField] AudioClip playButtonSound;

    public int playerHealth;
    public int playerScore;
    public const int pointPerCoin = 500;
    public AudioClip pointGainedSound;
    
    private float _secondsBetweenLevels = 20;
    private int _levelWorld;

    // Start is called before the first frame update
    void Start()
    {
        _levelWorld = 1;
        speedLevelText.text = _levelWorld.ToString();

        InitialPlayerData();
        PlayerLifeFormatter();
    }
    
    // Update is called once per frame
    void Update()
    {
        PlayerLifeFormatter();
        PlayerScoreFormatter();
        speedLevelText.text = _levelWorld.ToString();

        if (playerHealth <= 0)
        {
            isPlayerReady = false;
            menu.SetActive(true);
        }

        if (isPlayerReady)
        {
            LevelUpTheWorld();
        }
    }

    private void LevelUpTheWorld()
    {
        _secondsBetweenLevels -= Time.deltaTime;
        if (_secondsBetweenLevels <= 0)
        {
            _levelWorld += 1;
            _secondsBetweenLevels = 20;
            speedLevelText.text = _levelWorld.ToString();

            backgroundScrollSpeed += 0.1f;
            speedFallingObjects += 1f;
            delayTime -= 0.1f;
        }
    }

    private void PlayerScoreFormatter() => playerScoreText.text = playerScore.ToString();

    private void PlayerLifeFormatter() => playerHealthText.text = $"x{ playerHealth }";

    public void OnPlayButton()
    {
        AudioSource.PlayClipAtPoint(playButtonSound, Camera.main.transform.position);

        InitialPlayerData();
        
        isPlayerReady = true;
        menu.SetActive(false);
    }

    private void InitialPlayerData()
    {
        playerHealth = 3;
        playerScore = 0;

        delayTime = 1f;
        speedFallingObjects = 5f;
        backgroundScrollSpeed = 0.3f;
        _levelWorld = 1;
    }
}
