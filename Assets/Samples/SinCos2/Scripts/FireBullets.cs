using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;

public class FireBullets : MonoBehaviour
{
    #region [ Variables ]
    public GameObject bulletObj;
    public Transform bulletPoint;
    public float interval;
    public int count;
    public float angle;
    #endregion

    #region [ MonoBehaviour CallBacks ]
    private void OnEnable()
    {
        RegisterFire();
    }
    #endregion

    #region [ Register Methods ]
    private void RegisterFire()
    {
        Observable.FromCoroutine(FireLoop)
            .Subscribe().AddTo(this);

        IEnumerator FireLoop()
        {
            var waitForSeconds = new WaitForSeconds(interval);

            while (IsVaildCondition())
            {
                float gap = (count > 1) ? angle / (float)(count - 1) : 0;
                float startAngle = -angle / 2.0f;

                for (int i = 0; i < count; i++)
                {
                    float theta = startAngle + gap * (float)i;
                    theta *= Mathf.Deg2Rad;

                    GameObject go = Instantiate(bulletObj, bulletPoint.position, Quaternion.identity);
                    var bullet = go.GetComponent<Bullet>();
                    bullet.Initialize(disappearTime: 3.0f, speed: 100);
                    bullet.SetNormalizedDirection(new Vector3(Mathf.Cos(theta), Mathf.Sin(theta), 0));
                }

                yield return waitForSeconds;
            }
        }

        bool IsVaildCondition()
            => interval > 0 && count > 0;
    }
    #endregion
}
