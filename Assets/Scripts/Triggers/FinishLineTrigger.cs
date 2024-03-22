using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLineTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider colliderInfo)
    {
        if (colliderInfo.transform.CompareTag("Player"))
        {
            GameManager.Instance.CompleteLevel();
        }
    }
}
