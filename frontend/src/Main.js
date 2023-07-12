import { useParams } from 'react-router-dom';

function Main() {
    const { query } = useParams();

    return (
        <>
            {query !== "euNf7RdWRJ7Up7" && (
                <div
                    style={{
                        display: 'flex',
                        flexDirection: 'column',
                        alignItems: 'center',
                        justifyContent: 'center',
                        height: '90vh',
                        background: `url("https://media.tenor.com/hYVsWvkpdrMAAAAC/you-didnt-say-the-magic-word-ah-ah.gif") no-repeat center center fixed`,
                        backgroundSize: 'cover',
                    }}
                />
            )}
        </>
    );
}

export default Main;