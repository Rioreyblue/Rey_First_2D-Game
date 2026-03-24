using TMPro;
using UnityEngine;

public class LandingPadVisuals : MonoBehaviour
{
    [SerializeField] private TextMeshPro scoreMultiplierTextSmesh;

    private void Awake()
    {
        LandingPad landingPad = GetComponent<LandingPad>();
        scoreMultiplierTextSmesh.text = "x" + landingPad.getScoreMultiplier();
    }
}
