using UnityEngine;

public class RotationController : MonoBehaviour
{
    [Range(0f, 0.125f)]
    public float RotationFactor; //how fast to rotate card
    [Range(2, 64)]
    public int ReturnCardInFrames; //how fast to lerp card

    //public CardState cardState;

    public void RotateCard() //rotates card as user swipes
    {
        float rotationFactor = -1 * RotationFactor * Input.touches[0].deltaPosition.x;
        transform.Rotate(0f, 0f, rotationFactor);
    }

    public void ResetRotationOfCard() //recall card to its deck position (LERP)
    {
        float pointZero = 0f;
        float middlePoint = 180f;
        float currentRotationZ = transform.eulerAngles.z;

        currentRotationZ = currentRotationZ < middlePoint ? currentRotationZ : currentRotationZ - 360;

        float rotationGap = currentRotationZ - pointZero;
        float rotatingFactor = -1 * (rotationGap / ReturnCardInFrames);

        if (currentRotationZ > 0.1f || currentRotationZ < -0.1f)
        {
            transform.Rotate(0f, 0f, rotatingFactor);
        }
    }
}
