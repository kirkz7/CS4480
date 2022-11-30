using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public enum RockType { Group1, Group2, Group3, Group4, Group5, Group6, Group7 };
    [SerializeField] private RockType type;
    void Start()
    {
        type = transform.parent.GetComponent<RockGroup>().rockType;
    }
    public RockType GetRockType()
    {
        return type;
    }
    public void Mine(){
        LeftArmController._instance.enableRock(GetRockType(), true);
        if(!UIHandler.instance.CheckIfMined(GetRockType())){
        NotificationManager._instance.Notify("Rock sample added to bag");
        }else{
            if(UIHandler.instance.CheckRockComplete(GetRockType())){
                NotificationManager._instance.Notify("This rock group is complete");
            }else{
                NotificationManager._instance.Notify("This rock group has questions remaining");
            }
        }
        UIHandler.instance.CollectRockGroup(GetRockType());
    }
    public void OpenUI()
    {
        MouseController._instance.IncrementFocusLevel();
        UIHandler.instance.OpenQuestion(GetRockType());
    }
    void OnTriggerStay(Collider col)
    {
        RockMiner rockMiner = col.GetComponent<RockMiner>();
       if(rockMiner){
           if(rockMiner.canMine){
               Mine();
               rockMiner.Mine();
           }
       }
    }
}
