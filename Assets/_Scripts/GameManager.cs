using TMPro;
using UnityEditor;
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

        // 确保 inputManager 不为空
        if (inputManager != null)
        {
            inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        }
        else
        {
            Debug.LogError("InputManager is not assigned in GameManager!");
        }

        // 游戏开始时禁用设置菜单
        DisableSettingsMenu();
    }

    public void IncreaseScore()
    {
        score++;
        coinCounter.UpdateScore(score);
    }

    private void ToggleSettingsMenu()
    {
        if (isSettingsMenuActive) DisableSettingsMenu();
        else EnableSettingsMenu();
    }

    private void EnableSettingsMenu()
    {
        Time.timeScale = 0f; // 暂停游戏
        settingsMenu.SetActive(true); // 激活设置菜单
        Cursor.lockState = CursorLockMode.None; // 解锁光标
        Cursor.visible = true; // 显示光标
        isSettingsMenuActive = true; // 设置菜单为激活状态
    }

    public void DisableSettingsMenu()
    {
        Time.timeScale = 1f; // 恢复游戏
        settingsMenu.SetActive(false); // 禁用设置菜单
        Cursor.lockState = CursorLockMode.Locked; // 锁定光标
        Cursor.visible = false; // 隐藏光标
        isSettingsMenuActive = false; // 设置菜单为非激活状态
    }

    public void QuitGame()
    {
        EditorApplication.isPlaying = false;
        Application.Quit();
    }
}