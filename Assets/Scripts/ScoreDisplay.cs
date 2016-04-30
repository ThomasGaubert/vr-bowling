using UnityEngine;
using System.Collections;

public class ScoreDisplay : MonoBehaviour {
	
	
	public ScoreKeeper _ScoreKeeper;
    public TextMesh _Frame;
    public TextMesh _Score;
	
	void Update()
	{
        _Frame.text = _ScoreKeeper._Frame.ToString();
        _Score.text = _ScoreKeeper._Score.ToString();
	}
}
