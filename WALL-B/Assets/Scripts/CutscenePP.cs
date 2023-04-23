using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;

public class CutscenePP : MonoBehaviour
{
    [SerializeField] private PostProcessVolume PV;
    private Bloom bloom;
    private ChromaticAberration ca;
    private bool startEffects = false;

    private void Awake()
    {
        PV.profile.TryGetSettings<Bloom>(out bloom);
        PV.profile.TryGetSettings<ChromaticAberration>(out ca);
    }

    // Start is called before the first frame update
    void Start()
    {
        bloom.intensity.Override(0);
        ca.intensity.Override(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (startEffects)
        {
            bloom.intensity.Override(bloom.intensity + Time.deltaTime * 2);
            ca.intensity.Override(ca.intensity + Time.deltaTime / 5);
        }
    }

    public void StartEffect()
    {
        startEffects = true;
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene("Level1Test");
    }
}
