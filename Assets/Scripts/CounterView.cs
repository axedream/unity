using TMPro;
using UnityEngine;

public class CounterView : MonoBehaviour
{
    [SerializeField] private Counter _counter;
    [SerializeField] private TMP_Text _text;

    private void OnEnable()
    {
        if (_counter != null)
        {
            _counter.Changed += UpdateView;
        }
    }

    private void OnDisable()
    {
        if (_counter != null)
        {
            _counter.Changed -= UpdateView;
        }
    }

    private void UpdateView(int value)
    {
        if (_text != null)
        {
            _text.text = value.ToString();
        }
    }
}
