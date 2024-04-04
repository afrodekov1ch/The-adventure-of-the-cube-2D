using UnityEngine;
using UnityEngine.UI;

public class PanelController : MonoBehaviour
{
    public GameObject panel; // ссылка на панель, которую вы хотите отобразить/скрыть
    private bool isPanelActive; // флаг, показывающий, активна ли панель в данный момент
    public Button enableButton; // кнопка для включения панели
    public Button disableButton; // кнопка для выключения панели

    void Start()
    {
        // Подписываемся на события нажатия кнопок
        enableButton.onClick.AddListener(EnablePanel);
        disableButton.onClick.AddListener(DisablePanel);

        // По умолчанию панель скрыта
        panel.SetActive(false);
        isPanelActive = false;
    }

    public void EnablePanel()
    {
        if (!isPanelActive)
        {
            isPanelActive = true;
            panel.SetActive(true);
            Time.timeScale = 0f; // Поставить игру на паузу
        }
    }

    public void DisablePanel()
    {
        if (isPanelActive)
        {
            isPanelActive = false;
            panel.SetActive(false);
            Time.timeScale = 1f; // Возобновить игру
        }
    }
}