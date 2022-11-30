using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionHandler : MonoBehaviour
{
    protected bool questionDone = false;
    public bool isQuestionFullyAnswered()
    {
        return questionDone;
    }
}
