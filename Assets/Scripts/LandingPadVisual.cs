using TMPro;
using UnityEngine;

public class LandingPadBehaviour : MonoBehaviour
{
 [SerializeField] private TextMeshPro scoreMultiplierTextSmesh;

 private void Awake()
    {
        LandingPad landingPad = GetComponent<LandingPad>();
        scoreMultiplierTextSmesh.text = "x" + landingPad.getScoreMultiplier();
    }
}
