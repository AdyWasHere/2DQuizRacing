using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.UI;


public class QuizManager : MonoBehaviour {


	public Questions[] questions;
	private static List<Questions> unansweredQuestions;

	private Questions currentQuestion;

	[SerializeField]
	private Text QuestionText;

	[SerializeField]
	Text Answer1;

	[SerializeField]
	Text Answer2;

	[SerializeField]
	Text Answer3;

	bool isAnswered;

	public GameObject QuestionPanel;

	void Start () {
		
		isAnswered = false;
		QuestionPanel.SetActive (true);
		if (unansweredQuestions == null || unansweredQuestions.Count == 0) {

			unansweredQuestions = questions.ToList<Questions> ();



		}

		GetRandomQuestion ();

	}

	void GetRandomQuestion()
	{
		int randomQuestionIndex = Random.Range (0, unansweredQuestions.Count);
		currentQuestion = unansweredQuestions [randomQuestionIndex];

		QuestionText.text = currentQuestion.Question.ToString();
		Answer1.text = currentQuestion.Answer1.ToString ();
		Answer2.text = currentQuestion.Answer2.ToString ();
		Answer3.text = currentQuestion.Answer3.ToString ();



		unansweredQuestions.RemoveAt (randomQuestionIndex);


	}

	void Update () {

		if (isAnswered) {
			isAnswered = false;

			Debug.Log("Getting into Coroutine");
			StartCoroutine (Waiting(2.0f));

			GetRandomQuestion ();

	


		}

	}

	public void VerifyAnswer(int index)
	{

		if (index == currentQuestion.cAnswer) {

			CorrectAnswer ();
			isAnswered = true;
			QuestionPanel.SetActive (false);
		} else {

			WrongAnswer ();
			isAnswered = true;
			QuestionPanel.SetActive (false);
		}

	}

	public void CorrectAnswer()
	{

		GameObject.Find("Car2").GetComponent<CarsManager>().MoveForward();

	}

	public void WrongAnswer()
	{

		int pickRandomCars;

		pickRandomCars = Random.Range (0, 6);

		if (pickRandomCars == 0) {

			GameObject.Find ("Car1").GetComponent<CarsManager>().MoveForward ();
			GameObject.Find ("Car3").GetComponent<CarsManager>().MoveForward ();


		}

		if (pickRandomCars == 1) {

			GameObject.Find ("Car1").GetComponent<CarsManager>().MoveForward ();
			GameObject.Find ("Car4").GetComponent<CarsManager>().MoveForward ();
		

		}

		if (pickRandomCars == 2) {

			GameObject.Find ("Car4").GetComponent<CarsManager>().MoveForward ();
			GameObject.Find ("Car3").GetComponent<CarsManager>().MoveForward ();


		}

		if (pickRandomCars == 3) {

			GameObject.Find ("Car1").GetComponent<CarsManager>().MoveForward ();


		}


		if (pickRandomCars == 4) {

			GameObject.Find ("Car3").GetComponent<CarsManager>().MoveForward ();

		

		}


		if (pickRandomCars == 5) {

			GameObject.Find ("Car4").GetComponent<CarsManager>().MoveForward ();


		}




	}

	private IEnumerator Waiting(float waitTime)
	{

		yield return new WaitForSeconds(waitTime);
		QuestionPanel.SetActive (true);

	}

}
