using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Question1Handler : QuestionHandler
{

    [SerializeField] private GameObject parta;
    [SerializeField] private GameObject partb;
    [SerializeField] private GameObject bagRock;
    [SerializeField] private GameObject CorrectObject;

    GameObject VisualTestUI;

    // Start is called before the first frame update
    void Start()
    {
        VisualTestUI = GameObject.Find("VisualTestUI");

        parta = gameObject.transform.GetChild(1).gameObject;
        partb = gameObject.transform.GetChild(2).gameObject;
        bagRock = VisualTestUI.transform.GetChild(4).gameObject.transform.GetChild(1).gameObject;
    }

    // Update is called once per frame
    void Update()
    {

        if (parta.GetComponent<ItemSlot>().isAccepted() && partb.GetComponent<ItemSlot>().isAccepted())
        {
            gameObject.transform.GetChild(3).gameObject.SetActive(true);

            if (questionDone)
                VisualTestUI.GetComponent<UIHandler>().CancelQuestion1();
            else
                StartCoroutine(PauseForASecAndClose());
        }
    }

    private IEnumerator PauseForASecAndClose()
    {
        yield return new WaitForSeconds(0.3f);
        VisualTestUI.GetComponent<UIHandler>().CancelQuestion1();

        //activate Rock in bag UI and make green.
        bagRock.SetActive(true);
        bagRock.GetComponent<Image>().color = new Color32(32, 217, 28, 255);
        bagRock.GetComponent<Button>().interactable = false;

        CorrectObject.GetComponent<Image>().color = new Color32(63, 255, 31, 255);

        questionDone = true;
    }
}
