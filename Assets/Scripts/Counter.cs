using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text CounterText;

    private int _counter = 0;

    private bool _isCounting = false;

    private Coroutine _countingCoroutine;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ToggleCounting();
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            if (_countingCoroutine == null)
            {
                _countingCoroutine = StartCoroutine(CountEveryHalfSecond());
            }
        }
        else
        {
            if (_countingCoroutine != null)
            {
                StopCoroutine(_countingCoroutine);

                _countingCoroutine = null;
            }
        }
    }

    private IEnumerator CountEveryHalfSecond()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            
            _counter++;
            
            UpdateCounterDisplay();
        }
    }

    private void UpdateCounterDisplay()
    {
        
        Debug.Log($"Текущее значение счетчика: {_counter}");

        if (CounterText != null)
        {
            CounterText.text = _counter.ToString();
        }
    }
}
