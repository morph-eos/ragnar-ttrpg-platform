function Main() {
    return (
    <>
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
            <img src="/logo.png" alt="Logo" style={{ height: '60px', marginRight: '20px' , marginLeft: '-19px'}}/>
            {/* Aggiungi altri elementi della navbar, come pulsanti o menu, a destra del logo */}
        </div>
        <div
            style={{
                display: 'flex',
                flexDirection: 'column',
                alignItems: 'center',
                justifyContent: 'center',
                height: '98vh',
                backgroundColor: 'black',
            }}
        >
            <img
                src="https://media2.giphy.com/media/hV1dkT2u1gqTUpKdKy/giphy.gif?cid=6c09b952nzs1x9zhws2aj1t84dp2j7rnxanrer4f3jxxd6p5&ep=v1_internal_gif_by_id&rid=giphy.gif&ct=g"
                alt="Under Construction"
                style={{ width: '50%', height: 'auto' }}
            />
            <h1 style={{ color: 'white' }}>
                Website under construction~ Check @heatpeakstudio on Instagram to get more informations!
            </h1>
        </div>
    </>
    );
}

export default Main;
