using UnityEngine;
using UniRx;

// �̹��� ��ó : <a href="https://kr.freepik.com/free-vector/sticker-template-with-unidentified-flying-object-ufo-isolated_18384112.htm#query=%EC%9A%B0%EC%A3%BC%EC%84%A0&position=2&from_view=search&track=sph">�۰� brgfx</a> ��ó Freepik
public class Bullet : MonoBehaviour
{
    #region [ Variables ]
    private Vector3 velo;
    private float speed;
    #endregion

    #region [ MonoBehaviour CallBacks ]
    private void OnEnable()
    {
        RegisterMoveBullet();
    }
    #endregion

    #region [ Public Methods ]
    public void Initialize(float disappearTime, float speed)
    {
        this.speed = speed;

        Destroy(gameObject, disappearTime);
    }

    public void SetNormalizedDirection(Vector3 dir)
        => velo = dir * speed;
    #endregion

    #region [ Private Methods ]
    private void RegisterMoveBullet()
    {
        Observable.EveryUpdate()
            .Select(_ => velo * Time.deltaTime)
            .Subscribe(delta =>
            {
                transform.position += delta;
            }).AddTo(this);
    }
    #endregion
}
