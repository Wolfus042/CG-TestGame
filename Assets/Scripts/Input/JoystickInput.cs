using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickInput : MonoBehaviour
{
    public ActionMap actionMap;
    [HideInInspector]public static JoystickInput current;
    public CharacterController controller;
    public Animator animator;

    public float playerSpeed;

    public Vector3 gravity;

    private void Awake() {
        current = this;
        actionMap = new ActionMap();
    }

    private void OnEnable() {
        if (actionMap != null) {
            actionMap.Enable();
            Debug.Log("actionMap enabled");
        } else {
            Debug.Log("no actionMap found");
        }
    }

    private void FixedUpdate() {
        Vector2 input = actionMap.PlayerMove.Movement.ReadValue<Vector2>();
        Vector3 move = new Vector3(input.x, 0f, input.y);


        if (move == Vector3.zero) {
            Debug.Log("standing");
            animator.SetBool("isRunning", false);
        }else {
            Debug.Log("Running");
            animator.SetBool("isRunning", true);
        }
        move += gravity;

        //Debug.Log("input: "+ input.ToString());
        if (move.z > 0) {
            animator.SetBool("runLeft", false);
            animator.SetBool("runRight", false);
            animator.SetBool("runBack", false);
            animator.SetBool("runForward", true);

            Debug.Log("fwd");
        } else if (move.x > 0) {
            animator.SetBool("runLeft", false);
            animator.SetBool("runRight", true);
            animator.SetBool("runBack", false);
            animator.SetBool("runForward", false);
            Debug.Log("rgh");
        } else if (move.x < 0) {
            animator.SetBool("runLeft", true);
            animator.SetBool("runRight", false);
            animator.SetBool("runBack", false);
            animator.SetBool("runForward", false);
            Debug.Log("lft");
        } else if (move.z < 0) {
            animator.SetBool("runLeft", false);
            animator.SetBool("runRight", false);
            animator.SetBool("runBack", true);
            animator.SetBool("runForward", false);
            Debug.Log("bck");
        }
        //Debug.Log("movement: " + move.ToString());

        controller.Move(move * Time.deltaTime * playerSpeed);
    }
}
