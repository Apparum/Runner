using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	/*
	 * 
	 * Mettre des PowerUps
	 * Mettre des rampes
	 * Faire la déco du jeu
	 * Interface Graphique (Menu/Choix Diff/Tps/Score etc)
	 * Score bonus quand on frole les obstacle
	 * Sons des bonus etc...
	 * Musique
	 * Affichage special avec certains score (milestone)
	 * Rajouter des éléments (petit mur droit en face de la position en x / 8-12 blocs individuel random / 3 ptites diag -/-/-/- et dans l'autre sens)  
	 * Deposer des coins
	 * 
	 */

	bool gameHasEnded = false;

	public float restartDelay = 1f;

	public GameObject completeLevelUI;

	public void CompleteLevel()
	{
		completeLevelUI.SetActive(true);
	}

	public void EndGame()
	{
		if (!gameHasEnded)
		{
			gameHasEnded = true;
			Debug.Log("GAME OVER");
			Invoke("Restart", restartDelay);
		}
	}
	
	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
