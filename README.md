# Bug Kat's

## 🚀 Como executar o jogo

Para rodar o jogo corretamente, você **PRECISA baixar um arquivo obrigatório** que não está no repositório.

👉 https://drive.google.com/file/d/1ZNMC6EYDqyGQ1AvqGhSZfPj5MZHhDs9G/view?usp=drive_link

### Passo a passo rápido:

1. Baixe o arquivo UnityPlayer.dll pelo link acima  
2. Extraia (se necessário)  
3. Copie o arquivo `UnityPlayer.dll`  
4. Cole na mesma pasta do arquivo .exe (dentro da pasta /build)  
5. Execute o jogo  

⚠️ **Sem esse arquivo o jogo não abre.**

---

## Sobre o Projeto
Jogo do gênero Shoot 'em Up 2D (Top-Down Scrolling) para PC, desenvolvido como atividade prática durante as aulas da disciplina. O jogador controla um gatinho astronauta em sua cápsula espacial para defender a galáxia de hordas de naves invasoras.

---

## Integrantes da Equipe
* Evelin Maria
* Johão Victor
* Rebeca Macedo

---

## Resumo do GDD

* **História e Estética:** Universo em pixel art vibrante (galáxia profunda, planetas e nebulosas). O gatinho enfrenta frotas alienígenas metálicas e avermelhadas.
* **Mecânicas:** Movimentação livre nos eixos horizontal e vertical com sistema de disparo automático e contínuo de lasers verticais.
* **Inimigos:** Naves surgem do topo da tela em formações progressivas, realizam órbitas/mergulhos e atiram projéteis esféricos. Inimigos abatidos geram efeitos visuais de explosão.
* **Loop de Jogo:** Estilo sobrevivência arcade com ondas consecutivas de dificuldade crescente.
* **Fluxo e Interfaces:** 
  * Menu Inicial: Botões "Jogar" (inicia o game) e "Sair" (fecha a aplicação).
  * Interface de Gameplay: HUD limpa focada na ação.
  * Tela de Game Over: Tecla "Espaço" reinicia o jogo; botão "Sou Noob e Desisto" fecha a aplicação.
* **Regra de Derrota:** O jogo acaba ao colidir com naves inimigas ou ser atingido por seus projéteis.

---

## Estrutura do Repositório e Créditos
* **Código-fonte:** Implementação de todas as mecânicas descritas.
* **/build:** Pasta que contém o arquivo executável (.exe) compilado do jogo.
* **Direitos Autorais:** Sprites, scripts e alguns recursos visuais obtidos na Unity Assets Store.
