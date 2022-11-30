using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableRock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Rock.RockType types;
    void OnDisable()
    {
        Pickaxe.dic[types].SetActive(false);
    }
}
