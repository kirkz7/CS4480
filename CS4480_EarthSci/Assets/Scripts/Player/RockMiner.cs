using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockMiner : MonoBehaviour
{
    public bool canMine;
    public virtual void Mine(){
        GameObject.Destroy(gameObject);
    }
}
