using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class Move : MonoBehaviour
{
    private CharacterController characterController;
    public bool onQuiz = false;
    public float movementSpeed = 5f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!onQuiz)
        {
            //see how much our Player is pressing down on the relevant axis' (on a keyboard it would be binary but unity automatically smooths out the inputs, which is cool)
            Vector3 forward = Input.GetAxis("Vertical") * transform.forward;
            Vector3 horizontal = Input.GetAxis("Horizontal") * transform.right;

            //normalize the resultant vector
            Vector3 normalized = (forward + horizontal).normalized;
            Vector3 fineMovement = (forward + horizontal);
            Vector3 movement = fineMovement;

            //make sure we don't move faster on diagonals (i.e. sqrt(2) * movementSpeed)
            if (fineMovement.magnitude > normalized.magnitude)
            {
                movement = normalized;
            }

            //actually move the player
            characterController.SimpleMove(movement * movementSpeed);

            //Check if falling off the map
            if (transform.position.y <= -10)
            {
                transform.position = new Vector3(0, 1, 0);
            }

            //press escape to exit first-person player mode
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Rock")
        {
            RockGroup rg = other.GetComponentInParent<RockGroup>();
            ToolbarUI.Instance.HighlightUsableTools(rg.getUsableTools());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        ToolbarUI.Instance.RemoveHighlights();
    }


}
