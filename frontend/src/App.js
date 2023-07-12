import { useEffect, useState } from "react";

function App() {
    const [message, setMessage] = useState("");

    // Fetching message from backend on mount
    useEffect(() => {
        fetch("https://heatpeakstudio.onrender.com:4000")
            .then((res) => console.log(res))
            .then((data) => setMessage(data.json().message));
    }, []);

    return (
        <div className="App">
            <h1>{message}</h1>
        </div>
    );
}

export default App;