using UnityEngine;

public class GameManager : SingletonMonoBehavior<GameManager>
{
    [SerializeField] private int score = 0;
    [SerializeField] private CoinCounterUI coinCounter;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;

    private bool isSettingsMenuActive;

    public bool IsSettingsMenuActive => isSettingsMenuActive;

    protected override void Awake()
    {
        base.Awake();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        DisableSettingsMenu();

        if (coinCounter == null)
        {
            coinCounter = Object.FindFirstObjectByType<CoinCounterUI>();
            if (coinCounter == null)
            {
                Debug.LogError("CoinCounterUI not found in the scene!");
            }
        }
    }

    public void IncreaseScore()
    {
        score++;
        coinCounter.UpdateScore(score);
    }

    private void ToggleSettingsMenu()
    {
        if (isSettingsMenuActive)
        {
            DisableSettingsMenu();
        }
        else
        {
            EnableSettingsMenu();
        }
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f;
        settingsMenu.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        isSettingsMenuActive = true;
    }

    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f;
        settingsMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        isSettingsMenuActive = false;
    }

    public void QuitGame()
    {
# if Unity_Editor
        EditorApplication.isPlaying = false;
# else
        Application.Quit();
# endif
    }
}
