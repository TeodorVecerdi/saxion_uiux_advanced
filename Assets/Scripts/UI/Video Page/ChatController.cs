	using System.Collections;
	using TMPro;
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.UIElements;

	public class ChatController : MonoBehaviour {
		public ChatMessage ChatPrefab;
		public Transform ChatMessages;
		public TMP_InputField ChatInput;
		public ScrollRect ChatScrollRect;

		public void OnKeyTyped() {
			if (Input.GetKey(KeyCode.Return)) {
				var message = ChatInput.text;
				ChatInput.text = "";
				ChatInput.Select();
				ChatInput.ActivateInputField();
				var chatEntry = Instantiate(ChatPrefab, ChatMessages);
				chatEntry.Initialize(message);
				StartCoroutine(Scroll());
			}
		}

		private IEnumerator Scroll() {
			yield return new WaitForSeconds(0.05f);
			ChatScrollRect.verticalNormalizedPosition = 0.0f;
		}
	}