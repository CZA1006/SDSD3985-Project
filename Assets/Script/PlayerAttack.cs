using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    AudioSource attackAudio;

    private void Update()
    {
        attackAudio = GetComponent<AudioSource>();
        if (Input.GetMouseButtonDown(0))
        {
            Attack();
            StartCoroutine(FindObjectOfType<CameraController>().CameraShakeCo(0.2f, 0.2f));
        }
    }

    private void Attack()
    {
        transform.GetChild(0).gameObject.SetActive(true);
        attackAudio.Play();

        //Mouse Direction = mouse Pos - current player pos 鼠标位置「目标点位置」-当前位置「人物所在位置」
        Vector2 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;//Radius -> Degree 弧度转角度
        transform.rotation = Quaternion.Euler(0, 0, rotZ);
    }
}
