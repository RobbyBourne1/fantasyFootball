
let url = '/proxy'

function getPlayerId() {
    let searchstring = window.location.pathname
    let parts = searchstring.split('/')
    return parts[parts.length - 1];
}

fetch(url).then(response => response.json())
    .then(data => {
        console.log(data)
        let playersFound = data.Players.filter(player => {
            return player.playerId === getPlayerId();
        })
        console.log(playersFound)
        let indvPlayerNT = document.querySelector('.indvPlayerNT')
        indvPlayerNT.innerHTML = `
                <dt>Player Name</dt>
                <dd>${playersFound[0].displayName}</dd>
                <br>
                <dt>Player Team</dt>
                <dd>${playersFound[0].team}</dd>
            `
        let indvPlayerPos = document.querySelector('.indvPlayerPos')
        indvPlayerPos.innerHTML = `
                <dt>Player Position</dt>
                <dd>${playersFound[0].position}</dd>
                <br>
                <dt>Player Status</dt>
                <dd>${playersFound[0].active}</dd>
            `
    })