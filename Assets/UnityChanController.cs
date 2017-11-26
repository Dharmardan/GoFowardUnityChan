using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanController : MonoBehaviour {
	
	//コンポーネント
	Animator animator;
	Rigidbody2D rigid2D;

	//ジャンプ速度の減衰
	private float dump=0.8f;
	//ジャンプ速度
	float jumpVelocity=20;

	//地面の位置
	private float groundLevel=-3.0f;

	//ゲームオーバー位置
	private float deadLine=-9;


	// Use this for initialization
	void Start () {
		//コンポーネント取得
		this.animator=GetComponent<Animator>();
		this.rigid2D = GetComponent<Rigidbody2D> ();
		
	}
	
	// Update is called once per frame
	void Update () {
		//パラメーター調節
		this.animator.SetFloat("Horizontal",1);
		//着地しているか調べる
		bool isGround=(transform.position.y>this.groundLevel)?false:true;
		this.animator.SetBool ("isGround", isGround);

		//ジャンプ状態で消音
		GetComponent<AudioSource>().volume=(isGround)?1:0;

		//着地状態でクリックされた場合
		if (Input.GetMouseButton (0) && isGround) {
			//上方向の力をかける
			this.rigid2D.velocity = new Vector2 (0, this.jumpVelocity);
		}
		//クリックをやめたら減速
		if (Input.GetMouseButton (0) == false) {
			if (this.rigid2D.velocity.y > 0) {
				this.rigid2D.velocity *= this.dump;
			}
		}
		//デッドラインを超えたらゲームオーバーにする
		if (transform.position.x < this.deadLine) {
			//UIControllerのGameOver関数を呼び出してゲームオーバーを表示
			GameObject.Find ("Canvas").GetComponent<UIController> ().GameOver ();
			//Unityちゃんを廃棄
			Destroy (gameObject);
		}
		
	}
}
