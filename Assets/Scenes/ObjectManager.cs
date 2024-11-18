using UnityEngine;

public class ObjectManager : MonoBehaviour
{
    public GameObject[] objects; // Danh sách các v?t th? trong dãy
    public Transform[] emptySlots; // Danh sách các ô tr?ng

    void Update()
    {
        // Ki?m tra khi ng??i ch?i click chu?t
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Ki?m tra xem chu?t ?ã ch?m vào v?t th? nào hay không
            if (Physics.Raycast(ray, out hit))
            {
                GameObject clickedObject = hit.transform.gameObject;

                // Ki?m tra xem v?t th? ???c ch?n có trong danh sách không
                if (System.Array.Exists(objects, obj => obj == clickedObject))
                {
                    // Tìm v? trí c?a v?t th? ???c ch?n trong danh sách
                    int objectIndex = System.Array.IndexOf(objects, clickedObject);

                    // Ki?m tra xem có ô tr?ng nào không
                    if (objectIndex < emptySlots.Length)
                    {
                        // Di chuy?n v?t th? ???c ch?n ??n v? trí c?a ô tr?ng
                        clickedObject.transform.position = emptySlots[objectIndex].position;
                    }
                }
            }
        }
    }
}
