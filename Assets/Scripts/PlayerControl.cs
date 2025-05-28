using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask; // Layer of clickable ground
    [SerializeField] private Collider[] weapons;

    private CharacterController characterController;
    private Animator animator;

    private Vector3 targetPosition;
    private Vector3 velocity;
    private float gravity = -20f;
    private float moveSpeed = 7;

    public void ToggleWeapons(bool enable)
    {
        foreach (Collider weapon in weapons)
        {
            weapon.enabled = enable;
        }
    }

    void Start()
    {
        ToggleWeapons(false);
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        targetPosition = transform.position;

        if (characterController == null)
            Debug.LogError("CharacterController not found!");
    }

    public void BeginAttack()
    {
        ToggleWeapons(true);
    }

    public void EndAttack()
    {
        ToggleWeapons(false);
    }

    void Update()
    {
        Debug.Log("PlayerHealth.isAlive: " + PlayerHealth.isAlive);

        // Gravity
        if (!characterController.isGrounded)
        {
            velocity.y += gravity * Time.deltaTime;
        }
        else
        {
            velocity.y = -1f; // Helps stick to ground
        }

        float distToTarget = Vector3.Distance(targetPosition, transform.position);
        Debug.Log("Distance to target: " + distToTarget);

        if (distToTarget > 0.5f && PlayerHealth.isAlive)
        {
            Vector3 direction = (targetPosition - transform.position);
            direction.y = 0; // Keep movement flat on ground
            direction = direction.normalized;

            Vector3 move = direction * moveSpeed;
            move.y = velocity.y;

            characterController.Move(move * Time.deltaTime);
            animator.SetBool("Running", true);
        }
        else
        {
            animator.SetBool("Running", false);
        }

        // Left-click movement
        if (Input.GetMouseButtonDown(0) && PlayerHealth.isAlive)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Debug ray
            Debug.DrawRay(ray.origin, ray.direction * 500f, Color.red, 1f);

            if (Physics.Raycast(ray, out hit, 500f, layerMask))
            {
                Debug.Log("Hit: " + hit.collider.name + " at " + hit.point);
                targetPosition = hit.point;
                transform.LookAt(new Vector3(targetPosition.x, transform.position.y, targetPosition.z));
            }
            else
            {
                Debug.LogWarning("Raycast did NOT hit anything on layerMask: " + layerMask.value);
            }
        }

        // Right-click attack
        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Stab");
        }
    }
}
