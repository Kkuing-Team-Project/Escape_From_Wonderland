using UnityEngine;

public class h : StateMachineBehaviour
{
    public AudioClip soundClip; // 재생할 사운드 클립

    private AudioSource audioSource;
    private bool audioSourceWasInitiallyDisabled;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        PlaySound(animator.gameObject);
    }

    private void PlaySound(GameObject gameObject)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSourceWasInitiallyDisabled = !audioSource.enabled;

        // Enable the AudioSource temporarily to play the sound
        if (audioSourceWasInitiallyDisabled)
        {
            audioSource.enabled = true;
        }

        audioSource.clip = soundClip;
        audioSource.Play();

        // Disable the AudioSource if it was initially disabled
        if (audioSourceWasInitiallyDisabled)
        {
            audioSource.enabled = false;
        }
    }
}
