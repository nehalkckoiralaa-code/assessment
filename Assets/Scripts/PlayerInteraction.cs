using UnityEngine;
using TMPro;
using System.Collections;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance = 3f;

    public TextMeshProUGUI interactText;

    public GameObject warningPanel;

    public TextMeshProUGUI titleText;
    public TextMeshProUGUI messageText;

    // Quiz reference
    public QuizManager quizManager;

    void Start()
    {
        interactText.gameObject.SetActive(false);
        warningPanel.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        // Close warning panel with ESC
        if (warningPanel.activeSelf)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                ClosePanel();
            }

            return;
        }

        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            Interactable interactable = hit.collider.GetComponent<Interactable>();

            if (interactable != null)
            {
                interactText.gameObject.SetActive(true);

                if (Input.GetKeyDown(KeyCode.E))
                {
                    // QUIZ BOARD
                    if (interactable.isQuizBoard)
                    {
                        quizManager.StartQuiz();
                        return;
                    }

                    // NORMAL HAZARD
                    titleText.text = interactable.title;
                    messageText.text = interactable.description;

                    if (!interactable.hasBeenFound)
                    {
                        interactable.hasBeenFound = true;
                        StartCoroutine(ShowHazard(interactable));
                    }
                    else
                    {
                        OpenWarningPanel();
                    }
                }
            }
            else
            {
                interactText.gameObject.SetActive(false);
            }
        }
        else
        {
            interactText.gameObject.SetActive(false);
        }
    }

    IEnumerator ShowHazard(Interactable interactable)
    {
        yield return StartCoroutine(GameManager.Instance.FoundHazard(interactable.title));

        OpenWarningPanel();
    }

    void OpenWarningPanel()
    {
        warningPanel.SetActive(true);
    }

    public void ClosePanel()
    {
        warningPanel.SetActive(false);
    }
}