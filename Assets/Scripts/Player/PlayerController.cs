using UnityEngine;
using Unity.Netcode;

namespace Player
{
    public class PlayerController : NetworkBehaviour
    {
        [SerializeField] private float moveSpeed = 5f;
        [SerializeField] private float maxRangeYMove = 3.5f;
        
        void FixedUpdate()
        {
            if (!IsOwner)
            {
                return;
            }
            if (Input.GetMouseButton(0))
            {
                Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float newY = Mathf.Clamp(clickPosition.y, -maxRangeYMove, maxRangeYMove); // limita o jogador determinado alcance de movimento
                Vector3 newPosition = new Vector3(transform.position.x, newY, transform.position.z);;
                transform.position = Vector3.MoveTowards(transform.position, newPosition, moveSpeed * Time.deltaTime); // adiciona movimento suave para o jogador
            }
            
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 currentPosition = transform.position;

            // Move o objeto apenas no eixo Y
            currentPosition.y += verticalInput * moveSpeed * Time.deltaTime;

            // Atualiza a posição do objeto
            transform.position = currentPosition;
        }

        public override void OnNetworkSpawn()
        {
            Debug.Log("ta spawnando");
            if (!IsOwner)
            {
                transform.position = new Vector3(8.5f, 0);
                Debug.Log("destruindo o playercontroller \n");
                //Destroy(this);
            }
            else
            {
                transform.position = new Vector3(-8.5f, 0);
            }
        }

        public void ResetPosition()
        {
            transform.position = new Vector3(transform.position.x, 0);
        }
    }
}
