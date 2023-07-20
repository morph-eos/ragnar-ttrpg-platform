import { useParams } from 'react-router-dom';

function Main() {
    const { query } = useParams();

    return (
        <>
            {query !== "actualworksite" ? (
                <div
                    style={{
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                        justifyContent: 'center',
                        height: '98vh',
                        background: `url("https://media.tenor.com/hYVsWvkpdrMAAAAC/you-didnt-say-the-magic-word-ah-ah.gif") no-repeat center center fixed`,
                        backgroundSize: 'contain',
                        backgroundPosition: 'center',
                        backgroundAttachment: 'fixed',
                        borderRadius: '20px', // Imposta il raggio di curvatura degli angoli
                    }}
                />
            ) : (
                <div
                    style={{
                        backgroundColor: 'orange',
                        height: '60px',
                        display: 'flex',
                        alignItems: 'center',
                        padding: '0 20px',
                        borderRadius: '40px', // Imposta il raggio di curvatura degli angoli
                    }}
                >
                    <img src="/logo.png" alt="Logo" style={{ height: '50px', marginRight: '20px' , marginLeft: '-5px'}}/>
                    {/* Aggiungi altri elementi della navbar, come pulsanti o menu, a destra del logo */}
                </div>
            )}
        </>
    );
}

export default Main;
