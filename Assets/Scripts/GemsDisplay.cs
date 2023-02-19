using UnityEngine;
using TMPro;

public class GemsDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private TMP_Text _gemsDisplay;

    private void OnEnable()
    {
        _player.OnGemsChanged += OnGemsGhanged;
    }

    private void OnDisable()
    {
        _player.OnGemsChanged -= OnGemsGhanged;
    }

    private void OnGemsGhanged(int gemsCount)
    {
        _gemsDisplay.text = gemsCount.ToString();
    }
}
