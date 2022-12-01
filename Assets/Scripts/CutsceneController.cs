using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject killedCutscene;
    [SerializeField] private GameObject sparedCutscene;
    [SerializeField] private GameObject backgroundImage;

    public void KilledCutscene()
    {
        killedCutscene.SetActive(true);
        backgroundImage.SetActive(true);
    }

    public bool KilledCutsceneActive()
    {
        return killedCutscene.activeInHierarchy;
    }

    public void SparedCutscene()
    {
        sparedCutscene.SetActive(true);
        backgroundImage.SetActive(true);
    }

    public bool SparedCutsceneActive()
    {
        return sparedCutscene.activeInHierarchy;
    }
}
