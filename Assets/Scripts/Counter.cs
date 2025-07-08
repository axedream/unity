using System.Collections;
using TMPro;
using UnityEngine;

public class Counter : MonoBehaviour
{
    [SerializeField] private TMP_Text CounterText;

    private int _counter = 0;

    private bool _isCounting = false;

    private Coroutine _countingCoroutine;

    private WaitForSeconds _waitHalfSecond;

    private void Awake()
    {
        _waitHalfSecond = new WaitForSeconds(0.5f); // Создаем один раз
    }

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
        while (_isCounting)
        {
            yield return _waitHalfSecond;
            
            _counter++;
            
            UpdateCounterDisplay();
        }
    }

    private void UpdateCounterDisplay()
    {
        if (CounterText != null)
        {
            CounterText.text = _counter.ToString();
        }
    }
}
