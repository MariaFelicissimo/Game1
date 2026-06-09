
🎮 Game1:
Descrição do Jogo
Este é um jogo 3D desenvolvido no Unity que desafia o jogador a navegar por um cenário dinâmico, coletando esferas para alcançar a pontuação máxima. O foco do projeto foi a implementação de movimentação fluida do jogador e gerenciamento de estados de jogo.

Instruções de Jogabilidade
Movimentação: Utilize as teclas W, A, S, D para mover o personagem pelo cenário.

Câmera: Mova o Mouse para rotacionar a visão em torno do personagem.

Coleta: Aproxime-se dos objetos flutuantes (esferas) para coletá-los automaticamente.

Objetivo: Colete todas as esferas do cenário no menor tempo possível.

Gameplay
(https://youtube.com/shorts/L9wpc5zf2UQ?si=_5H1KaWmoMdK6mwc)

Galeria de Imagens
Funcionalidades Desenvolvidas
1. Sistema de Coleta (Coletavel.cs)
Foi desenvolvido um sistema de colisão que identifica quando o jogador entra em contato com um objeto, destruindo o item coletado e atualizando a pontuação no GameManager.

C#
// Trecho do código para detecção de coleta
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Player"))
    {
        // Atualiza a pontuação no gerenciador do jogo
        GameManager.instance.AdicionarPontos(10);
        // Remove o objeto da cena
        Destroy(gameObject);
    }
}
<img width="1919" height="1079" alt="Screenshot_1" src="https://github.com/user-attachments/assets/0b8be58e-6a5d-4343-bfbb-7061b24a4d5a" />


2. Sistema de Movimentação (Movimentacao.cs)
Implementamos uma movimentação baseada na direção da câmera, permitindo que o personagem se desloque de forma intuitiva, mantendo a orientação do corpo do personagem alinhada com o movimento.

C#
// Trecho do código para movimentação do jogador
void Update()
{
    float horizontal = Input.GetAxis("Horizontal");
    float vertical = Input.GetAxis("Vertical");
    
    Vector3 direcao = new Vector3(horizontal, 0, vertical);
    transform.Translate(direcao * velocidade * Time.deltaTime);
}
<img width="1919" height="1079" alt="Screenshot_2" src="https://github.com/user-attachments/assets/4e49e785-019b-4ef2-a3a7-94dfda6d0749" />
<img width="1026" height="470" alt="Screenshot_5" src="https://github.com/user-attachments/assets/33f6b301-6bc0-43b7-bb9f-45393bceaae2" />
<img width="1012" height="488" alt="Screenshot_3" src="https://github.com/user-attachments/assets/77be393b-4427-4d74-9e58-27659b363457" />
<img width="1015" height="457" alt="Screenshot_4" src="https://github.com/user-attachments/assets/d9dda5ab-3081-4883-9e6a-fa95a95951db" />
