using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject fizz;
    public GameObject fizzWeak;

    public float acidLifetime = 5.0f;

    void Start()
    {
        Destroy(gameObject, acidLifetime);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null)
        {
            RockGroup rockGroup = other.transform.parent.GetComponent<RockGroup>();
            if (rockGroup != null)
            {
                switch (rockGroup.reactionType)
                {
                    case RockGroup.AcidReaction.Strong:
                        GameObject fizzGO = GameObject.Instantiate(fizz);
                        fizzGO.transform.position = transform.position;
                        break;
                    case RockGroup.AcidReaction.Weak:
                        GameObject weakFizzGO = GameObject.Instantiate(fizzWeak);
                        weakFizzGO.transform.position = transform.position;
                        break;
            }
        }
    }
    GameObject.Destroy(gameObject);
    }
}
