import { useEffect, useState } from "react";
import consts from './consts';

function App() {
    const [message, setMessage] = useState("");

    // Fetching message from backend on mount
    useEffect(() => {
        fetch(consts.BACKEND)
            .then((res) => res.json())
            .then((data) => setMessage(data.message));
    }, []);

    return (
        <div className="App">
            <h1>{message}</h1>
        </div>
    );
}

export default App;