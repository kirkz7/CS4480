using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointController : MonoBehaviour
{
    // Start is called before the first frame update
    public static CheckpointController _instance;
    public GameObject[] checkPoints;
    public GameObject player;
    public GameObject mapCamera;
    public Transform map;
    private Vector3 originalPos;
    private Quaternion originalRot;
    void Start()
    {
        _instance = this;
        originalPos = map.position;
        originalRot = map.rotation;
    }
    //enables/disables checkpoints depending on passed parameter
    //e.g. if we want to disable all checkpoints (hide them from user) once we select one
    public void ActivateCheckpoints(bool activate){
        foreach(GameObject checkpoint in checkPoints){
            checkpoint.SetActive(activate);
        }
    }
    public void SelectCheckpoint(Checkpoint checkpoint){
        ResetPositionAndRotation(); //we want to undo all the panning, zooming and scrolling
        Vector3 position = checkpoint.transform.position;
        CheckpointController._instance.ActivateCheckpoints(false); //hide the checkpoints
        mapCamera.SetActive(false);
        player.transform.position = position;
        player.transform.rotation = checkpoint.transform.rotation;
        player.SetActive(true);
        MouseController._instance.DecrementFocusLevel();
    }
    public void ExitCurrentCheckpoint()
    {
        MouseController._instance.IncrementFocusLevel();
        player.SetActive(false);
        mapCamera.SetActive(true);
        CheckpointController._instance.ActivateCheckpoints(true);
    }
    public void ResetPositionAndRotation(){
        map.position = originalPos;
        map.rotation = originalRot;
    }
}
