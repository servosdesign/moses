using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject killedCutscene;
    [SerializeField] private GameObject sparedCutscene;

    public void KilledCutscene()
    {
        killedCutscene.SetActive(true);
    }

    public bool KilledCutsceneActive()
    {
        return killedCutscene.activeInHierarchy;
    }

    public void SparedCutscene()
    {
        sparedCutscene.SetActive(true);
    }

    public bool SparedCutsceneActive()
    {
        return sparedCutscene.activeInHierarchy;
    }
}
