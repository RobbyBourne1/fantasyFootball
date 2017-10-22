
let allPlayers = document.querySelector('.allPlayers')
let allPlayerBody = document.querySelector('.allPlayerBody')
let allPlayerSearch = document.querySelector('.searchAllPlayerName')
let url = "/proxy"

allPlayerSearch.addEventListener('input', event => {
    const _userInput = event.target.value.toLowerCase()
    console.log(_userInput)

    let allPlayerInfo = fetch(url).then(response => response.json())
        .then(data => {
            let playersFound = data.Players.filter(player => {
                return player.displayName.toLowerCase().indexOf(_userInput) >= 0;
            })
            let displayOfPlayers = document.querySelector('.allPlayerBody')
            displayOfPlayers.innerHTML = ''
            playersFound.slice(0, 45).forEach(function (playerData, index) {

                if (playerData.active == 0) {
                    allPlayerBody.innerHTML += ""
                } else {
                    allPlayerBody.innerHTML += `
                    <tr>
                        <td><a href="/playerinfo/index/${playerData.playerId}?finitial=${playerData.fname}&lname=${playerData.lname}&team=${playerData.team}&position=${playerData.position}">${playerData.displayName}</a></td>
                        <td>${playerData.position}</td>
                        <td>${playerData.team}</td>
                        <td><a href="/playersinput/create">Add Player</a></td>
                    </tr>
                  `;
                }
            })
        })
})