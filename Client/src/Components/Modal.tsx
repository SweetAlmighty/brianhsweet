import { useEffect } from 'react';
import './App.css'

function App() {
  useEffect(() => {
    const modal = document.querySelector("dialog");
    const audio = new Audio("congratulations-you-won.mp3");
    const startButton = document.getElementById("startButton");

    function buttonClicked() {
      if (startButton !== null) {
        startButton.hidden = true;
      }
      audio?.play();
      modal?.showModal();
    }

    startButton?.addEventListener("click", buttonClicked);
  }, []);
  
  return (
    <>
      <button id="startButton">Start</button>
      <dialog>
        <center>
        <p>
          It is not a joke
          <br />
          You are the 100,000th visitor of the day!
          <br />
          <br />
          Claim your winnings?
        </p>
        <button>OK</button>

        <button>Yes</button>
        </center>
      </dialog>
    </>
  )
}

export default App
