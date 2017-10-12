
let allPlayers = document.querySelector('.allPlayers')
let allPlayerBody = document.querySelector('.allPlayerBody')
let allPlayerSearch = document.querySelector('.searchAllPlayerName')
let url = "/proxy"

allPlayerSearch.addEventListener('input', event => {
    const _userInput = event.target.value

let allPlayerInfo = fetch(url).then(response => response.json())
    .then(data => {
        console.log(data)
        let playersFound = data.Players.filter(player => {
            return player.displayName.indexOf(_userInput) >= 0;
        })
        let displayOfPlayers = document.querySelector('.allPlayerBody')
            displayOfPlayers.innerHTML = ''
            playersFound.slice(0, 15).forEach(function (playerData, index) {
                
                allPlayerBody.innerHTML += `
                <tr>
                    <td><a href="/playerinfo">${playerData.displayName}</a></td>
                    <td>${playerData.position}</td>
                    <td>${playerData.team}</td>
                    <td>${playerData.active}</td>
                    <td>${playerData.college}</td>
                </tr>
              `;
            })
    })
})