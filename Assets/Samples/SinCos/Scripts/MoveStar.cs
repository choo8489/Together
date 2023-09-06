using System;
using UnityEngine;
using UniRx;

public class MoveStar : MonoBehaviour
{
    #region [ Variables ]
    [SerializeField] private float speed = 1;
    private int currentStep = 1;
    #endregion

    #region [ MonoBehaviour CallBacks ]
    private void OnEnable()
    {
        int length = RegisterMoveStart();
        RegisterMouseButtonUp(length);
    }
    #endregion

    #region [ Register Events ]
    private void RegisterMouseButtonUp(int actionsLength)
    {
        Observable.EveryUpdate()
            .Where(_ => Input.GetMouseButtonUp(0))
            .Subscribe(_ =>
            {
                ChangeStep();
            }).AddTo(this);

        void ChangeStep()
        {
            currentStep++;

            if (currentStep > actionsLength)
                currentStep = 1;
        }
    }

    private int RegisterMoveStart()
    {
        Vector3 retVector = Vector3.zero;

        Action<float>[] actions = new Action<float>[3];
        actions[0] = (theta) => StepOne(theta);
        actions[1] = (theta) => StepTwo(theta);
        actions[2] = (theta) => StepThree(theta);

        Observable.EveryUpdate()
           .Subscribe(_ =>
           {
               retVector = Vector3.zero;
               float theta = Time.realtimeSinceStartup * speed;

               for (int i = 0; i < currentStep; i++)
               {
                   actions[i](theta);
               }

               this.transform.position = retVector;
           }).AddTo(this);

        void StepOne(float theta)
        {
            retVector.x += 3 * MathF.Cos(theta);
            retVector.y += 3 * MathF.Sin(theta);
        }

        void StepTwo(float theta)
        {
            retVector.x += 2 * MathF.Cos(3 * theta);
            retVector.y += 2 * MathF.Sin(3 * theta);
        }

        void StepThree(float theta)
        {
            retVector.x += MathF.Cos(15 * theta);
            retVector.y += MathF.Sin(15 * theta);
        }

        return actions.Length;
    }
    #endregion
}
