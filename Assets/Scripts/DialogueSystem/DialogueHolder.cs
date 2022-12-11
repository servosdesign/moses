using System.Collections;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueHolder : MonoBehaviour
    {
        private IEnumerator dialogueSeq;
        public Animator killedCutsceneAnimation;
        public Animator sparedCutsceneAnimation;

        private bool dialogueFinsihed;
        public bool cutscene;

        private void OnEnable()
        {
            if (cutscene && !PauseManager.isPaused)
            {
                if (killedCutsceneAnimation)
                {
                    killedCutsceneAnimation.Play("cutscene-fadein");
                }
                else if (sparedCutsceneAnimation)
                {
                    sparedCutsceneAnimation.Play("cutscene-fadein2");
                }
            }

            dialogueSeq = dialogueSequence();
            StartCoroutine(dialogueSeq);
        }

        private void Update()
        {
            if (!cutscene && !PauseManager.isPaused)
            {
                if (Input.GetMouseButtonDown(1))
                {
                    Deactivate();
                    gameObject.SetActive(false);
                    StopCoroutine(dialogueSeq);
                }
            }
        }

        private IEnumerator dialogueSequence()
        {
            if (!dialogueFinsihed)
            {
                for (int i = 0; i < transform.childCount - 1; i++)
                {
                    Deactivate();
                    transform.GetChild(i).gameObject.SetActive(true);
                    yield return new WaitUntil(() => transform.GetChild(i).GetComponent<DialogueLine>().finished);
                }
            }
            else
            {
                int index = transform.childCount - 1;
                Deactivate();
                transform.GetChild(index).gameObject.SetActive(true);
                yield return new WaitUntil(() => transform.GetChild(index).GetComponent<DialogueLine>().finished);
            }
            dialogueFinsihed = true;
            gameObject.SetActive(false);
        }

        private void Deactivate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
}

