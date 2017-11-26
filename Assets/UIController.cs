using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	//テキスト
	private GameObject gameOverText;
	private GameObject runLengthText;

	//走った距離
	private float len=0;
	//速度
	private float speed=0.03f;

	//ゲームオーバーの判定
	private bool isGameOver=false;


	// Use this for initialization
	void Start () {
		//インスタンスを検索
		this.gameOverText=GameObject.Find("GameOver");
		this.runLengthText = GameObject.Find ("RunLength");
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.isGameOver == false) {
			//距離を更新
			this.len += this.speed;
			//距離を表示
			this.runLengthText.GetComponent<Text> ().text = "Distance:" + len.ToString ("F2") + "m";
		}
		//ゲームオーバー時
		if (this.isGameOver) {
			//クリックでリロード
			if (Input.GetMouseButtonDown (0)) {
				//ゲームシーンの読み込み
				SceneManager.LoadScene ("GameScene");
			}
		}
			
		
	}
	public void GameOver(){
		//ゲームオーバー時に画面上にゲームオーバーを表示
		this.gameOverText.GetComponent<Text> ().text = "GameOver";
		this.isGameOver = true;
	}
}
