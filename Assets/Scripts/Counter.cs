using System.Collections;
using UnityEngine;

public class Counter : MonoBehaviour
{
    private int _counter = 0;

    private bool _isCounting = false;

    private Coroutine _countingCoroutine;

    private WaitForSeconds _waitHalfSecond;

    public event System.Action<int> CountChanged;

    private void Awake()
    {
        _waitHalfSecond = new WaitForSeconds(0.5f);
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

            CountChanged?.Invoke(_counter);
        }
    }
}
