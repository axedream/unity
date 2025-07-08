using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _counterText;

    private void OnEnable()
    {
        if (_counter != null)
        {
            _counter.CountChanged += UpdateView;
        }
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.CountChanged -= UpdateView;
        }
    }

    private void UpdateView(int value)
    {
        if (_counterText != null)
        {
            _counterText.text = value.ToString();
        }
    }
}
