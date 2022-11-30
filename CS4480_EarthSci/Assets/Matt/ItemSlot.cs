using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour, IDropHandler
{

    public string acceptableAnswer;
    public bool accepted = false;

    public void OnDrop(PointerEventData eventData)
    {

        if (!accepted) {

            DragNDropHandler handler = eventData.pointerDrag.GetComponent<DragNDropHandler>();

            if (handler.answer == acceptableAnswer)
            {
                accepted = true;
                gameObject.transform.GetChild(0).gameObject.SetActive(true);
                this.GetComponent<Image>().color = new Color32(83, 255, 96, 255);
            }
            else{
                StartCoroutine(FlashRed());
                ScoreController._instance.AdjustScore(-2);
            }
        }
    }

    private IEnumerator FlashRed()
    {

        this.GetComponent<Image>().color = new Color32(255, 50, 50, 255);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Image>().color = new Color32(255, 50, 50, 255);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Image>().color = new Color32(255, 50, 50, 255);
        yield return new WaitForSeconds(0.1f);
        this.GetComponent<Image>().color = new Color32(255, 255, 255, 255);
    }
    private IEnumerator checkIfComplete(){
        yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.3f);
        if(UIHandler.instance.checkAllComplete()){
            Debug.Log("You beat the game!!!");
        }
    }

    public bool isAccepted()
    {
        return accepted;
    }
}
