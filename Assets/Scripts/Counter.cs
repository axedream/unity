using System.Collections;
using UnityEngine;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class Counter : MonoBehaviour
{
    [SerializeField] private InputMouse _inputMouse;

    private int _sum = 0;

    private bool _isCounting = false;

    private Coroutine _coroutine;

    private WaitForSeconds _waitHalfSecond;

    public event System.Action<int> Changed;

    private void Awake()
    {
        _waitHalfSecond = new WaitForSeconds(0.5f);
    }

    private void OnEnable()
    {
        if (_inputMouse != null)
        {
            _inputMouse.ButtonLeftPressed += ToggleCounting;
        }
    }

    private void OnDestroy()
    {
        if (_inputMouse != null)
        {
            _inputMouse.ButtonLeftPressed -= ToggleCounting;
        }
    }

    private void ToggleCounting()
    {
        _isCounting = !_isCounting;

        if (_isCounting)
        {
            if (_coroutine == null)
            {
                _coroutine = StartCoroutine(ChangeEveryHalfSecond());
            }
        }
        else
        {
            if (_coroutine != null)
            {
                StopCoroutine(_coroutine);

                _coroutine = null;
            }
        }
    }

    private IEnumerator ChangeEveryHalfSecond()
    {
        while (_isCounting)
        {
            yield return _waitHalfSecond;
            
            _sum++;

            Changed?.Invoke(_sum);
        }
    }
}
