using UnityEngine;

public enum PrimitiveType
{
    Circle,
    Square,
    Hexagon,
    Triangle
}

public enum ColorType
{
    Red,
    Green,
    Blue,
    Yellow
}

public class Character : MonoBehaviour
{
    public GameObject head;
    public GameObject torso;
    public GameObject rightArm;
    public GameObject leftArm;
    public GameObject rightLeg;
    public GameObject leftLeg;
}


