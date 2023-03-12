using System.Collections;
using UnityEngine;

namespace Common.Scripts
{
    public class DestroyByTime : MonoBehaviour
    {
        [SerializeField] private float _destroyTime = 2f;

        private IEnumerator Start()
        {
            yield return new WaitForSeconds(_destroyTime);
            Destroy(gameObject);
        }
    }
}