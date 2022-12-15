using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Levels : MonoBehaviour
{
    [SerializeField]
    GameObject leftLevel;

    [SerializeField]
    GameObject rightLevel;

    HingeJoint rightjoint;
    HingeJoint leftjoint;

    Control inputActions;

    private void Awake()
    {
        inputActions = new Control();
        inputActions.LevelsControl.LeftLift.performed += context => LeftLevelLift();
        inputActions.LevelsControl.RightLift.performed += context => RightLevelLift();

        inputActions.LevelsControl.LeftLift.canceled += context => LeftLevelDown();
        inputActions.LevelsControl.RightLift.canceled += context => RightLevelDown();
    }
    private void OnEnable()
    {
        inputActions.Enable();
    }
    private void OnDisable()
    {
        inputActions.Disable();
    }
    void Start()
    {
        rightjoint = rightLevel.GetComponent<HingeJoint>();
        leftjoint = leftLevel.GetComponent<HingeJoint>();
    }

    void LeftLevelLift()
    {
        JointSpring spring = leftjoint.spring;
        spring.targetPosition = 40f;
        leftjoint.spring = spring;
    }
    void RightLevelLift()
    {
        JointSpring spring = rightjoint.spring;
        spring.targetPosition = -40f;
        rightjoint.spring = spring;
    }
    void LeftLevelDown()
    {
        JointSpring spring = leftjoint.spring;
        spring.targetPosition = 0;
        leftjoint.spring = spring;
    }
    void RightLevelDown()
    {
        JointSpring spring = rightjoint.spring;
        spring.targetPosition = 0f;
        rightjoint.spring = spring;
    }
}
